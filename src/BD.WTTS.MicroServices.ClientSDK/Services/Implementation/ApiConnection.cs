using Polly;
using static BD.WTTS.ApiConstants.Headers.Request;
using static BD.WTTS.MicroServices.Primitives.R.Strings;
using static BD.WTTS.Services.IApiConnectionPlatformHelper;

namespace BD.WTTS.Services.Implementation;

sealed class ApiConnection : IApiConnection
{
    readonly ILogger<ApiConnection> logger;
    readonly IHttpPlatformHelperService http_helper;
    readonly IApiConnectionPlatformHelper conn_helper;
    readonly IModelValidator validator;
    readonly Uri Referrer;

    public ApiConnection(
        ILogger<ApiConnection> logger,
        IApiConnectionPlatformHelper conn_helper,
        IHttpPlatformHelperService http_helper,
        IModelValidator validator,
        IApplicationVersionService applicationVersionService)
    {
        this.logger = logger;
        this.conn_helper = conn_helper;
        this.http_helper = http_helper;
        this.validator = validator;
        Referrer = new(ApiConstants.GetReferrer(DeviceInfo2.OSNameValue(),
            applicationVersionService.ApplicationVersion));
    }

    /// <summary>
    /// 设置请求中的授权头
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    async ValueTask<JWTEntity?> SetRequestHeaderAuthorization(HttpRequestMessage request)
    {
        var authToken = await conn_helper.Auth.GetAuthTokenAsync();
        var authHeaderValue = conn_helper.GetAuthenticationHeaderValue(authToken);
        if (authHeaderValue != null)
        {
            request.Headers.Authorization = authHeaderValue;
            return authToken;
        }
        return null;
    }

    /// <summary>
    /// 根据异常获取响应
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="requestUri"></param>
    /// <param name="logger"></param>
    /// <param name="logTag"></param>
    /// <returns></returns>
    public static (ApiRspCode code, string? msg) GetRspByExceptionWithLogCore(Exception ex, string requestUri, ILogger? logger = null, string? logTag = null)
    {
        if (ex is ApiRspCodeException apiResponseCodeException)
        {
            return (apiResponseCodeException.Code, null);
        }
        var knownType = ex.GetKnownType();
        switch (knownType)
        {
            case ExceptionKnownType.Canceled:
                return (ApiRspCode.Canceled, null);
            case ExceptionKnownType.OperationCanceled:
                return (ApiRspCode.OperationCanceled, null);
            case ExceptionKnownType.TaskCanceled:
                return (ApiRspCode.TaskCanceled, null);
            case ExceptionKnownType.CertificateNotYetValid:
                return (ApiRspCode.CertificateNotYetValid, null);
        }
        var code = ApiRspCode.ClientException;
        var exMsg = ex.GetAllMessage();
        var hasLogger = logger != null;
        var hasLogTag = !string.IsNullOrEmpty(logTag);
        if (hasLogger || hasLogTag)
        {
            const string logMessage = "ApiConn Fail({0} - {1})，Url：{2}";
            var logArgs = new object?[]
            {
                    (int)code,
                    code,
                    requestUri,
            };
            if (hasLogger)
            {
                logger!.LogError(ex, logMessage, logArgs);
            }
            else if (hasLogTag)
            {
                Log.Error(logTag!, ex, logMessage, logArgs);
            }
        }
        return (code, ApiRspExtensions.GetMessage(code, errorAppendText: exMsg));
    }

    /// <inheritdoc cref="GetRspByExceptionWithLogCore(Exception, string, Microsoft.Extensions.Logging.ILogger?, string?)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    (ApiRspCode code, string? msg) GetRspByExceptionWithLog(Exception ex, string requestUri)
        => GetRspByExceptionWithLogCore(ex, requestUri, logger);

    /// <summary>
    /// 返回 HTTP 401 未授权，清空当前 AuthToken，并调用 SignOut
    /// </summary>
    /// <param name="method"></param>
    /// <param name="requestUri"></param>
    async Task Unauthorized(HttpMethod method, string requestUri)
    {
        logger.LogCritical("Unauthorized method: {method}, requestUri: {requestUri}", method, requestUri);
        await conn_helper.Auth.SignOutAsync();
    }

