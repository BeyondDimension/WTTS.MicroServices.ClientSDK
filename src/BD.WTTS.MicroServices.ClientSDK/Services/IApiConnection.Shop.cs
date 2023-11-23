using static BD.WTTS.Services.IApiConnectionPlatformHelper;

namespace BD.WTTS.Services;

#pragma warning disable CA1068 // CancellationToken parameters must come last

internal partial interface IApiConnection
{

    Task<IApiRsp<JWTEntity?>> GetShopUserTokenAsync(CancellationToken cancellationToken);

    /// <summary>
    /// RequestModel+ResponseModel(调用 Shop 服务端接口)
    /// </summary>
    /// <typeparam name="TRequestModel">请求模型类型</typeparam>
    /// <typeparam name="TResponseModel">响应模型类型</typeparam>
    /// <param name="cancellationToken">传播应取消操作的通知</param>
    /// <param name="isAnonymous">是否匿名</param>
    /// <param name="method">HTTP方法</param>
    /// <param name="requestUri">服务端接口 Url 地址</param>
    /// <param name="request">请求模型</param>
    /// <param name="responseContentMaybeNull">响应内容是否能为<see langword="null"/></param>
    /// <param name="isShowResponseErrorMessage"></param>
    /// <param name="errorAppendText"></param>
    /// <param name="isPolly"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    Task<IApiRsp<TResponseModel?>> SendShopAsync<TRequestModel, TResponseModel>(
        CancellationToken cancellationToken,
        bool isAnonymous,
        HttpMethod method,
        string requestUri,
        TRequestModel? request,
        bool responseContentMaybeNull = false,
        bool isShowResponseErrorMessage = true,
        string? errorAppendText = null,
        bool isPolly = false,
        HttpHandlerCategory category = DefaultHttpHandlerCategory);
}