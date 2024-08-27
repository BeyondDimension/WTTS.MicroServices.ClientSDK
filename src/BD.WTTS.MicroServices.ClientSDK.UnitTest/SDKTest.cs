namespace BD.WTTS.MicroServices.ClientSDK.UnitTest;

public sealed partial class SDKTest : IDisposable
{
    IHost? host;
    RSA? rsa;
    bool disposedValue;
    IMicroServiceClient? client;
    static string? tel;
    static bool localhost;

    const string AppVerId = "4403abfa-82c0-4cea-92dd-da5f89c725f1";

    public static string ApiBaseUrl => localhost ?
        "https://localhost:7124" :
        "https://steampp.mossimo.net:8800";

    async Task OnTestEnv(Func<IHost, IMicroServiceClient, Task> envAction)
    {
        foreach (var implType in new[] {
            Serializable.ImplType.MessagePack,
            Serializable.ImplType.SystemTextJson,
            Serializable.ImplType.MemoryPack,
        })
        {
            host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                //services.AddSingleton(repo.Object);
                services.AddSingleton<MicroServiceClient>();
                services.AddSingleton<IHttpClientFactory, TestHttpClientFactory>();
                services.AddSingleton<IHttpPlatformHelperService, TestHttpPlatformHelperService>();
                services.AddSingleton<IToast, TestToast>();
                services.AddSingleton<IAuthHelper, AuthHelper>();
                services.AddSingleton<IModelValidator, TestModelValidator>();
                services.AddSingleton<IApplicationVersionService, TestApplicationVersionService>();
                services.AddSingleton<IMicroServiceClient.ISettings, TestSettings>();
                services.AddSingleton<IMicroServiceClient>(s => s.GetRequiredService<MicroServiceClient>());
                IMicroServiceClient.SerializableImplType = implType;
            })
            .ConfigureLogging(cfg => cfg.AddConsole())
            .Build();
            Ioc.ConfigureServices(host.Services);
            client = host!.Services.GetRequiredService<IMicroServiceClient>();

            await envAction(host, client);
        }
    }

    void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                rsa?.Dispose();
                host?.Dispose();
            }
            rsa = null;
            host = null;
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    sealed class TestHttpClientFactory : IHttpClientFactory
    {
        public TestHttpClientFactory()
        {
        }

        HttpClient IHttpClientFactory.CreateClient(string name, HttpHandlerCategory category)
        {
            var handler = new SocketsHttpHandler
            {
                AutomaticDecompression = DecompressionMethods.Brotli,
            };
            HttpClient httpClient = new(handler) { BaseAddress = new(ApiBaseUrl), };
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent.Default);
            return httpClient;
        }
    }

    sealed class TestHttpPlatformHelperService : HttpPlatformHelperService
    {
        public override string UserAgent => DefaultUserAgent;
    }

    sealed class TestToast : IToast
    {
        public void Show(ToastIcon icon, string text, int? duration = null)
        {
            TestContext.WriteLine(text);
        }

        public void Show(ToastIcon icon, string text, ToastLength duration)
        {
            TestContext.WriteLine(text);
        }

        void IToast.Show(string text, int? duration)
        {
            TestContext.WriteLine(text);
        }

        void IToast.Show(string text, ToastLength duration)
        {
            TestContext.WriteLine(text);
        }
    }

    sealed class TestApplicationVersionService : IApplicationVersionService
    {
        string IApplicationVersionService.ApplicationVersion => "3.0.0";

        string IApplicationVersionService.AssemblyTrademark => "TestApp";
    }

    sealed class TestSettings : IMicroServiceClient.ISettings
    {
        string? IMicroServiceClient.ISettings.ApiBaseUrl { get; set; } = ApiBaseUrl;

        RSA IMicroServiceClient.ISettings.RSA { get; } = RSAUtils.CreateFromJsonString(RSAKeyJsonString);

        const string RSAKeyJsonString = """
            {"v":"AQAB","n":"z3JV6g-cRPGBef0Dk_zCV3iwfg2pfoJ5dCyZdzWu1SznOZEOFoBSNVOzSSJB-9_WrsmjB2TFtxebTa3EqfLMtOYjpVZzIfWpGX2OMOelIwOsaBkrWzoxlFDJDD0ZDrp0027FtpbrGAb3HwWF73KxiQfpXGU_6W881ALz6D1JnQu1EaKwZULCu8ACiIRp9EBswqMMamWYYj8caGKywohBHMdwURV3y451jNrSjLSXcdGVRACEa1agj81EcBCr9331pyBznHC0rXgLyTqnyk6bGvMqILPqeEs5P375RftzniwsCHZCpXo5EAtUCEzIE86dY6mBv6vgdv0WiJ1kpER-MqT84mKXqi5Yw7KiVtIjGPg8Sv58oLYbVYENDZZqve2rDy_XpoCN4XFCVEjrLYmJ8NN6qBNnjx7TO7OIrYBxkB4DRDp2P1uwMLFtke9JtrtGB-ZGkxRA4hqnXNvnP6VcYfo1uWd8EvjSp8UZndCFEqP63DKNCZHBQFFXV3oMGEG9fUvMO6URRAVW3A_MF6Sv4YWaxNPUlUuE5t_UiqCkIf_Bedbckdwtq6n5w37Jgm_2N2L2UZuc8FM-Jywx4khViG8LpGdTadBx5f6udVXripfLpPcYVEDbR0_6nRKfFLa4hV2efzTY47DpAJ4eFnw5cPZLchnr_CxoWmW0UGKqpsE"}
            """;
    }

    sealed class TestModelValidator : IModelValidator
    {
        bool IModelValidator.Validate(object model, [NotNullWhen(false)] out string? errorMessage, params Type[] ignores)
        {
            errorMessage = null;
            return true;
        }
    }

    sealed class AuthHelper : IAuthHelper
    {
        ValueTask<JWTEntity?> IAuthHelper.GetAuthTokenAsync() => new(AuthToken);

        Task IAuthHelper.SignOutAsync() => Task.CompletedTask;

        public ValueTask<JWTEntity?> GetShopAuthTokenAsync()
        {
            return new((JWTEntity?)null);
        }

        internal static JWTEntity? AuthToken;
    }

    sealed class MicroServiceClient : MicroServiceClientBase
    {
        public MicroServiceClient(
            ILogger<MicroServiceClient> logger,
            ILoggerFactory loggerFactory,
            System.Net.Http.Client.IHttpClientFactory clientFactory,
            IHttpPlatformHelperService http_helper,
            IToast toast,
            IAuthHelper authHelper,
            IMicroServiceClient.ISettings settings,
            IModelValidator validator,
            IApplicationVersionService applicationVersionService) : base(logger, loggerFactory,
                clientFactory, http_helper, toast,
                authHelper, settings, validator,
                applicationVersionService)
        {
        }

        protected override HttpClient CreateClient(HttpHandlerCategory category)
        {
            var client = base.CreateClient(category);
            try
            {
                client.Timeout = TimeSpan.MaxValue;
            }
            catch
            {

            }
            return client;
        }

        public override async Task OnLoginedAsync(IReadOnlyPhoneNumber? phoneNumber, ILoginResponse response)
        {
            await SaveAuthTokenAsync(response.AuthToken);
            await base.OnLoginedAsync(phoneNumber, response);
        }

        public override Task SaveAuthTokenAsync(JWTEntity? authToken)
        {
            AuthHelper.AuthToken = authToken;
            return Task.CompletedTask;
        }
    }
}