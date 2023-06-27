namespace BD.WTTS.Services;

partial interface IMicroServiceClient
{
    #region BasicServices - 基础服务

    INoticeClient Notice { get; }

    interface INoticeClient
    {
    }

    IVersionClient Version { get; }

    interface IVersionClient
    {
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="deviceIdiom"></param>
        /// <param name="osVersion"></param>
        /// <param name="architecture"></param>
        /// <param name="deploymentMode"></param>
        /// <returns></returns>
        Task<IApiRsp<AppVersionDTO?>> CheckUpdate(
            Platform platform,
            DeviceIdiom deviceIdiom,
            Version osVersion,
            Architecture architecture,
            DeploymentMode deploymentMode);
    }

    #endregion

    #region BigDataAnalysis - 大数据分析

    IActiveUserClient ActiveUser { get; }

    interface IActiveUserClient
    {
        /// <summary>
        /// 记录活跃用户
        /// </summary>
        /// <param name="request">匿名收集数据</param>
        /// <returns></returns>
        Task<IApiRsp> Record(ActiveUserRecordDTO request);
    }

    #endregion

    #region Identity - 账号服务

    IAccountClient Account { get; }

    interface IAccountClient
    {
        /// <summary>
        /// 登录或注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp<LoginOrRegisterResponse?>> LoginOrRegister(
            LoginOrRegisterRequest request);

        /// <summary>
        /// 刷新 JWT
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        Task<IApiRsp<JWTEntity?>> RefreshToken(string refresh_token);

