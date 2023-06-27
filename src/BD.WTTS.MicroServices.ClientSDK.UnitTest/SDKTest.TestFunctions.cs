namespace BD.WTTS.MicroServices.ClientSDK.UnitTest;

partial class SDKTest
{
    [SetUp]
    public void Setup()
    {
        localhost = false;
    }

    /// <summary>
    /// 对 SDK 中的所有接口进行测试
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task TestSDK()
    {
        if (ProjectUtils.IsCI()) return;

        foreach (var implType in new[] {
            Serializable.ImplType.MessagePack,
            Serializable.ImplType.SystemTextJson,
            Serializable.ImplType.MemoryPack,
        })
        {
            #region host

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

            #endregion

            #region Identity - 账号服务

            tel = string.Concat("176", Random2.GenerateRandomString(8, String2.Digits));

            var ssRsp = await client.AuthMessage.SendSms(new() { PhoneNumber = tel, Type = SmsCodeType.LoginOrRegister });
            Assert.That(ssRsp.Code, Is.EqualTo(ApiRspCode.OK));

            //MemoryPack 405
            var lrRsp = await client.Account.LoginOrRegister_Compat(new() { PhoneNumber = tel, SmsCode = "666666" });

            Assert.That(lrRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var cRsp = await client.Manage.ClockIn_Compat();
            Assert.That(cRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var eupRsp = await client.Manage.EditUserProfile_Compat(new()
            {
                NickName = Random2.GenerateRandomString(),
                Avatar = null,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                BirthDateTimeZone = 0,
                AreaId = null,
            });
            Assert.That(eupRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var cbpSsRsp = await client.AuthMessage.SendSms(new() { PhoneNumber = PhoneNumberHelper.SimulatorDefaultValue, Type = SmsCodeType.ChangePhoneNumberValidation });
            Assert.That(cbpSsRsp.Code, Is.EqualTo(ApiRspCode.OK));

            string newtel = string.Concat("186", Random2.GenerateRandomString(8, String2.Digits));
            var cbpRsp = await client.Manage.ChangeBindPhoneNumber_Compat(new ChangePhoneNumberValidationRequest()
            {
                SmsCode = "666666",
                PhoneNumber = newtel,
            });
            Assert.That(cbpRsp.Code, Is.EqualTo(ApiRspCode.OK));
            Assert.That(cbpRsp.Content, Is.Not.Null);

            var cbpSsauRspT = await client.AuthMessage.SendSms(new() { PhoneNumber = newtel, Type = SmsCodeType.ChangePhoneNumberNew });
            Assert.That(cbpSsauRspT.Code, Is.EqualTo(ApiRspCode.OK));
            var cbpRspT = await client.Manage.ChangeBindPhoneNumber_Compat(new ChangePhoneNumberNewRequest()
            {
                PhoneNumber = newtel,
                SmsCode = "666666",
                Code = cbpRsp.Content,
            });
            Assert.That(cbpRspT.Code, Is.EqualTo(ApiRspCode.OK));

            //[未测试]
            //var bpnRsp = await client.Manage.BindPhoneNumber(new()
            //{
            //    SmsCode = "666666",
            //    PhoneNumber = "",
            //});
            //Assert.True(bpnRsp.Code == ApiRspCode.OK);

            //[未测试]
            //var rsp = await client.Manage.ClockInLogs(DateTimeOffset.Now);
            //Assert.True(rsp.Code == ApiRspCode.OK);

            #endregion

            #region BasicServices - 基础服务

            var ntRsp = await client.Notice.Types_Compat();
            Assert.That(ntRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var ntbRsp = await client.Notice.Table_Compat(Guid.NewGuid(), 1, 10);
            Assert.That(ntbRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var nmRsp = await client.Notice.NewMsg_Compat(null, DateTimeOffset.Now);
            Assert.That(nmRsp.Code, Is.EqualTo(ApiRspCode.OK));

            Version version = new(10, 1, 14393);
            var cuRsp = await client.Version.CheckUpdate2_Compat(
                Guid.Parse(AppVerId),
                Platform.Windows,
                DeviceIdiom.Desktop,
                version,
                Architecture.X64,
                DeploymentMode.FDE);
            Assert.That(cuRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            #region BigDataAnalysis - 大数据分析

            ActiveUserRecordDTOCompat pReq = new()
            {
                Type = ActiveUserAnonymousStatisticType.OnStartup,
                Platform = Platform.Windows,
                DeviceIdiom = DeviceIdiom.Desktop,
                ProcessArch = ArchitectureFlags.X64,
                OSVersion = "10.0.22621.0",
                ScreenCount = 2,
                PrimaryScreenPixelDensity = 1,
                PrimaryScreenWidth = 1920,
                PrimaryScreenHeight = 1080,
                SumScreenWidth = 3840,
                SumScreenHeight = 2160,
                IsAuthenticated = false,
                DeviceIdG = Guid.NewGuid(),
                DeviceIdN = "410B773537608400954B2EBB90123456D4FCE70A27EC66CDFF57B569C3123456",
                DeviceIdR = "AFA27aY",
            };
            Assert.IsTrue(pReq.HasValue());
            var pRsp = await client.ActiveUser.Post_Compat(pReq);
            Assert.That(pRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            #region Accelerator - 加速与脚本业务

            var allRsp = await client.Accelerate.All_Compat(ReverseProxyEngine.Yarp);
            Assert.That(allRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var bRsp = await client.Script.Basics_Compat("");
            Assert.That(bRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var stRsp = await client.Script.ScriptTable_Compat("", 1, 15, null);
            Assert.That(stRsp.Code, Is.EqualTo(ApiRspCode.OK));

            List<Guid> guids = new()
            {
                Guid.NewGuid(),
            };
            var suiRsp = await client.Script.ScriptUpdateInfo_Compat(guids, "");
            Assert.That(suiRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            #region Advertisement - 广告业务

            var gallRsp = await client.Advertisement.All_Compat(AdvertisementType.Banner);
            Assert.That(gallRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            #region Sponsor - 外部赞助业务

            //SystemTextJson 500
            PageQueryRequest<RankingRequestCompat> page = new PageQueryRequest<RankingRequestCompat>
            {
                Current = 1,
                PageSize = 10,
                Params = new()
                {
                    Type = SponsorPlatformType.Afdian,
                    TimeRange = new DateTimeOffset[] { DateTimeOffset.Now.GetCurrentMonth(), DateTimeOffset.Now },
                },
            };
            var dqRsp = await client.Sponsor.RangeQuery_Compat(page);
            Assert.That(dqRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            #region Identity - 账号服务-退出

            var uaRsp = await client.Manage.UnbundleAccount_Compat(ExternalLoginChannel.Apple);
            Assert.That(uaRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var rtRsp = await client.Account.RefreshToken(AuthHelper.AuthToken?.RefreshToken ?? "");
            Assert.That(rtRsp.Code, Is.EqualTo(ApiRspCode.Unauthorized));

            var ruiRsp = await client.Manage.RefreshUserInfo_Compat();
            Assert.That(ruiRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var delARsp = await client.Manage.DeleteAccount_Compat();
            Assert.That(delARsp.Code, Is.EqualTo(ApiRspCode.OK));

            tel = string.Concat("176", Random2.GenerateRandomString(8, String2.Digits));
            var outssRsp = await client.AuthMessage.SendSms(new() { PhoneNumber = tel, Type = SmsCodeType.LoginOrRegister });
            Assert.That(outssRsp.Code, Is.EqualTo(ApiRspCode.OK));
            var outlrRsp = await client.Account.LoginOrRegister_Compat(new() { PhoneNumber = tel, SmsCode = "666666" });

            Assert.That(outlrRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var sorsp = await client.Manage.SignOut_Compat();
            Assert.That(sorsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion

            // 下次循环之前清空登录状态
            AuthHelper.AuthToken = null;
        }
    }

    /// <summary>
    /// 仅测试【库存游戏】部分的接口
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task TeskGameLibary()
    {
        if (ProjectUtils.IsCI()) return;

        await OnTestEnv(async (host, client) =>
        {
            #region GameLibary - 游戏库存服务

            var syncUserAppInfoRsp = await client.GameLibary.SyncUserAppInfo(new SyncSteamUserAppInfoRequest(Random.Shared.Next(1, 9999999)));
            //var syncUserAppInfoRsp = await client.GameLibary.SyncUserAppInfo(new SyncSteamUserAppInfoRequest(76561198179379306));

            Assert.That(syncUserAppInfoRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var useOwnedGamesExistRsp = await client.GameLibary.OwnedGamesExists(new QuerySteamAppIdExistOwnedGamesRequest(1, 2));

            Assert.That(useOwnedGamesExistRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var wishListExistRsp = await client.GameLibary.WishListExist(new QuerySteamAppIdExistsWishListRequest(1, 2));

            Assert.That(wishListExistRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion
        });
    }

    /// <summary>
    /// 测试【脚本评价】部分的接口
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task TestScriptEvaluation()
    {
        if (ProjectUtils.IsCI()) return;

        #region Auth
        var jWTEntity = new JWTEntity()
        {
            AccessToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTM4NCIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1Sm5adi1tcHpVeVFjSF82cEJFWjZnIiwiaWF0IjoxNjg3Njc1NTA4OTY3LCJuYmYiOjE2ODc2NDY3MDgsImV4cCI6MTY5MDMyNTEwOCwiaXNzIjoiQ2xvdWRTZXJ2aWNlIiwiYXVkIjoiU3RlYW1Ub29scy5DbGllbnQifQ.5Njp-lV-FNFCVHuWlBr-frsG-HY3R3VO7yFBmWiY8k4CPyt6nmFgonqdpHStl5vK",
            RefreshToken = "AQAAAAEAACcQAAAAIIV3pRxfP8w1OFHoX6erJp8DLmOnWBD0AyIe5VW_0U19fmWEsizryebpzRBzE0us8_HZ6NVvpg58JG6-vEvk9Ec",
            ExpiresIn = new DateTimeOffset(DateTime.Now.AddYears(1))
        };
        AuthHelper.AuthToken = jWTEntity;
        #endregion

        foreach (var implType in new[] {
            Serializable.ImplType.MessagePack,
            Serializable.ImplType.SystemTextJson,
            Serializable.ImplType.MemoryPack,
        })
        {

            #region Host
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
            #endregion

            var scriptId = Guid.Parse("91bcbf3e-f36b-1410-8745-00bf2430ffa9");
            var userId = Guid.Parse("7068106b-fad0-409f-878b-91397c1d084b");

            // ScriptEvaluationAddorUpdate
            var scriptEvaluationAddorUpdateRsp = await client.Script.ScriptEvaluationAddorUpdate(new AddOrUpdateEvaluationRequest
            {
                ScriptId = scriptId,
                Content = "amazing script",
                Visibility = Visibility.公开,
                Rate = 9
            });

            Assert.That(scriptEvaluationAddorUpdateRsp.Code, Is.EqualTo(ApiRspCode.OK));

            // QueryScriptEvaluations
            var queryScriptEvaluationsRsp = await client.Script.QueryScriptEvaluations(1, 10, scriptId, userId, null);

            Assert.That(queryScriptEvaluationsRsp.Code, Is.EqualTo(ApiRspCode.OK));

            // Judge
            var scriptEvaluationId = queryScriptEvaluationsRsp.Content.DataSource.Select(s => s.Id).FirstOrDefault();
            var judgeRsp = await client.Script.Judge(new JudgeEvaluationRequest
            {
                ScriptEvaluationId = scriptEvaluationId,
                JudgeType = ScriptEvaluationJudgeType.赞赏
            });

            Assert.That(judgeRsp.Code, Is.EqualTo(ApiRspCode.OK));

            // Delete
            var deleteRsp = await client.Script.DeleteScriptEvaluation(scriptEvaluationId);

            Assert.That(deleteRsp.Code, Is.EqualTo(ApiRspCode.OK));
        }
    }

    /// <summary>
    /// 测试【基础服务】部分的接口
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task TestSDKBasic()
    {
        if (ProjectUtils.IsCI()) return;

        foreach (var implType in new[] {
            Serializable.ImplType.MessagePack,
            Serializable.ImplType.SystemTextJson,
            Serializable.ImplType.MemoryPack,
        })
        {
            #region host

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

            #endregion

            #region BasicServices - 基础服务

            var ntRsp = await client.Notice.Types_Compat();
            Assert.That(ntRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var ntbRsp = await client.Notice.Table_Compat(Guid.NewGuid(), 1, 10);
            Assert.That(ntbRsp.Code, Is.EqualTo(ApiRspCode.OK));

            var nmRsp = await client.Notice.NewMsg_Compat(null, DateTimeOffset.Now);
            Assert.That(nmRsp.Code, Is.EqualTo(ApiRspCode.OK));

            Version version = new(10, 1, 14393);
            var cuRsp = await client.Version.CheckUpdate2_Compat(Guid.Parse(AppVerId),
                Platform.Windows,
                DeviceIdiom.Desktop,
                version,
                Architecture.X64,
                DeploymentMode.FDE);
            Assert.That(cuRsp.Code, Is.EqualTo(ApiRspCode.OK));

            #endregion
        }
    }
}
