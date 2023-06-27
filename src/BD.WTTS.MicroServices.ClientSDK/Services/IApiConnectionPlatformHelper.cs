namespace BD.WTTS.Services;

public interface IApiConnectionPlatformHelper
{
    protected const string TAG = "ApiConnectionPH";

    const HttpHandlerCategory DefaultHttpHandlerCategory = HttpHandlerCategory.UserInitiated;

    #region Authentication

    IAuthHelper Auth { get; }

    /// <summary>
    /// 保存用户登录凭证
    /// </summary>
    /// <param name="authToken"></param>
    Task SaveAuthTokenAsync(JWTEntity authToken);

    /// <summary>
    /// 当登录完成时
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <param name="response"></param>
    Task OnLoginedAsync(IReadOnlyPhoneNumber? phoneNumber, ILoginResponse response);

    AuthenticationHeaderValue? GetAuthenticationHeaderValue(JWTEntity? authToken)
    {
        if (authToken.HasValue())
        {
            var authHeaderValue = new AuthenticationHeaderValue(ApiConstants.Basic, authToken?.AccessToken);
            return authHeaderValue;
        }
        return null;
    }

    #endregion

    /// <summary>
    /// 显示响应错误消息
    /// </summary>
    /// <param name="message"></param>
    void ShowResponseErrorMessage(string message);

    void ShowResponseErrorMessage(string? requestUri, IApiRsp response, string? errorAppendText = null)
    {
        if (response.Code == ApiRspCode.Canceled) return;
        var message = response.GetMessageByAppendText(errorAppendText);
        ShowResponseErrorMessage(message);
        Exception? exception = null;
        if (response is ApiRsp apiRsp) exception = apiRsp.ClientException;
        Log.Error(TAG, exception, $"requestUri: {(string.IsNullOrWhiteSpace(requestUri) ? string.Empty : requestUri.Split('?', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault())}, message: {message}");
    }

    HttpClient CreateClient(HttpHandlerCategory category = DefaultHttpHandlerCategory);

    RSA RSA { get; }

    /// <inheritdoc cref="IMicroServiceClient.IAccountClient.RefreshToken(JWTEntity)"/>
    Task<IApiRsp<JWTEntity?>> RefreshToken(JWTEntity jwt);

    /// <summary>
    /// 设置客户端设备 Id
    /// </summary>
    /// <param name="deviceId"></param>
    void SetDeviceId(IDeviceId deviceId);
}