        /// <summary>
        /// 刷新 JWT
        /// </summary>
        /// <param name="jWT"></param>
        /// <returns></returns>
        Task<IApiRsp<JWTEntity?>> RefreshToken(JWTEntity jWT)
        {
            var refresh_token = jWT.RefreshToken;
            return RefreshToken(refresh_token.ThrowIsNull(nameof(refresh_token)));
        }
    }

    IManageClient Manage { get; }

    interface IManageClient
    {
        /// <summary>
        /// 换绑手机（安全验证）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp<string?>> ChangeBindPhoneNumber(
            ChangePhoneNumberValidationRequest request);

        /// <summary>
        /// 绑定新手机号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp> ChangeBindPhoneNumber(
            ChangePhoneNumberNewRequest request);

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp> DeleteAccount();

        /// <summary>
        /// 每日签到
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<ClockInResponse?>> ClockIn();

        /// <summary>
        /// 获取每日签到记录，用于 UI 上显示日历并且标记 ✅
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        Task<IApiRsp<IEnumerable<DateTimeOffset>?>> ClockInRecords(DateTimeOffset? time);

        /// <summary>
        /// 编辑个人资料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp> EditUserProfile(
            EditUserProfileRequest request);

        /// <summary>
        /// 登出，退出登录
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp> SignOut();

        /// <summary>
        /// 绑定手机号码(通过快速登录注册的账号需要此功能)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp> BindPhoneNumber(
            BindPhoneNumberRequest request);

        /// <summary>
        /// 解绑账号
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        Task<IApiRsp> UnbundleAccount(
            ExternalLoginChannel channel);

        /// <summary>
        /// 刷新用户信息
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<IdentityUserInfoDTO?>> RefreshUserInfo();
    }

    IAuthMessageClient AuthMessage { get; }

    interface IAuthMessageClient
    {
        ValueTask<IApiRsp> SendSms(SendSmsRequest request);
    }

    #endregion

    #region Accelerator - 加速与脚本业务

    IAccelerateClient Accelerate { get; }

    interface IAccelerateClient
    {
        /// <summary>
        /// 获取所有加速项目组数据
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<List<AccelerateProjectGroupDTO>?>> All();

        /// <summary>
        /// 获取 GM.js(基础依赖库) 脚本信息
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<ScriptInfoDTO?>> GM();

        /// <summary>
        /// 获取所有脚本数据
        /// </summary>
        /// <param name="current">当前页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="name">脚本名称</param>
        /// <param name="errorAppendText"></param>
        /// <returns></returns>
        Task<IApiRsp<PagedModel<ScriptDTO>?>> Query(
            string? name = null,
            int current = 1,
            int pageSize = 15,
            string? errorAppendText = null);

        /// <summary>
        /// 根据脚本主键获取脚本信息，可用于检查脚本更新
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="errorAppendText"></param>
        /// <returns></returns>
        Task<IApiRsp<List<ScriptInfoDTO>?>> GetInfoByIds(
            string? errorAppendText = null,
            IEnumerable<Guid>? ids = null);

        /// <inheritdoc cref="GetInfoByIds(string?, IEnumerable{Guid}?)"/>
        Task<IApiRsp<List<ScriptInfoDTO>?>> GetInfoByIds(
            string? errorAppendText = null, params Guid[] ids)
        {
            var ids_ = ids.AsEnumerable();
            return GetInfoByIds(errorAppendText, ids_);
        }
    }

    IScriptClient Script { get; }

    interface IScriptClient
    {
        /// <summary>
        /// 获取 GM.js(基础依赖库) 脚本信息
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<ScriptInfoDTO?>> GM(string? errorAppendText = null);

        /// <summary>
        /// 获取所有脚本数据
        /// </summary>
        /// <param name="current">当前页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="name">脚本名称</param>
        /// <param name="errorAppendText"></param>
        /// <returns></returns>
        Task<IApiRsp<PagedModel<ScriptDTO>?>> Query(
            string? name = null,
            int current = 1,
            int pageSize = 15,
            string? errorAppendText = null);

        /// <summary>
        /// 根据脚本主键获取脚本信息，可用于检查脚本更新
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="errorAppendText"></param>
        /// <returns></returns>
        Task<IApiRsp<List<ScriptInfoDTO>?>> GetInfoByIds(
            string? errorAppendText = null,
            IEnumerable<Guid>? ids = null);

        /// <inheritdoc cref="GetInfoByIds(string?, IEnumerable{Guid}?)"/>
        Task<IApiRsp<List<ScriptInfoDTO>?>> GetInfoByIds(
            string? errorAppendText = null, params Guid[] ids)
        {
            var ids_ = ids.AsEnumerable();
            return GetInfoByIds(errorAppendText, ids_);
        }

        /// <summary>
        /// 分页获取脚本评价
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<PagedModel<ScriptEvaluationDTO>?>> QueryScriptEvaluations(
            int current,
            int pageSize,
            Guid? scriptId,
            Guid? userId,
            bool? visiblitiy);

        /// <summary>
        /// 分页获取脚本评价
        /// </summary>
        /// <returns></returns>
        Task<IApiRsp<PagedModel<ScriptEvaluationDTO>?>> QueryProfileScriptEvaluations(
            int current,
            int pageSize,
            Guid? userId,
            bool? visiblitiy);

        /// <summary>
        /// 添加和修改脚本评价
        /// </summary>
        /// <param name="addOrUpdateEvaluationRequest"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> ScriptEvaluationAddorUpdate(AddOrUpdateEvaluationRequest addOrUpdateEvaluationRequest);

        /// <summary>
        /// 脚本评判操作 如为已赞赏，再次调用则为取消
        /// </summary>
        /// <param name="judgeEvaluationRequest"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> Judge(JudgeEvaluationRequest judgeEvaluationRequest);

        /// <summary>
        /// 用户设置评价可见性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> SetVisibility(Guid? id, Visibility? visibility);

        /// <summary>
        /// 删除脚本评价
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> DeleteScriptEvaluation(Guid? id);
    }

    #endregion

    #region Advertisement - 广告业务

    IAdvertisementClient Advertisement { get; }

    interface IAdvertisementClient
    {
        /// <summary>
        /// 根据广告类型获取所有广告数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<IApiRsp<List<AdvertisementDTO>?>> All(AdvertisementType type);
    }

    #endregion

    #region Authenticator - 云令牌业务

    IAuthenticatorClient AuthenticatorClient { get; }

    interface IAuthenticatorClient
    {
        ///// <summary>
        ///// 获取用户令牌DTO列表
        ///// </summary>
        ///// <returns></returns>
        //Task<IApiRsp<List<UserAuthenticatorResponse>?>> Table();

        ///// <summary>
        ///// 获取用户令牌信息
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //Task<IApiRsp<List<UserAuthenticatorTokenResponse>?>> AuthToken(IEnumerable<Guid> ids);

        ///// <summary>
        ///// 用户添加令牌
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> Add(IEnumerable<UserAuthenticatorRequest> list);

        ///// <summary>
        ///// 删除令牌
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> Delete(Guid id);

        ///// <summary>
        ///// 同步令牌
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> SyncToken(IEnumerable<UserAuthenticatorSyncTokenRequest> list);

        ///// <summary>
        ///// 添加用户独立密码
        ///// </summary>
        ///// <param name="pwdRequest"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> AddSeparatePwd(UserAuthenticatorIndependentPasswordRequest pwdRequest);

        ///// <summary>
        ///// 用户独立密码验证
        ///// </summary>
        ///// <param name="separatePwd"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> SeparatePwdVerify(string separatePwd);

        ///// <summary>
        ///// 获取用户独立密码密保问题
        ///// </summary>
        ///// <returns></returns>
        //Task<IApiRsp<string>> GetSeparatePwdQuestion();

        ///// <summary>
        ///// 用户独立密码密保问题验证
        ///// </summary>
        ///// <param name="separatePwd"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> SeparatePwdQuestionVerify(string separatePwd);

        ///// <summary>
        ///// 用户重置独立密码
        ///// </summary>
        ///// <param name="separatePwd"></param>
        ///// <returns></returns>
        //Task<IApiRsp<bool>> SeparatePwdReset(string separatePwd);

    }

    #endregion

    #region Sponsor - 外部赞助业务

    ISponsorClient Sponsor { get; }

    interface ISponsorClient
    {
        /// <summary>
        /// 获取赞助用户排行分页列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp<PagedModel<QueryRankRecordsResponse>?>> QueryRankRecords(
            PageQueryRequest<QueryRankRecordsRequest> request);
    }

    #endregion

    #region GameLibary 游戏库存业务

    IGameLibaryClient GameLibary { get; }

    interface IGameLibaryClient
    {
        /// <summary>
        /// 同步用户 Steam 信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp> SyncUserAppInfo(SyncSteamUserAppInfoRequest request);

        /// <summary>
        /// 根据 Steam AppId 与 Steam 64 位用户 Id 查询是否存在用户的已拥有游戏中
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> OwnedGamesExists(QuerySteamAppIdExistOwnedGamesRequest request);

        /// <summary>
        /// 根据 Steam AppId 与 Steam 64 位用户 Id 查询是否存在用户的愿望单中
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IApiRsp<bool>> WishListExist(QuerySteamAppIdExistsWishListRequest request);
    }

    #endregion
}