    /// <summary>
    /// 生成请求内容
    /// </summary>
    /// <typeparam name="TRequestModel">请求模型类型</typeparam>
    /// <param name="isSecurity"></param>
    /// <param name="aes"></param>
    /// <param name="serializableImplType">序列化实现类型，如果为上传文件，则此参数无效</param>
    /// <param name="cancellationToken">传播应取消操作的通知</param>
    /// <param name="request">请求模型</param>
    /// <returns></returns>
    HttpContent? GetRequestContent<TRequestModel>(
        bool isSecurity,
        Aes? aes,
        Serializable.ImplType serializableImplType,
        TRequestModel? request,
        CancellationToken cancellationToken)
    {
        if (request == null) return null;
        if (isSecurity && aes == null) throw new ArgumentNullException(nameof(aes));

        if (request is IDeviceId deviceId)
        {
            conn_helper.SetDeviceId(deviceId);
        }

        HttpContent? httpContent;
        if (request is IUploadFileSource uploadFile) // 上传单个文件
        {
            httpContent = GetMultipartFormDataContent1(uploadFile);
        }
        else if (request is IEnumerable<IUploadFileSource> uploadFiles) // 上传多个文件
        {
            httpContent = GetMultipartFormDataContent2(uploadFiles);
        }
        else
        {
            httpContent = serializableImplType switch // 序列化模型
            {
                //Serializable.ImplType.NewtonsoftJson => GetJsonContent(Serializable.JsonImplType.NewtonsoftJson),
                Serializable.ImplType.MessagePack => GetMessagePackContent(),
                Serializable.ImplType.SystemTextJson => GetJsonContent(Serializable.JsonImplType.SystemTextJson),
                Serializable.ImplType.MemoryPack => GetMemoryPackContent(),
                _ => throw new ArgumentOutOfRangeException(nameof(serializableImplType), serializableImplType, null),
            };
        }
        return httpContent;
        HttpContent? GetJsonContent(Serializable.JsonImplType jsonImplType)
        {
            var jsonStr = request == null ? null : Serializable.SJSON(jsonImplType, request);
            if (jsonStr == null) return null;
            if (isSecurity)
            {
                var byteArray = aes.ThrowIsNull(nameof(aes)).Encrypt(Encoding.UTF8.GetBytes(jsonStr));
                var httpContent = new ByteArrayContent(byteArray);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(ApiConstants.MediaTypeNames.JSONSecurity);
                return httpContent;
            }
            else
            {
                var httpContent = new StringContent(jsonStr, Encoding.UTF8, MediaTypeNames.JSON);
                return httpContent;
            }
        }
        ByteArrayContent? GetMessagePackContent()
        {
            var byteArray = Serializable.SMP(request, cancellationToken);
            if (byteArray == null) return null;
            if (isSecurity)
            {
                byteArray = aes.ThrowIsNull(nameof(aes)).Encrypt(byteArray);
            }
            var httpContent = new ByteArrayContent(byteArray);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(isSecurity ? ApiConstants.MediaTypeNames.MessagePackSecurity : MediaTypeNames.MessagePack);
            return httpContent;
        }
        ByteArrayContent? GetMemoryPackContent()
        {
            var byteArray = Serializable.SMP2(request);
            if (byteArray == null) return null;
            if (isSecurity)
            {
                byteArray = aes.ThrowIsNull(nameof(aes)).Encrypt(byteArray);
            }
            var httpContent = new ByteArrayContent(byteArray);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(isSecurity ? ApiConstants.MediaTypeNames.MemoryPackSecurity : ApiConstants.MediaTypeNames.MemoryPack);
            return httpContent;
        }
        MultipartFormDataContent GetMultipartFormDataContent1(params IUploadFileSource[] uploadFiles)
        {
            var uploadFiles_ = uploadFiles.AsEnumerable();
            return GetMultipartFormDataContent2(uploadFiles_);
        }
        MultipartFormDataContent GetMultipartFormDataContent2(IEnumerable<IUploadFileSource> uploadFiles)
        {
            var multipartFormDataContent = new MultipartFormDataContent();
            var index = 0;
            foreach (var item in uploadFiles)
            {
                if (item.HasValue() && item.Available)
                {
                    var uploadFile = item;
                    var stream = uploadFile.OpenRead();
                    void ThrowUnsupportedUploadFileMediaType() // 未知的上传媒体类型
                    {
                        stream?.Dispose();
                        multipartFormDataContent.Dispose();
                        // ↑ 释放未压缩的文件流 与 总内容(MultipartFormDataContent) 当前文件源不释放
                        var msg = $"Unsupported Upload File MediaType, filePath: {uploadFile.FilePath}, index: {index}";
                        logger.LogError(msg);
                        throw new ApiRspCodeException(
                            ApiRspCode.UnsupportedUploadFileMediaType, msg);
                    }
                    var needHandle = true;
                    switch (uploadFile.UploadFileType) // 上传文件类型
                    {
                        case UploadFileType.Image: // 图片
                            if (uploadFile.IsCompressed) // 文件源已压缩过
                            {
                                if (string.IsNullOrEmpty(uploadFile.MIME)) // 无MIME，则检测
                                {
                                    if (FileFormat.IsImage(stream, out var format))
                                    {
                                        if (format.IsAllow()) // 属于允许的格式，则不处理
                                        {
                                            uploadFile.MIME = format.GetMIME();
                                            needHandle = false;
                                        }
                                    }
                                }
                                else if (FileFormat.AllowImageMediaTypeNames.Contains(uploadFile.MIME))
                                {
                                    // 有MIME值，且在允许的范围内，则不处理
                                    needHandle = false;
                                }
                            }
                            break;
                        //case UploadFileType.Voice: // 音频
                        //    break;
                        //case UploadFileType.Video: // 视频
                        //    break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(uploadFile.UploadFileType), uploadFile.UploadFileType, null);
                    }
                    if (needHandle)
                    {
                        var result = http_helper.TryHandleUploadFile(stream);
                        if (!result.HasValue) // 处理失败
                        {
                            ThrowUnsupportedUploadFileMediaType();
                        }
                        else
                        {
                            stream.Dispose();
                            uploadFile.Dispose();
                            // ↑ 释放未压缩的文件流 与 文件源
                            uploadFile = new UploadFileSource
                            {
                                FilePath = result.Value.filePath,
                                MIME = result.Value.mime,
                                IsCompressed = true,
                                IsCache = true,
                                UploadFileType = uploadFile.UploadFileType,
                            };
                            stream = uploadFile.OpenRead();
                            // 生成新的文件源 并 重新打开文件流
                        }
                    }
                    var content = new UploadFileContent(uploadFile, stream);
                    if (string.IsNullOrWhiteSpace(uploadFile.FilePath))
                    {
                        multipartFormDataContent.Add(content, "file");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(uploadFile.FilePath);
                        multipartFormDataContent.Add(content, "file", fileName);
                    }
                }
                index++;
            }
            if (!multipartFormDataContent.Any())
            {
                throw new ApiRspCodeException(ApiRspCode.LackAvailableUploadFile);
            }
            return multipartFormDataContent;
        }
    }

