using Polly;
using static BD.WTTS.Services.IApiConnectionPlatformHelper;

namespace BD.WTTS.Services.Implementation;

partial class ApiConnection
{
    /// <summary>
    /// 从 Api 获取商城用户信息 特殊接口
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IApiRsp<JWTEntity?>> GetShopUserTokenAsync(CancellationToken cancellationToken)
    {
        var requestUri = "/identity/loginshop/token";
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = conn_helper.CreateClient(DefaultHttpHandlerCategory);

        IApiRsp<JWTEntity?> responseResult;
        try
        {
            JWTEntity? jwt = await SetRequestHeaderAuthorization(request);

            HandleHttpRequest(request);
            var response = await client.UseDefaultSendAsync(request,
                   HttpCompletionOption.ResponseHeadersRead,
                   cancellationToken)
                   .ConfigureAwait(false);

            HandleAppObsolete(response.Headers);

            var code = (ApiRspCode)response.StatusCode;

            if (response.Content == null)
            {
                responseResult = ApiRspHelper.Code<JWTEntity>(code);
            }
            else
            {
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                var obj = await JsonSerializer.DeserializeAsync<ShopBaseResponse<ShopJwtToken>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                }, cancellationToken: cancellationToken);
                if (obj == null)
                {
                    responseResult = ApiRspHelper.Code<JWTEntity>(code);
                }
                else
                {
                    responseResult = ApiRspHelper.Code(obj.Status ? ApiRspCode.OK : code, obj.Msg, obj.Data != null ? new JWTEntity
                    {
                        AccessToken = obj.Data.AccessToken,
                        ExpiresIn = DateTimeOffset.Now.AddSeconds(obj.Data.ExpiresIn - 3600),
                        RefreshToken = nameof(RefreshToken)
                    } : null);
                }
            }
        }
        catch (Exception ex)
        {
            (var code, var msg) = GetRspByExceptionWithLog(ex, requestUri);
            responseResult = ApiRspHelper.Code<JWTEntity>(code, msg, default, ex);
        }
        await GlobalResponseIntercept(
            true,
            HttpMethod.Get,
            requestUri,
            null,
            responseResult,
            false,
            isShowResponseErrorMessage: false);
        return responseResult;
    }

    /// <summary>
    /// 设置请求中的授权头
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    async ValueTask<JWTEntity?> SetShopRequestHeaderAuthorization(HttpRequestMessage request)
    {
        var authToken = await conn_helper.Auth.GetShopAuthTokenAsync();
        var authHeaderValue = conn_helper.GetAuthenticationHeaderValue(authToken);
        if (authHeaderValue != null)
        {
            request.Headers.Authorization = authHeaderValue;
            return authToken;
        }
        return null;
    }

    public Task<bool>? RefreshShopTokenAndAutoSaveTask { get; private set; }

    async Task<bool> RefreshShopTokenAndAutoSave()
    {
        var rsp = await GetShopUserTokenAsync(default);

        if (rsp.IsSuccess && rsp.Content != null)
        {
            await conn_helper.SaveShopAuthTokenAsync(rsp.Content);
            return true;
        }
        else if (rsp.Code != ApiRspCode.Unauthorized)
        {
            logger.LogWarning("GetShopUserToken fail, Code: {0}", rsp.Code);
        }
        return false;
    }

    async Task<bool> RefreshShopToken()
    {
        if (RefreshShopTokenAndAutoSaveTask == null)
        {
            RefreshShopTokenAndAutoSaveTask = RefreshShopTokenAndAutoSave();
        }
        var r = await RefreshShopTokenAndAutoSaveTask;
        return r;
    }

    public async Task<IApiRsp<TResponseModel?>> SendShopAsync<TRequestModel, TResponseModel>(
        CancellationToken cancellationToken,
        bool isAnonymous,
        HttpMethod method,
        string requestUri,
        TRequestModel? request,
        bool responseContentMaybeNull,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        var rsp = await SendShopCoreAsync<TRequestModel, TResponseModel>(
            isAnonymous,
            isPolly: isPolly,
            cancellationToken,
            method,
            requestUri,
            requestModel: request,
            responseContentMaybeNull,
            isShowResponseErrorMessage,
            errorAppendText);
        return rsp;
    }

    async Task<IApiRsp<TResponseModel?>> SendShopCoreAsync<TRequestModel, TResponseModel>(
        bool isAnonymous,
        bool isPolly,
        CancellationToken cancellationToken,
        HttpMethod method,
        string requestUri,
        TRequestModel? requestModel,
        bool responseContentMaybeNull,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        if (category == HttpHandlerCategory.Offline)
            isPolly = false;

        IApiRsp<TResponseModel?> response;
        Task<IApiRsp<TResponseModel?>> _SendShopCoreAsync(CancellationToken cancellationToken)
            => SendShopCoreAsync<TRequestModel, TResponseModel>(
                isAnonymous,
                cancellationToken,
                method,
                requestUri,
                requestModel,
                responseContentMaybeNull,
                !isPolly && isShowResponseErrorMessage,
                errorAppendText,
                category: category);
        if (isPolly)
        {
            response = await Policy.HandleResult<IApiRsp<TResponseModel?>>(PollyHandleResultPredicate)
                .WaitAndRetryAsync(numRetries, PollyRetryAttempt)
                .ExecuteAsync(_SendShopCoreAsync, cancellationToken);
        }
        else
        {
            response = await _SendShopCoreAsync(cancellationToken);
        }

        if (!response.IsSuccess)
        {
            // https://github.com/reactiveui/Fusillade/blob/2.4.67/src/Fusillade/RateLimitedHttpMessageHandler.cs#L106
            if (category != HttpHandlerCategory.Offline && (method == HttpMethod.Get ||
                method == HttpMethod.Head ||
                method == HttpMethod.Options))
            {
                category = HttpHandlerCategory.Offline;

                var responseByOffline = await _SendShopCoreAsync(cancellationToken);
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

    async Task<IApiRsp<TResponseModel?>> SendShopCoreAsync<TRequestModel, TResponseModel>(
        bool isAnonymous,
        CancellationToken cancellationToken,
        HttpMethod method,
        string requestUri,
        TRequestModel? requestModel,
        bool responseContentMaybeNull,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        HttpHandlerCategory category = DefaultHttpHandlerCategory)
    {
        const bool isApi = true;

        #region ModelValidator

        if (!IMicroServiceClient.DisableModelValidator &&
            requestModel != null &&
            typeof(TRequestModel) != typeof(object))
        {
            if (!validator.Validate(requestModel, out var errorMessage))
            {
                var validate_fail_r = ApiRspHelper.Code<TResponseModel>(
                    ApiRspCode.RequestModelValidateFail, errorMessage);
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

        try
        {
            var request = new HttpRequestMessage(method, requestUri);
            if (requestModel != null)
            {
                request.Content = JsonContent.Create(requestModel);
            }

            request.Headers.Accept.ParseAdd(MediaTypeNames.JSON);

            var client = conn_helper.CreateClient(category);

            JWTEntity? jwt = null;

            if (!isAnonymous)
            {
                jwt = await SetShopRequestHeaderAuthorization(request);
            }

            HandleHttpRequest(request);

            var response = await client.UseDefaultSendAsync(request,
               HttpCompletionOption.ResponseHeadersRead,
               cancellationToken)
               .ConfigureAwait(false);

            HandleAppObsolete(response.Headers);

            var code = (ApiRspCode)response.StatusCode;

            if (!isAnonymous && code == ApiRspCode.Unauthorized && jwt != null)
            {
                var resultRefreshToken = await RefreshShopToken();
                if (resultRefreshToken)
                {
                    var resultRecursion = await SendShopCoreAsync<TRequestModel, TResponseModel>(
                        isAnonymous,
                        isApi,
                        cancellationToken,
                        method,
                        requestUri,
                        requestModel,
                        responseContentMaybeNull,
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
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                var obj = await JsonSerializer.DeserializeAsync<ShopBaseResponse<TResponseModel>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                }, cancellationToken: cancellationToken);
                if (obj == null)
                {
                    responseResult = ApiRspHelper.Code<TResponseModel>(code);
                }
                else
                {
                    responseResult = ApiRspHelper.Code(obj.Status ? ApiRspCode.OK : code, obj.Msg, obj.Data);
                }
            }
        }
        catch (Exception ex)
        {
            (var code, var msg) = GetRspByExceptionWithLog(ex, requestUri);
            responseResult = ApiRspHelper.Code<TResponseModel>(code, msg, default, ex);
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
}