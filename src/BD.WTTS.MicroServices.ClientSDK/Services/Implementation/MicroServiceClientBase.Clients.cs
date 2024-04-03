using static BD.WTTS.Services.IMicroServiceClient;

namespace BD.WTTS.Services.Implementation;

partial class MicroServiceClientBase :
    INoticeClient,
    IMessageClient,
    IVersionClient,
    IActiveUserClient,
    IAccountClient,
    IManageClient,
    IAuthMessageClient,
    IAccelerateClient,
    IScriptClient,
    IAdvertisementClient,
    IAuthenticatorClient,
    ISponsorClient,
    IGameLibaryClient,
    IArticleClient,
    IShopClient
{
    #region BasicServices - 基础服务

    public IArticleClient Article => this;

    public async Task<IApiRsp<PagedModel<ArticleItemDTO>?>> Order(
            Guid? categoryId,
            ArticleOrderBy orderBy = ArticleOrderBy.DateTime,
            int current = IPagedModel.DefaultCurrent,
            int pageSize = IPagedModel.DefaultPageSize)
    {
        var url = $"basic/article/order/{(int)orderBy}/{current}/{pageSize}{(categoryId.HasValue ? $"/{categoryId}" : "")}";
        var r = await Conn.SendAsync<PagedModel<ArticleItemDTO>?>(
            isAnonymous: true,
            method: HttpMethod.Get,
            requestUri: url,
            cancellationToken: default,
            responseContentMaybeNull: true);
        return r;
    }

    public INoticeClient Notice => this;

    public async Task<IApiRsp<AppVersionDTO?>> CheckUpdate(
            Platform platform,
            DeviceIdiom deviceIdiom,
            Version osVersion,
            Architecture architecture,
            DeploymentMode deploymentMode)
    {
        var url = $"basic/versions/{(int)platform}/{(int)deviceIdiom}/{(int)architecture}/{osVersion.Major}/{osVersion.Minor}/{osVersion.Build}/{(int)deploymentMode}";
        var r = await Conn.SendAsync<AppVersionDTO?>(
            isAnonymous: true,
            method: HttpMethod.Get,
            requestUri: url,
            cancellationToken: default,
            responseContentMaybeNull: true);
        return r;
    }

    public async Task<IApiRsp> SubmitAppVersion(AppVerSubmissionRequest request)
    {
        var url = $"basic/versions/submitappversion";
        var r = await Conn.SendAsync(
            isAnonymous: false, // 使用 PublishToken 授权
            method: HttpMethod.Post,
            requestUri: url,
            request: request,
            cancellationToken: default);
        return r;
    }

    public IVersionClient Version => this;

    public IMessageClient Message => this;

    public async Task<IApiRsp<PagedModel<OfficialMessageItemDTO>>> GetMessage(
        ClientPlatform? clientPlatform,
        OfficialMessageType? messageType,
        int current = 1,
        int pageSize = 10)
    {
        var apiUrl = $"basic/officialmessage/message";
        var r = await Conn.SendAsync<PagedModel<OfficialMessageItemDTO>>(
                method: HttpMethod.Get,
                requestUri: apiUrl,
                isPolly: true,
                isAnonymous: true,
                cancellationToken: default);
        return r;
    }

    #endregion BasicServices - 基础服务

    #region BigDataAnalysis - 大数据分析

    public async Task<IApiRsp> Record(ActiveUserRecordDTO request)
    {
        var r = await Conn.SendAsync(
                isAnonymous: true, // 仅匿名收集
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: $"bigdataanalysis/activeusers",
                request: request,
                cancellationToken: default);
        return r;
    }

    public IActiveUserClient ActiveUser => this;

    #endregion BigDataAnalysis - 大数据分析

    #region Identity - 账号服务

    public IAccountClient Account => this;

    public virtual async Task<IApiRsp<LoginOrRegisterResponse?>> LoginOrRegister(
        LoginOrRegisterRequest request)
    {
        var r = await Conn.SendAsync<LoginOrRegisterRequest, LoginOrRegisterResponse>(
              isAnonymous: true,
              isSecurity: true,
              method: HttpMethod.Post,
              requestUri: "identity/v1/account/loginorregister",
              request: request,
              cancellationToken: default,
              responseContentMaybeNull: false);
        return r;
    }

    public virtual async Task<IApiRsp<JWTEntity?>> RefreshToken(string refresh_token)
    {
        var r = await Conn.SendAsync<RefreshTokenRequest, JWTEntity>(
                isAnonymous: true, // 刷新 Token 必须匿名身份，否则将在客户端上递归导致死循环
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/account/refreshtoken",
                request: new()
                {
                    RefreshToken = refresh_token,
                },
                cancellationToken: default,
                responseContentMaybeNull: true);
        return r;
    }

    public async Task<IApiRsp<string?>> GenerateServerSideProxyToken(GenerateServerSideProxyTokenRequest request)
    {
        var r = await Conn.SendAsync<GenerateServerSideProxyTokenRequest, string>(
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/v1/account/serversideproxytoken",
                request: request,
                cancellationToken: default,
                responseContentMaybeNull: false
            );

        return r;
    }

    public IManageClient Manage => this;

    public virtual async Task<IApiRsp<string?>> ChangeBindPhoneNumber(
      ChangePhoneNumberValidationRequest request)
    {
        var r = await Conn.SendAsync<ChangePhoneNumberValidationRequest, string>(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/manage/changebindphonenumber",
                request: request,
                cancellationToken: default,
                responseContentMaybeNull: false);
        return r;
    }

    public virtual async Task<IApiRsp> ChangeBindPhoneNumber(
        ChangePhoneNumberNewRequest request)
    {
        var r = await Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Put,
                requestUri: "identity/manage/changebindphonenumber",
                request: request,
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp> DeleteAccount()
    {
        var r = await Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Delete,
                requestUri: "identity/manage/deleteaccount",
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp<ClockInResponse?>> ClockIn()
    {
        var r = await Conn.SendAsync<ClockInRequest, ClockInResponse>(
                  isAnonymous: false,
                  isSecurity: true,
                  method: HttpMethod.Post,
                  requestUri: "identity/manage/clockin",
                  request: new ClockInRequest
                  {
                      CreationTime = DateTimeOffset.Now,
                  },
                  cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp<IEnumerable<DateTimeOffset>?>> ClockInRecords(DateTimeOffset? time)
    {
        var r = await Conn.SendAsync<IEnumerable<DateTimeOffset>>(
              isAnonymous: false,
              isSecurity: true,
              method: HttpMethod.Get,
              requestUri: $"identity/manage/clockinrecords?time={(time.HasValue ? time : DateTimeOffset.Now)}",
              cancellationToken: default,
              responseContentMaybeNull: false);
        return r;
    }

    public virtual async Task<IApiRsp> EditUserProfile(
        EditUserProfileRequest request)
    {
        var errorMessage = request.GetErrorMessage();
        if (errorMessage != null)
            return ApiRspHelper.Fail(errorMessage);

        var r = await Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/manage/edituserprofile",
                request: request,
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp> SignOut()
    {
        var r = await Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Get,
                requestUri: "identity/manage/signout",
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp> BindPhoneNumber(
        BindPhoneNumberRequest request)
    {
        var r = await Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/manage/bindphonenumber",
                request: request,
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp> UnbundleAccount(
        ExternalLoginChannel channel)
    {
        var r = await Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Delete,
                requestUri: $"identity/manage/unbundleaccount/{(int)channel}",
                cancellationToken: default);
        return r;
    }

    public virtual async Task<IApiRsp<IdentityUserInfoDTO?>> RefreshUserInfo()
    {
        var r = await Conn.SendAsync<IdentityUserInfoDTO>(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Get,
                requestUri: "identity/v1/manage/refreshuserinfo",
                cancellationToken: default);
        return r;
    }

    public IAuthMessageClient AuthMessage => this;

    protected async Task<IApiRsp> SendSmsCore(SendSmsRequest request)
    {
        var r = await Conn.SendAsync(
                isAnonymous: false, // 发送短信验证码某些类型需要身份验证，某些则不要
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "identity/vcodes/sms",
                request: request,
                cancellationToken: default);
        return r;
    }

    protected readonly IDictionary<string, DateTime> send_sms_pairs = AuthMessageClientHelper.Create();

    public virtual async ValueTask<IApiRsp> SendSms(SendSmsRequest request)
    {
        var r = await AuthMessageClientHelper.SendSms(send_sms_pairs, request, SendSmsCore);
        return r;
    }

    #endregion Identity - 账号服务

    #region Accelerator - 加速与脚本业务

    public async Task<IApiRsp<List<AccelerateProjectGroupDTO>?>> All()
    {
        var r = await Conn.SendAsync<GetAccelerateProjectGroupRequest, List<AccelerateProjectGroupDTO>>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "accelerator/projectgroups",
               request: new(),
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<ScriptInfoDTO?>> GM()
    {
        var r = await Conn.SendAsync<ScriptInfoDTO>(
               isPolly: true,
               isAnonymous: true,
               isSecurity: false,
               method: HttpMethod.Get,
               requestUri: "accelerator/scripts/gm",
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<PagedModel<ScriptDTO>?>> Query(
        string? name = null,
        int current = 1,
        int pageSize = 15,
        string? errorAppendText = null)
    {
        var r = await Conn.SendAsync<PagedModel<ScriptDTO>>(
               isPolly: true,
               isSecurity: false,
               method: HttpMethod.Get,
               requestUri: $"accelerator/scripts/{current}/{pageSize}/{name}",
               errorAppendText: errorAppendText,
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<List<ScriptInfoDTO>?>> GetInfoByIds(
        string? errorAppendText = null,
        IEnumerable<Guid>? ids = null)
    {
        if (!ids.Any_Nullable()) // 客户端优化
            return ApiRspHelper.Ok(new List<ScriptInfoDTO>());

        var r = await Conn.SendAsync<IEnumerable<Guid>, List<ScriptInfoDTO>>(
               isPolly: true,
               isAnonymous: true,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "accelerator/scripts",
               request: ids,
               errorAppendText: errorAppendText,
               cancellationToken: default)!;
        return r;
    }

    public IAccelerateClient Accelerate => this;

    public async Task<IApiRsp<ScriptDTO?>> GM(string? errorAppendText = null)
    {
        var r = await Conn.SendAsync<ScriptDTO>(
               isPolly: true,
               isAnonymous: true,
               isSecurity: false,
               method: HttpMethod.Get,
               requestUri: "accelerator/scripts/gm",
               errorAppendText: errorAppendText,
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<PagedModel<ScriptEvaluationDTO>?>> QueryScriptEvaluations(
        int current,
        int pageSize,
        Guid? scriptId,
        Guid? userId,
        bool? visiblitiy)
    {
        var r = await Conn.SendAsync<PagedModel<ScriptEvaluationDTO>>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Get,
               requestUri: $"accelerator/scriptevaluations/{current}/{pageSize}?scriptId={scriptId}",
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<PagedModel<ScriptEvaluationDTO>?>> QueryProfileScriptEvaluations(
        int current,
        int pageSize,
        Guid? userId,
        bool? visiblitiy)
    {
        var r = await Conn.SendAsync<PagedModel<ScriptEvaluationDTO>>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Get,
               requestUri: $"accelerator/scriptevaluations/{current}/{pageSize}?userId={userId}&visiblitiy={visiblitiy}",
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<string?>> GetMyIP(bool ipV4 = false, bool ipV6 = false)
    {
        //var r = await Conn.SendAsync<string?>(
        //       isPolly: true,
        //       isAnonymous: true,
        //       isSecurity: false,
        //       method: HttpMethod.Get,
        //       requestUri: $"accelerator/projectgroups/myip?ipv4={ipV4}&ipv6={ipV6}",
        //       responseContentMaybeNull: true,
        //       cancellationToken: default)!;
        //return r;

        try
        {
            string url;
            if (ipV4)
            {
                url = "https://v4.ipip.net";
            }
            else if (ipV6)
            {
                url = "https://v6.ipip.net";
            }
            else
            {
                return ApiRspHelper.Ok((string?)null);
            }
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(7.75d);
            var r = (await client.GetStringAsync(url, cancellationToken: default))?.Trim();
            if (IPAddress.TryParse(r, out var _))
                return ApiRspHelper.Ok(r);
        }
        catch
        {
        }
        return ApiRspHelper.Ok((string?)null);
    }

    public async Task<IApiRsp<bool>> ScriptEvaluationAddorUpdate(AddOrUpdateEvaluationRequest addOrUpdateEvaluationRequest)
    {
        var r = await Conn.SendAsync<AddOrUpdateEvaluationRequest, bool>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "accelerator/scriptevaluations",
               request: addOrUpdateEvaluationRequest,
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<bool>> Judge(JudgeEvaluationRequest judgeEvaluationRequest)
    {
        var r = await Conn.SendAsync<JudgeEvaluationRequest, bool>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "accelerator/scriptevaluations/judge",
               request: judgeEvaluationRequest,
               cancellationToken: default)!;
        return r;
    }

    public async Task<IApiRsp<bool>> DeleteScriptEvaluation(Guid? id)
    {
        var r = await Conn.SendAsync<bool>(
                isAnonymous: false,
                method: HttpMethod.Delete,
                requestUri: $"accelerator/scriptevaluations/{id}",
                cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp<bool>> SetVisibility(Guid? id, Visibility? visibility)
    {
        var r = await Conn.SendAsync<bool>(
                isAnonymous: false,
                method: HttpMethod.Post,
                requestUri: $"accelerator/scriptevaluations/setvisibility/{id}?visibility={visibility}",
                cancellationToken: default);
        return r;
    }

    public IScriptClient Script => this;

    #endregion Accelerator - 加速与脚本业务

    #region Advertisement - 广告业务

    public async Task<IApiRsp<List<AdvertisementDTO>?>> All(AdvertisementType type)
    {
        var r = await Conn.SendAsync<GetAccelerateProjectGroupRequest, List<AdvertisementDTO>>(
               isPolly: true,
               isAnonymous: false,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "accelerator/projectgroups", // 广告与加速项目组使用同一个 Url
               request: new()
               {
                   ADType = type,
                   Version = 1,
               },
               cancellationToken: default)!;
        return r;
    }

    public IAdvertisementClient Advertisement => this;

    #endregion Advertisement - 广告业务

    #region Authenticator - 云令牌业务

    public IAuthenticatorClient AuthenticatorClient => this;

    public async Task<IApiRsp<UserAuthenticatorResponse[]?>> GetAuthenticators()
    {
        var apiUrl = $"authenticator/authenticators";
        var r = await Conn.SendAsync<UserAuthenticatorResponse[]>(
                method: HttpMethod.Get,
                requestUri: apiUrl,
                isPolly: true,
                isSecurity: true,
                cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp<UserAuthenticatorPushResponse?>> SyncAuthenticatorsToCloud(UserAuthenticatorPushRequest request)
    {
        var apiUrl = $"authenticator/authenticators/synctocloud";
        var r = await Conn.SendAsync<UserAuthenticatorPushRequest, UserAuthenticatorPushResponse>(
            method: HttpMethod.Post,
            requestUri: apiUrl,
            request: request,
            isSecurity: true,
            cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp> SetIndependentPassword(UserAuthenticatorIndependentPasswordSetRequest request)
    {
        var apiUrl = $"/authenticator/independentpasswords";
        var r = await Conn.SendAsync(
            method: HttpMethod.Post,
            requestUri: apiUrl,
            request: request,
            isSecurity: true,
            cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp> ResetIndependentPassword(UserAuthenticatorIndependentPasswordResetRequest request)
    {
        var apiUrl = $"authenticator/independentpasswords";
        var r = await Conn.SendAsync(
            method: HttpMethod.Put,
            requestUri: apiUrl,
            request: request,
            isSecurity: true,
            cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp<bool>> VerifyIndependentPassword(UserAuthenticatorIndependentPasswordVerifyRequest request)
    {
        var apiUrl = $"authenticator/independentpasswords/verify";
        var r = await Conn.SendAsync<UserAuthenticatorIndependentPasswordVerifyRequest, bool>(
            method: HttpMethod.Post,
            requestUri: apiUrl,
            request: request,
            isSecurity: true,
            cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp<string?>> GetIndependentPasswordQuestion()
    {
        var apiUrl = $"authenticator/independentpasswords/getquestion";
        var r = await Conn.SendAsync<string?>(
                method: HttpMethod.Get,
                requestUri: apiUrl,
                isPolly: true,
                isSecurity: true,
                cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp<UserAuthenticatorDeleteBackupResponse[]?>> GetAuthenticatorDeleteBackups()
    {
        var apiUrl = $"authenticator/deletebackups";
        var r = await Conn.SendAsync<UserAuthenticatorDeleteBackupResponse[]?>(
                method: HttpMethod.Get,
                requestUri: apiUrl,
                isPolly: true,
                isSecurity: true,
                cancellationToken: default);
        return r;
    }

    public async Task<IApiRsp> RecoverAuthenticatorsFromDeleteBackups(UserAuthenticatorDeleteBackupRecoverRequest request)
    {
        var apiUrl = $"authenticator/deletebackups/recover";
        var r = await Conn.SendAsync(
            method: HttpMethod.Post,
            requestUri: apiUrl,
            request: request,
            isSecurity: true,
            cancellationToken: default);
        return r;
    }

    #endregion Authenticator - 云令牌业务

    #region Sponsor - 外部赞助业务

    public async Task<IApiRsp<PagedModel<QueryRankRecordsResponse>?>> QueryRankRecords(
        PageQueryRequest<QueryRankRecordsRequest> request)
    {
        var r = await Conn.SendAsync<PageQueryRequest<QueryRankRecordsRequest>, PagedModel<QueryRankRecordsResponse>>(
               isPolly: true,
               isAnonymous: true,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "sponsor/rankrecords",
               request: request,
               cancellationToken: default)!;
        return r;
    }

    public ISponsorClient Sponsor => this;

    #endregion Sponsor - 外部赞助业务

    #region GameLibary - 游戏库存业务

    public async Task<IApiRsp> SyncUserAppInfo(SyncSteamUserAppInfoRequest request)
    {
        var r = await Conn.SendAsync<SyncSteamUserAppInfoRequest?>(
            method: HttpMethod.Post,
            requestUri: "gamelibrary/sync",
            isAnonymous: true,
            isSecurity: false,
            request: request,
            cancellationToken: default)!;

        return r;
    }

    public async Task<IApiRsp<bool>> OwnedGamesExists(QuerySteamAppIdExistOwnedGamesRequest request)
    {
        var r = await Conn.SendAsync<QuerySteamAppIdExistOwnedGamesRequest?, bool>(
            method: HttpMethod.Post,
            requestUri: "gamelibrary/ownedgames/exists",
            isAnonymous: true,
            isSecurity: false,
            request: request,
            cancellationToken: default)!;

        return r;
    }

    public async Task<IApiRsp<bool>> WishListExist(QuerySteamAppIdExistsWishListRequest request)
    {
        var r = await Conn.SendAsync<QuerySteamAppIdExistsWishListRequest?, bool>(
            method: HttpMethod.Post,
            requestUri: "gamelibrary/steamwishlist/exists",
            isAnonymous: true,
            isSecurity: false,
            request: request,
            cancellationToken: default)!;

        return r;
    }

    public IGameLibaryClient GameLibary => this;

    #endregion GameLibary - 游戏库存业务

    #region Shop 商城接口

    public async Task<IApiRsp<JWTEntity?>> GetShopUserTokenAsync()
    {
        var r = await Conn.GetShopUserTokenAsync(cancellationToken: default)!;
        return r!; // IApiRsp.IsSuccess 为 true 时，Content 必定不为 null，由 responseContentMaybeNull = false 控制该行为
    }

    public async Task<IApiRsp<ShopRecommendGoodItem[]>> RecommendGoods(int id)
    {
        var r = await Conn.SendShopAsync<ShopBaseRequest, ShopRecommendGoodItem[]?>(
            method: HttpMethod.Post,
            isAnonymous: true,
            requestUri: $"https://{Constants.Urls.OfficialShopApiHostName}/api/Good/GetGoodsRecommendList",
            request: new ShopBaseRequest
            {
                Id = id,
                Data = true,
            },
            cancellationToken: default)!;
        return r!; // IApiRsp.IsSuccess 为 true 时，Content 必定不为 null，由 responseContentMaybeNull = false 控制该行为
    }

    public IShopClient Shop => this;

    #endregion Shop 商城接口
}