    /// <inheritdoc cref="IApiConnectionPlatformHelper.ShowResponseErrorMessage(string?, IApiRsp, string?)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void ShowResponseErrorMessage(string requestUri, IApiRsp response, string? errorAppendText = null)
        => conn_helper.ShowResponseErrorMessage(requestUri, response, errorAppendText);

    async Task GlobalResponseIntercept(
        HttpMethod method,
        string requestUri,
        IApiRsp response,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null)
    {
        if (!response.IsSuccess)
        {
            if (isShowResponseErrorMessage)
            {
                ShowResponseErrorMessage(requestUri, response, errorAppendText);
            }

            if (response.Code == ApiRspCode.Unauthorized)
            {
                await Unauthorized(method, requestUri);
            }
        }

        if (response is ApiRspBase rspImpl)
        {
            rspImpl.Url = requestUri;
        }
    }

    async Task GlobalResponseIntercept<TResponseModel>(
        bool isApi,
        HttpMethod method,
        string requestUri,
        object? request,
        IApiRsp<TResponseModel?> response,
        bool responseContentMaybeNull,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null)
    {
        if (response.IsSuccess)
        {
            if (!responseContentMaybeNull && response.Content == null)
            {
                response.Code = ApiRspCode.NoResponseContent;
            }
            else
            {
                if (isApi)
                {
                    if (!responseContentMaybeNull && response is
                        IApiRsp<IExplicitHasValue?> explicitHasValue &&
                        !explicitHasValue.Content.HasValue())
                    {
                        response.Code = ApiRspCode.NoResponseContentValue;
                    }
                    else
                    {
                        if (response is IApiRsp<ILoginResponse> loginResponse
                              && loginResponse.Content != null)
                        {
                            //IReadOnlyPhoneNumber? phoneNumber;
                            //if (loginResponse.Content is IReadOnlyPhoneNumber phoneNumber1)
                            //    phoneNumber = phoneNumber1;
                            //else if (request is IReadOnlyPhoneNumber phoneNumber2)
                            //    phoneNumber = phoneNumber2;
                            //else
                            //    phoneNumber = null;
                            //await conn_helper.OnLoginedAsync(phoneNumber, loginResponse.Content);
                            await conn_helper.OnLoginedAsync(loginResponse.Content, loginResponse.Content);
                        }
                        else if (response is IApiRsp<IReadOnlyAuthToken?> authTokenResponse
                            && authTokenResponse.Content != null)
                        {
                            var authToken = authTokenResponse.Content.AuthToken;
                            if (authToken.HasValue())
                            {
                                await conn_helper.SaveAuthTokenAsync(
                                    authToken.ThrowIsNull(nameof(authToken)));
                            }
                        }
                        else if (response is IApiRsp<Guid[]> guidsResponse
                            && guidsResponse.Content != null)
                        {
                            if (request is IUploadFileSource uploadFile) // 上传单个文件
                            {
                                HandleUploadFile(uploadFile);
                            }
                            else if (request is IEnumerable<IUploadFileSource> uploadFiles) // 上传多个文件
                            {
                                HandleUploadFiles(uploadFiles);
                            }
                            void HandleUploadFile(params IUploadFileSource[] uploadFiles)
                            {
                                var uploadFiles_ = uploadFiles.AsEnumerable();
                                HandleUploadFiles(uploadFiles_);
                            }
                            void HandleUploadFiles(IEnumerable<IUploadFileSource> uploadFiles)
                            {
                                var items = uploadFiles.Where(x => x.HasValue() && x.Available).ToArray();
                                if (items.Length != guidsResponse.Content.Length)
                                {
                                    var msg = $"Unequal Length Upload File request: {items.Length}, response: {guidsResponse.Content.Length}";
                                    logger.LogError(msg);
                                    throw new ApiRspCodeException(
                                        ApiRspCode.UnequalLengthUploadFile, msg);
                                }
                                else
                                {
                                    // 上传后将此缓存文件移动到下载图片文件夹中
                                    throw new NotImplementedException();
                                }
                            }
                        }
                    }
                }
            }
        }
        await GlobalResponseIntercept(method, requestUri, response, isShowResponseErrorMessage, errorAppendText);
    }

