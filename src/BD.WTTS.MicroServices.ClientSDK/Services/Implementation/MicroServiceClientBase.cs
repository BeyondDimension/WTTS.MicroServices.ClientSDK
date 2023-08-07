namespace BD.WTTS.Services.Implementation;

public abstract partial class MicroServiceClientBase : GeneralHttpClientFactory, IMicroServiceClient, IApiConnectionPlatformHelper
{
    protected internal const string ClientName_ = "MicroServiceClient";

    internal readonly IApiConnection Conn;
    protected readonly IMicroServiceClient.ISettings settings;
    protected readonly IAuthHelper authHelper;
    protected readonly IToast toast;

    public string ApiBaseUrl { get; }

    public IMicroServiceClient.ISettings Settings => settings;

    RSA IApiConnectionPlatformHelper.RSA
    {
        get
        {
            try
            {
                return Settings.RSA;
            }
            catch (IsNotOfficialChannelPackageException e)
            {
                logger.LogError(e, nameof(ApiRspCode.IsNotOfficialChannelPackage));
                throw new ApiRspCodeException(ApiRspCode.IsNotOfficialChannelPackage);
            }
        }
    }

    protected sealed override string? DefaultClientName => ClientName_;

    public MicroServiceClientBase(
        ILogger<MicroServiceClientBase> logger,
        ILoggerFactory loggerFactory,
        System.Net.Http.Client.IHttpClientFactory clientFactory,
        IHttpPlatformHelperService http_helper,
        IToast toast,
        IAuthHelper authHelper,
        IMicroServiceClient.ISettings settings,
        IModelValidator validator,
        IApplicationVersionService applicationVersionService) : base(logger, http_helper, clientFactory)
    {
        this.authHelper = authHelper;
        this.toast = toast;
        this.settings = settings;
        ApiBaseUrl = settings.ApiBaseUrl.ThrowIsNull();
        Conn = new ApiConnection(loggerFactory.CreateLogger<ApiConnection>(), this, http_helper, validator, applicationVersionService);
    }

    /// <inheritdoc cref="IHttpPlatformHelperService.UserAgent"/>
    internal string UserAgent => http_helper.UserAgent;

    IAuthHelper IApiConnectionPlatformHelper.Auth => authHelper;

    public virtual Task SaveAuthTokenAsync(JWTEntity authToken) => Task.CompletedTask;

    public virtual Task OnLoginedAsync(IReadOnlyPhoneNumber? phoneNumber, ILoginResponse response) => Task.CompletedTask;

    public virtual void ShowResponseErrorMessage(string message) => toast.Show(ToastIcon.Error, message);

    protected virtual HttpClient CreateClient(HttpHandlerCategory category)
        => CreateClient(ClientName_, category);

    HttpClient IApiConnectionPlatformHelper.CreateClient(HttpHandlerCategory category) => CreateClient(category);

    Task<IApiRsp<JWTEntity?>> IApiConnectionPlatformHelper.RefreshToken(JWTEntity jwt)
    {
        IMicroServiceClient.IAccountClient thiz = this;
        return thiz.RefreshToken(jwt);
    }

    Task<IApiRsp> IMicroServiceClient.Download(bool isAnonymous, string requestUri,
        string cacheFilePath, IProgress<float>? progress, CancellationToken cancellationToken)
            => Conn.DownloadAsync(cancellationToken, requestUri, cacheFilePath, progress, isAnonymous);

    async Task<string> IMicroServiceClient.Info()
    {
        var api = await Conn.GetHtml(default, "/info");
        var str = api.Content;
        if (!string.IsNullOrWhiteSpace(str))
        {
            try
            {
                var jsonObj = JsonNode.Parse(str);
                return Serializable.SJSON(Serializable.JsonImplType.SystemTextJson, jsonObj, writeIndented: true);
            }
            catch
            {
                return str;
            }
        }
        else
        {
            return string.Empty;
        }
    }

    protected virtual void SetDeviceId(IDeviceId deviceId)
    {

    }

    void IApiConnectionPlatformHelper.SetDeviceId(IDeviceId deviceId) => SetDeviceId(deviceId);
}
