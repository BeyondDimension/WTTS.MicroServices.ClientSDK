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
            {"v":"AQAB","n":"oUVTEIm_rXHJcI70OAPoj74quANUU8SJ5qXyyw7syIp9VymnyDAC8MTER2XdMwrq5Yefcrk5oyiLP4N3uRGotda3-AJw-uaWWfOUD3AJo7zjQJJiellgc5Z9MwC3g_nfSEvM63H0dWnBfsNTkCm3CIMsuTdTEPRkXIHnerm6FXqo2jkBoBrJBa4YKc1RbTh4JOtCWw2Sqhc1offwFSZp46zJpPSDEMhiF61pfRky18QA0zxAAxuhyamshATO_rF-MwJjHvDo8d4Ynpe0LeZe_Etr3h6RboDgRflg4i0qi_G_l0FMDxPeDEN9O26ROwhZ3nr7DxoWVDx-5AoZ591hYw"}
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