    async Task<IApiRsp<TResponseModel?>?> GlobalBeforeInterceptAsync<TResponseModel>(
        string requestUri,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null)
    {
        IApiRsp<TResponseModel?>? responseResult = null;

        #region NetworkAccess

        var isConnected = await http_helper.IsConnectedAsync();

        if (!isConnected)
        {
            responseResult = ApiRspHelper.Code<TResponseModel>(
                ApiRspCode.NetworkConnectionInterruption,
                NetworkConnectionInterruption);
        }

        #endregion

        if (isShowResponseErrorMessage && responseResult != null && !responseResult.IsSuccess)
        {
            ShowResponseErrorMessage(requestUri, responseResult, errorAppendText);
        }

        return responseResult;
    }

    public Task<bool>? RefreshTokenAndAutoSaveTask { get; private set; }

    async Task<bool> RefreshTokenAndAutoSave(JWTEntity jwt)
    {
        var rsp = await conn_helper.RefreshToken(jwt);

        if (rsp.IsSuccess && rsp.Content != null)
        {
            await conn_helper.SaveAuthTokenAsync(rsp.Content);
            return true;
        }
        else if (rsp.Code != ApiRspCode.Unauthorized)
        {
            logger.LogWarning("RefreshToken fail, Code: {0}", rsp.Code);
        }
        return false;
    }

