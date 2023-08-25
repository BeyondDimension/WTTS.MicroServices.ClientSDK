using Polly;
using static BD.WTTS.Services.IApiConnectionPlatformHelper;

namespace BD.WTTS.Services.Implementation;

partial class ApiConnection
{
    public async Task<IApiRsp<TResponseModel?>> SendShopAsync<TRequestModel, TResponseModel>(
        CancellationToken cancellationToken,
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

            HandleHttpRequest(request);

            var response = await client.UseDefaultSendAsync(request,
               HttpCompletionOption.ResponseHeadersRead,
               cancellationToken)
               .ConfigureAwait(false);

            HandleAppObsolete(response.Headers);

            var code = (ApiRspCode)response.StatusCode;

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