using static BD.WTTS.Services.IMicroServiceClient;

namespace BD.WTTS.Services.Implementation;

partial class MicroServiceClientBase :
    INoticeClient,
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
    IGameLibaryClient
{
    #region BasicServices - 基础服务

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

    public IVersionClient Version => this;

    #endregion

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

    #endregion

    #region Identity - 账号服务

    public IAccountClient Account => this;

    public virtual async Task<IApiRsp<LoginOrRegisterResponse?>> LoginOrRegister(
        LoginOrRegisterRequest request)
    {
        var r = await Conn.SendAsync<LoginOrRegisterRequest, LoginOrRegisterResponse>(
              isAnonymous: true,
              isSecurity: true,
              method: HttpMethod.Post,
              requestUri: "identity/account/loginorregister",
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
                requestUri: "identity/manage/refreshuserinfo",
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

    #endregion

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
               isAnonymous: true,
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

    public async Task<IApiRsp<ScriptInfoDTO?>> GM(string? errorAppendText = null)
    {
        var r = await Conn.SendAsync<ScriptInfoDTO>(
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

    #endregion

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

    #endregion

    #region Authenticator - 云令牌业务

    public IAuthenticatorClient AuthenticatorClient => this;

    //public virtual async Task<IApiRsp<List<UserAuthenticatorResponse>?>> Table()
    //{
    //    var apiUrl = $"authenticator/v3/userauth";
    //    var r = await Conn.SendAsync<List<UserAuthenticatorResponse>>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: false,
    //            method: HttpMethod.Get,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<List<UserAuthenticatorTokenResponse>?>> AuthToken(IEnumerable<Guid> ids)
    //{
    //    var apiUrl = $"authenticator/v3/userauth/ids";
    //    var r = await Conn.SendAsync<IEnumerable<Guid>, List<UserAuthenticatorTokenResponse>>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: ids,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> Add(IEnumerable<UserAuthenticatorRequest> list)
    //{
    //    var apiUrl = $"authenticator/v3/userauth/list";
    //    var r = await Conn.SendAsync<IEnumerable<UserAuthenticatorRequest>, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: list,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> Delete(Guid id)
    //{
    //    var apiUrl = $"authenticator/v3/userauth/{id}";
    //    var r = await Conn.SendAsync<bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: false,
    //            method: HttpMethod.Delete,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> SyncToken(IEnumerable<UserAuthenticatorSyncTokenRequest> list)
    //{
    //    var apiUrl = $"authenticator/v3/userauth";
    //    var r = await Conn.SendAsync<IEnumerable<UserAuthenticatorSyncTokenRequest>, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Put,
    //            request: list,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> AddSeparatePwd(UserAuthenticatorIndependentPasswordRequest pwdRequest)
    //{
    //    var apiUrl = $"authenticator/v3/separatepwd";
    //    var r = await Conn.SendAsync<UserAuthenticatorIndependentPasswordRequest, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: pwdRequest,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> SeparatePwdVerify(string separatePwd)
    //{
    //    var apiUrl = $"authenticator/v3/separatepwd/verify";
    //    var r = await Conn.SendAsync<string, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: separatePwd,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<string?>> GetSeparatePwdQuestion()
    //{
    //    var apiUrl = $"authenticator/v3/separatepwd";
    //    var r = await Conn.SendAsync<string>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: false,
    //            method: HttpMethod.Get,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> SeparatePwdQuestionVerify(string answer)
    //{
    //    var apiUrl = $"authenticator/v3/separatepwd/questionVerify";
    //    var r = await Conn.SendAsync<string, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: answer,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    //public virtual async Task<IApiRsp<bool>> SeparatePwdReset(string separatePwd)
    //{
    //    var apiUrl = $"authenticator/v3/separatepwd/questionVerify/reset";
    //    var r = await Conn.SendAsync<string, bool>(
    //            isPolly: true,
    //            isAnonymous: true,
    //            isSecurity: true,
    //            method: HttpMethod.Post,
    //            request: separatePwd,
    //            requestUri: apiUrl,
    //            cancellationToken: default);
    //    return r;
    //}

    #endregion

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

    #endregion

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

    #endregion
}