    async Task<bool> RefreshToken(JWTEntity jwt)
    {
        if (RefreshTokenAndAutoSaveTask == null)
        {
            RefreshTokenAndAutoSaveTask = RefreshTokenAndAutoSave(jwt);
        }
        var r = await RefreshTokenAndAutoSaveTask;
        return r;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsAppObsolete(HttpResponseHeaders headers)
        => headers.TryGetValues(ApiConstants.Headers.Response.AppObsolete, out var values) &&
            values.Contains(bool.TrueString, StringComparer.OrdinalIgnoreCase);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static void HandleAppObsolete(HttpResponseHeaders headers)
    {
        if (IsAppObsolete(headers))
        {
            throw new ApiRspCodeException(ApiRspCode.AppObsolete);
        }
    }

    public async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        HttpCompletionOption completionOption,
        HttpHandlerCategory category = DefaultHttpHandlerCategory,
        CancellationToken cancellationToken = default)
    {
        var client = conn_helper.CreateClient(category);

        HandleHttpRequest(request);

        var response = await client.UseDefaultSendAsync(request,
            completionOption,
            cancellationToken).ConfigureAwait(false);

        HandleAppObsolete(response.Headers);

        return response;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void HandleHttpRequest(HttpRequestMessage request)
    {
        request.Headers.AcceptLanguage.ParseAdd(http_helper.AcceptLanguage);
        request.Headers.Referrer = Referrer;
    }

    async Task<IApiRsp<TResponseModel?>> SendCoreAsync<TRequestModel, TResponseModel>(
        bool isAnonymous,
        bool isApi,
        CancellationToken cancellationToken,
        HttpMethod method,
        string requestUri,
        TRequestModel? requestModel,
        bool responseContentMaybeNull,
        bool isSecurity,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        #region ModelValidator

        if (!IMicroServiceClient.DisableModelValidator && isApi &&
            requestModel != null &&
            typeof(TRequestModel) != typeof(object))
        {
            if (!validator.Validate(requestModel, out var errorMessage))
            {
                var validate_fail_r = ApiRspHelper.Code<TResponseModel>(
                    ApiRspCode.RequestModelValidateFail, errorMessage);
                if (isShowResponseErrorMessage) ShowResponseErrorMessage(requestUri, validate_fail_r, errorAppendText);
                return validate_fail_r;
            }
        }

        #endregion

        var globalBeforeInterceptResponse = await GlobalBeforeInterceptAsync<TResponseModel>(requestUri, isShowResponseErrorMessage, errorAppendText);
        if (globalBeforeInterceptResponse != null)
        {
            return globalBeforeInterceptResponse;
        }

        IApiRsp<TResponseModel?> responseResult;

        Aes? aes = null;

        try
        {
            if (isSecurity)
            {
                // 行业标准加密
                aes = AESUtils.Create();
            }

            var serializableImplType = IMicroServiceClient.SerializableImplType;

            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = GetRequestContent(
                   isSecurity,
                   aes,
                   serializableImplType,
                   requestModel,
                   cancellationToken),
            };

            switch (serializableImplType)
            {
                case Serializable.ImplType.NewtonsoftJson:
                case Serializable.ImplType.SystemTextJson:
                    request.Headers.Accept.ParseAdd(isSecurity ?
                        ApiConstants.MediaTypeNames.JSONSecurity :
                        MediaTypeNames.JSON);
                    break;
                case Serializable.ImplType.MessagePack:
                    request.Headers.Accept.ParseAdd(isSecurity ?
                        ApiConstants.MediaTypeNames.MessagePackSecurity :
                        MediaTypeNames.MessagePack);
                    break;
                case Serializable.ImplType.MemoryPack:
                    request.Headers.Accept.ParseAdd(isSecurity ?
                        ApiConstants.MediaTypeNames.MemoryPackSecurity :
                        ApiConstants.MediaTypeNames.MemoryPack);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serializableImplType),
                        serializableImplType, null);
            }

            if (isSecurity)
            {
                var skey_bytes = aes.ThrowIsNull(nameof(aes)).ToParamsByteArray();
                var padding = RSAUtils.DefaultPadding;
                var skey_str = conn_helper.RSA.EncryptToHexString(skey_bytes, padding);
                request.Headers.Add(SecurityKeyHex, skey_str);
                request.Headers.Add(SecurityKeyPadding,
                    padding.OaepHashAlgorithm.ToString() ?? string.Empty);
            }

            JWTEntity? jwt = null;

            if (!isAnonymous)
            {
                jwt = await SetRequestHeaderAuthorization(request);
            }

            var client = conn_helper.CreateClient(category);

            HandleHttpRequest(request);

            var response = await client.UseDefaultSendAsync(request,
               HttpCompletionOption.ResponseHeadersRead,
               cancellationToken)
               .ConfigureAwait(false);

            HandleAppObsolete(response.Headers);

            var code = (ApiRspCode)response.StatusCode;

            if (!isAnonymous && code == ApiRspCode.Unauthorized && jwt != null)
            {
                var resultRefreshToken = await RefreshToken(jwt);
                if (resultRefreshToken)
                {
                    var resultRecursion = await SendCoreAsync<TRequestModel, TResponseModel>(
                        isAnonymous,
                        isApi,
                        cancellationToken,
                        method,
                        requestUri,
                        requestModel,
                        responseContentMaybeNull,
                        isSecurity,
                        isShowResponseErrorMessage,
                        errorAppendText,
                        category: HttpHandlerCategory.UserInitiated);
                    return resultRecursion;
                }
            }

            if (response.Content == null)
            {
                responseResult = ApiRspHelper.Code<TResponseModel>(code);
            }
            else
            {
                if (!isApi && typeof(TResponseModel) == typeof(byte[]))
                {
                    var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
                    responseResult = ApiRspHelper.Code(code, null, (TResponseModel)(object)bytes);
                }
                else if (!isApi && typeof(TResponseModel) == typeof(string))
                {
                    var str = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    responseResult = ApiRspHelper.Code(code, null, (TResponseModel)(object)str);
                }
                else
                {
                    async ValueTask<IApiRsp<TResponseModel?>> MessagePackDeserializeAsync(bool rspIsCiphertext)
                    {
                        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        using var cryptoStream = rspIsCiphertext ? new CryptoStream(stream, aes.ThrowIsNull(nameof(aes)).CreateDecryptor(), CryptoStreamMode.Read) : null;
                        var result = await ApiRspHelper.DeserializeAsync<TResponseModel>(rspIsCiphertext ? cryptoStream.ThrowIsNull(nameof(cryptoStream)) : stream, cancellationToken);
                        return result;
                    }
                    async ValueTask<IApiRsp<TResponseModel?>> MemoryPackDeserializeAsync(bool rspIsCiphertext)
                    {
                        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        using var cryptoStream = rspIsCiphertext ? new CryptoStream(stream, aes.ThrowIsNull(nameof(aes)).CreateDecryptor(), CryptoStreamMode.Read) : null;
                        var result = await ApiRspHelper.MemoryPackDeserializeAsync<TResponseModel>(rspIsCiphertext ? cryptoStream.ThrowIsNull(nameof(cryptoStream)) : stream, cancellationToken);
                        return result;
                    }
                    async ValueTask<IApiRsp<TResponseModel?>> JsonDeserializeAsync(bool rspIsCiphertext)
                    {
                        var a = await response.Content.ReadAsByteArrayAsync();
                        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        using var cryptoStream = rspIsCiphertext ? new CryptoStream(stream, aes.ThrowIsNull(nameof(aes)).CreateDecryptor(), CryptoStreamMode.Read) : null;
                        var result = await ApiRspHelper.JsonPackDeserializeAsync<TResponseModel>(rspIsCiphertext ? cryptoStream.ThrowIsNull(nameof(cryptoStream)) : stream, cancellationToken);
                        return result;
                    }

                    var mime = response.Content.Headers.ContentType?.MediaType;

                    switch (mime)
                    {
                        case ApiConstants.MediaTypeNames.MessagePackSecurity:
                            responseResult = await MessagePackDeserializeAsync(true);
                            break;
                        case ApiConstants.MediaTypeNames.MemoryPack:
                            responseResult = await MemoryPackDeserializeAsync(false);
                            break;
                        case ApiConstants.MediaTypeNames.MemoryPackSecurity:
                            responseResult = await MemoryPackDeserializeAsync(true);
                            break;
                        case MediaTypeNames.MessagePack:
                            responseResult = await MessagePackDeserializeAsync(false);
                            break;
                        case MediaTypeNames.JSON:
                            responseResult = await JsonDeserializeAsync(false);
                            break;
                        case ApiConstants.MediaTypeNames.JSONSecurity:
                            responseResult = await JsonDeserializeAsync(true);
                            break;
#if DEBUG
                        case MediaTypeNames.HTML:
                        case MediaTypeNames.TXT:
                            var htmlString = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            responseResult = ApiRspHelper.Code<TResponseModel>(response.IsSuccessStatusCode ? ApiRspCode.UnsupportedResponseMediaType : code, htmlString);
                            break;
#endif
                        default:
                            responseResult = ApiRspHelper.Code<TResponseModel>(response.IsSuccessStatusCode ? ApiRspCode.UnsupportedResponseMediaType : code);
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            (var code, var msg) = GetRspByExceptionWithLog(ex, requestUri);
            responseResult = ApiRspHelper.Code<TResponseModel>(code, msg, default, ex);
        }
        finally
        {
            aes?.Dispose();
        }
        await GlobalResponseIntercept(
            isApi,
            method,
            requestUri,
            requestModel,
            responseResult,
            responseContentMaybeNull, isShowResponseErrorMessage: false);
        return responseResult;
    }

    #region Polly

    const int numRetries = 10;

    static bool PollyHandleResultPredicate<TResponse>(TResponse response) where TResponse : IApiRsp
        => response is ApiRspBase impl &&
            impl.ClientException != null &&
            impl.Code == ApiRspCode.ClientException;

    static TimeSpan PollyRetryAttempt(int attemptNumber)
    {
        var powY = attemptNumber % numRetries;
        var timeSpan = TimeSpan.FromMilliseconds(Math.Pow(2, powY));
        int addS = attemptNumber / numRetries;
        if (addS > 0) timeSpan = timeSpan.Add(TimeSpan.FromSeconds(addS));
        return timeSpan;
    }

    #endregion

    async Task<IApiRsp<TResponseModel?>> SendCoreAsync<TRequestModel, TResponseModel>(
        bool isPolly,
        bool isAnonymous,
        bool isApi,
        CancellationToken cancellationToken,
        HttpMethod method,
        string requestUri,
        TRequestModel? requestModel,
        bool responseContentMaybeNull,
        bool isSecurity,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        if (category == HttpHandlerCategory.Offline)
            isPolly = false;

        IApiRsp<TResponseModel?> response;
        Task<IApiRsp<TResponseModel?>> _SendCoreAsync(CancellationToken cancellationToken)
            => SendCoreAsync<TRequestModel, TResponseModel>(
                isAnonymous,
                isApi,
                cancellationToken,
                method,
                requestUri,
                requestModel,
                responseContentMaybeNull,
                isSecurity,
                !isPolly && isShowResponseErrorMessage,
                errorAppendText,
                category: category);
        if (isPolly)
        {
            response = await Policy.HandleResult<IApiRsp<TResponseModel?>>(PollyHandleResultPredicate)
                .WaitAndRetryAsync(numRetries, PollyRetryAttempt)
                .ExecuteAsync(_SendCoreAsync, cancellationToken);
        }
        else
        {
            response = await _SendCoreAsync(cancellationToken);
        }

        if (!response.IsSuccess)
        {
            // https://github.com/reactiveui/Fusillade/blob/2.4.67/src/Fusillade/RateLimitedHttpMessageHandler.cs#L106
            if (!isSecurity && category != HttpHandlerCategory.Offline && (method == HttpMethod.Get ||
                method == HttpMethod.Head ||
                method == HttpMethod.Options))
            {
                category = HttpHandlerCategory.Offline;

                var responseByOffline = await _SendCoreAsync(cancellationToken);
                if (responseByOffline.IsSuccess)
                {
                    return responseByOffline;
                }
            }

            if (isShowResponseErrorMessage)
            {
                ShowResponseErrorMessage(requestUri, response, errorAppendText);
            }
        }

        return response;
    }

    const int bufferSize = 4096;

    async Task<IApiRsp> DownloadAsync(
       CancellationToken cancellationToken,
       string requestUri,
       string cacheFilePath,
       IProgress<float>? progress,
       bool isAnonymous,
       bool isShowResponseErrorMessage = true,
       string? errorAppendText = null)
    {
        var cacheDirPath = Path.GetDirectoryName(cacheFilePath);
        if (cacheDirPath == null) throw new ArgumentNullException(nameof(cacheDirPath));
        IOPath.DirCreateByNotExists(cacheDirPath);

        var globalBeforeInterceptResponse = await GlobalBeforeInterceptAsync<object>(requestUri, isShowResponseErrorMessage, errorAppendText);
        if (globalBeforeInterceptResponse != null)
        {
            return globalBeforeInterceptResponse;
        }

        var method = HttpMethod.Get;
        IApiRsp responseResult;
        try
        {
            var request = new HttpRequestMessage(method, requestUri);

            JWTEntity? jwt = null;

            if (!isAnonymous)
            {
                jwt = await SetRequestHeaderAuthorization(request);
            }

            var client = conn_helper.CreateClient();

            HandleHttpRequest(request);

            var response = await client.UseDefaultSendAsync(request,
               HttpCompletionOption.ResponseHeadersRead,
               cancellationToken)
               .ConfigureAwait(false);

            var code = (ApiRspCode)response.StatusCode;

            if (!isAnonymous && code == ApiRspCode.Unauthorized && jwt != null)
            {
                var resultRefreshToken = await RefreshToken(jwt);
                if (resultRefreshToken)
                {
                    var resultRecursion = await DownloadAsync(
                        cancellationToken,
                        requestUri,
                        cacheFilePath,
                        progress,
                        isAnonymous,
                        isShowResponseErrorMessage,
                        errorAppendText);
                    return resultRecursion;
                }
            }

            responseResult = ApiRspHelper.Code(code);
            if (responseResult.IsSuccess)
            {
                var total = response.Content.Headers.ContentLength ?? -1L;
                if (total > 0)
                {
                    var canReportProgress = progress != null;
                    IOPath.FileIfExistsItDelete(cacheFilePath);
                    using var fileStream = new FileStream(cacheFilePath,
                        FileMode.CreateNew,
                        FileAccess.Write,
                        FileShare.None,
                        bufferSize,
                        true);
                    using var stream = await response.Content.ReadAsStreamAsync();
                    var totalRead = 0L;
                    var buffer = new byte[bufferSize];
                    var isMoreToRead = true;
                    var lastProgressValue = 0f;
                    do
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        var readAsyncToken = CancellationTokenSource.
                            CreateLinkedTokenSource(cancellationToken);
                        readAsyncToken.CancelAfter(5000);
                        var read = await stream.ReadAsync(buffer.AsMemory(0, buffer.Length), readAsyncToken.Token);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
                            totalRead += read;
                            if (canReportProgress)
                            {
                                var progressValue = MathF.Round((float)totalRead / total * ApiConstants.MaxProgress, 2, MidpointRounding.AwayFromZero);
                                if (progressValue != lastProgressValue)
                                {
                                    progress?.Report(progressValue);
                                    lastProgressValue = progressValue;
                                }
                            }
                        }
                    }
                    while (isMoreToRead);
                }
                else
                {
                    responseResult.Code = ApiRspCode.NoResponseContent;
                }
            }
        }
        catch (Exception ex)
        {
            (var code, var msg) = GetRspByExceptionWithLog(ex, requestUri);
            responseResult = ApiRspHelper.Code(code, msg, ex);
        }
        await GlobalResponseIntercept(
            method,
            requestUri,
            responseResult,
            isShowResponseErrorMessage,
            errorAppendText);
        return responseResult;
    }

    public async Task<IApiRsp> DownloadAsync(
        CancellationToken cancellationToken,
        string requestUri,
        string cacheFilePath,
        IProgress<float>? progress,
        bool isAnonymous,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        bool isPolly = true,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        IApiRsp response;
        Task<IApiRsp> _DownloadAsync()
            => DownloadAsync(
                cancellationToken,
                requestUri,
                cacheFilePath,
                progress,
                isAnonymous,
                !isPolly && isShowResponseErrorMessage,
                errorAppendText,
                category: category);
        if (isPolly)
        {
            response = await Policy.HandleResult<IApiRsp>(PollyHandleResultPredicate)
                .WaitAndRetryAsync(numRetries, PollyRetryAttempt)
                .ExecuteAsync(_DownloadAsync);
            if (!response.IsSuccess)
            {
                if (isShowResponseErrorMessage)
                {
                    ShowResponseErrorMessage(requestUri, response, errorAppendText);
                }
            }
        }
        else
        {
            response = await _DownloadAsync();
        }
        return response;
    }

    public async Task<IApiRsp<TResponseModel?>> SendAsync<TRequestModel, TResponseModel>(CancellationToken cancellationToken, HttpMethod method, string requestUri, TRequestModel? request, bool responseContentMaybeNull, bool isSecurity, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<TRequestModel, TResponseModel>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: true,
            cancellationToken,
            method,
            requestUri,
            requestModel: request,
            responseContentMaybeNull,
            isSecurity,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    public async Task<IApiRsp<byte[]?>> GetRaw(CancellationToken cancellationToken, string requestUri, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = true,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<object, byte[]>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: false,
            cancellationToken,
            HttpMethod.Get,
            requestUri,
            requestModel: null,
            responseContentMaybeNull: false,
            isSecurity: false,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    public async Task<IApiRsp<string?>> GetHtml(CancellationToken cancellationToken, string requestUri, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = true,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<object, string>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: false,
            cancellationToken,
            HttpMethod.Get,
            requestUri,
            requestModel: null,
            responseContentMaybeNull: false,
            isSecurity: false,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    public async Task<IApiRsp> SendAsync<TRequestModel>(CancellationToken cancellationToken, HttpMethod method, string requestUri, TRequestModel? request, bool isSecurity, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<TRequestModel, object>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: true,
            cancellationToken,
            method,
            requestUri,
            requestModel: request,
            responseContentMaybeNull: true,
            isSecurity,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    public async Task<IApiRsp> SendAsync(CancellationToken cancellationToken, HttpMethod method, string requestUri, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<object, object>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: true,
            cancellationToken,
            method,
            requestUri,
            requestModel: null,
            responseContentMaybeNull: true,
            isSecurity: false,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    public async Task<IApiRsp<TResponseModel?>> SendAsync<TResponseModel>(CancellationToken cancellationToken, HttpMethod method, string requestUri, bool responseContentMaybeNull, bool isSecurity, bool isAnonymous, bool isShowResponseErrorMessage = true, string? errorAppendText = null, bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendCoreAsync<object, TResponseModel>(
            isPolly: isPolly,
            isAnonymous: isAnonymous,
            isApi: true,
            cancellationToken,
            method,
            requestUri,
            requestModel: null,
            responseContentMaybeNull,
            isSecurity,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }
}
