// ReSharper disable once CheckNamespace
namespace BD.WTTS.Services;

public static class CompatClientExtensions
{
    public static async Task<IApiRsp<NoticeGroupDTOCompat[]?>> Types_Compat(
        this IMicroServiceClient.INoticeClient client)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<NoticeGroupDTOCompat[]>(
           isPolly: true,
           isAnonymous: true,
           isSecurity: true,
           method: HttpMethod.Get,
           requestUri: "api/Notice/Types",
           cancellationToken: default);
        return r;
    }

    public static async Task<IApiRsp<PagedModel<NoticeDTOCompat>?>> Table_Compat(
        this IMicroServiceClient.INoticeClient client,
        Guid? typeId, int index, int? size = null)
    {
        var apiUrl = $"api/Notice/List/{(int)DeviceInfo2.Platform()}/{(int)DeviceInfo2.Idiom()}/?index={index}{(typeId.HasValue ? $"&typeid={typeId}" : "")}{(size.HasValue ? $"&size={size}" : "")}";
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<PagedModel<NoticeDTOCompat>>(
                     isPolly: true,
                     isAnonymous: true,
                     isSecurity: true,
                     method: HttpMethod.Post,
                     requestUri: apiUrl,
                     cancellationToken: default);
        return r;
    }

    public static async Task<IApiRsp<NoticeDTOCompat[]?>> NewMsg_Compat(
        this IMicroServiceClient.INoticeClient client,
        Guid? typeId, DateTimeOffset? time)
    {
        var apiUrl = $"api/Notice/NewMsg/{(int)DeviceInfo2.Platform()}/{(int)DeviceInfo2.Idiom()}?v=1{(typeId.HasValue ? $"&typeid={typeId}" : "")}{(time.HasValue ? $"?time={time}" : "")}";
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<NoticeDTOCompat[]>(
                       isPolly: true,
                       isAnonymous: true,
                       isSecurity: true,
                       method: HttpMethod.Get,
                       requestUri: apiUrl,
                       cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 检查更新
    /// </summary>
    /// <param name="client"></param>
    /// <param name="id">当前应用版本 Id</param>
    /// <param name="platform">(单选)当前设备所属平台</param>
    /// <param name="deviceIdiom">(单选)当前设备所属类型</param>
    /// <param name="osVersion">当前设备运行的操作系统版本号</param>
    /// <param name="architecture">当前 OS 支持的 CPU 架构</param>
    /// <param name="deploymentMode">当前应用部署模型</param>
    /// <returns></returns>
    public static async Task<IApiRsp<AppVersionDTOCompat?>> CheckUpdate2_Compat(
        this IMicroServiceClient.IVersionClient client,
        Guid id,
        Platform platform,
        DeviceIdiom deviceIdiom,
        Version osVersion,
        Architecture architecture,
        DeploymentMode deploymentMode)
    {
        var url = $"api/version/checkupdate3/{id}/{(int)platform}/{(int)deviceIdiom}/{(int)architecture}/{osVersion.Major}/{osVersion.Minor}/{osVersion.Build}/{(int)deploymentMode}";
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<AppVersionDTOCompat?>(
            isAnonymous: true,
            method: HttpMethod.Get,
            requestUri: url,
            cancellationToken: default,
            responseContentMaybeNull: true);
        return r;
    }

    /// <summary>
    /// 记录活跃用户并返回通知(公告，如果有新公告时)
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request">匿名收集数据</param>
    /// <returns></returns>
    public static async Task<IApiRsp> Post_Compat(
        this IMicroServiceClient.IActiveUserClient client,
        ActiveUserRecordDTOCompat request)
    {
        var r = await ((MicroServiceClientBase)client).Conn.
            SendAsync<ActiveUserRecordDTOCompat?, NoticeDTOCompat?>(
                isAnonymous: true, // 仅匿名收集
                isSecurity: true,
                responseContentMaybeNull: true,
                method: HttpMethod.Post,
                requestUri: $"api/ActiveUser",
                request: request,
                cancellationToken: default);
        return r;
    }

    public static async Task<IApiRsp<LoginOrRegisterResponseCompat?>> LoginOrRegister_Compat(
        this IMicroServiceClient.IAccountClient client,
        LoginOrRegisterRequestCompat request)
    {
        var r = await ((MicroServiceClientBase)client).Conn
            .SendAsync<LoginOrRegisterRequestCompat, LoginOrRegisterResponseCompat>(
              isAnonymous: true,
              isSecurity: true,
              method: HttpMethod.Post,
              requestUri: "api/Account/LoginOrRegister",
              request: request,
              cancellationToken: default,
              responseContentMaybeNull: false);
        return r;
    }

    /// <summary>
    /// 换绑手机（安全验证）
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<string?>> ChangeBindPhoneNumber_Compat(
        this IMicroServiceClient.IManageClient client,
        ChangePhoneNumberValidationRequest request)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<ChangePhoneNumberValidationRequest, string>(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "api/Manage/ChangeBindPhoneNumber",
                request: request,
                cancellationToken: default,
                responseContentMaybeNull: false);
        return r;
    }

    /// <summary>
    /// 绑定新手机号
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> ChangeBindPhoneNumber_Compat(
        this IMicroServiceClient.IManageClient client,
        ChangePhoneNumberNewRequest request)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Put,
                requestUri: "api/Manage/ChangeBindPhoneNumber",
                request: request,
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 删除账号
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> DeleteAccount_Compat(
        this IMicroServiceClient.IManageClient client
        )
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Delete,
                requestUri: "api/Manage/DeleteAccount",
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 每日签到
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<ClockInResponse?>> ClockIn_Compat(
        this IMicroServiceClient.IManageClient client
        )
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<ClockInRequest, ClockInResponse>(
                  isAnonymous: false,
                  isSecurity: true,
                  method: HttpMethod.Post,
                  requestUri: "api/Manage/ClockIn",
                  request: new ClockInRequest
                  {
                      CreationTime = DateTimeOffset.Now,
                  },
                  cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 获取签到历史记录
    /// </summary>
    /// <param name="client"></param>
    /// <param name="time">时间 服务器会自动取该时间本月的所有签到记录</param>
    /// <returns></returns>
    public static async Task<IApiRsp<IEnumerable<DateTimeOffset>?>> ClockInLogs_Compat(
        this IMicroServiceClient.IManageClient client,
        DateTimeOffset? time)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<IEnumerable<DateTimeOffset>>(
              isAnonymous: false,
              isSecurity: true,
              method: HttpMethod.Get,
              requestUri: $"api/Manage/ClockInLogs?time={(time.HasValue ? time : DateTimeOffset.Now)}",
              cancellationToken: default,
              responseContentMaybeNull: false);
        return r;
    }

    /// <summary>
    /// 编辑用户资料
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> EditUserProfile_Compat(
        this IMicroServiceClient.IManageClient client,
        EditUserProfileRequest request)
    {
        var errorMessage = request.GetErrorMessage();
        if (errorMessage != null) return ApiRspHelper.Fail(errorMessage);
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "api/Manage/EditUserProfile",
                request: request,
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 登出
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> SignOut_Compat(
        this IMicroServiceClient.IManageClient client
        )
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Get,
                requestUri: "api/Manage/SignOut",
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 绑定手机号码(通过快速登录注册的账号需要此功能)
    /// </summary>
    /// <param name="client"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> BindPhoneNumber_Compat(
        this IMicroServiceClient.IManageClient client,
        BindPhoneNumberRequest request)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Post,
                requestUri: "api/Manage/BindPhoneNumber",
                request: request,
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 解绑账号
    /// </summary>
    /// <param name="client"></param>
    /// <param name="channel"></param>
    /// <returns></returns>
    public static async Task<IApiRsp> UnbundleAccount_Compat(
        this IMicroServiceClient.IManageClient client,
        ExternalLoginChannel channel)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync(
                isAnonymous: false,
                method: HttpMethod.Delete,
                requestUri: $"api/Manage/UnbundleAccount/{(int)channel}",
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 刷新用户信息
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<UserInfoDTOCompat?>> RefreshUserInfo_Compat(
        this IMicroServiceClient.IManageClient client
        )
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<UserInfoDTOCompat>(
                isAnonymous: false,
                isSecurity: true,
                method: HttpMethod.Get,
                requestUri: $"api/Manage/RefreshUserInfo",
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 获取所有加速项目组数据
    /// </summary>
    /// <param name="client"></param>
    /// <param name="engine">当前反向代理引擎</param>
    /// <returns></returns>
    public static async Task<IApiRsp<List<AccelerateProjectGroupDTOCompat>?>> All_Compat(
        this IMicroServiceClient.IAccelerateClient client,
        ReverseProxyEngine engine)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<List<AccelerateProjectGroupDTOCompat>>(
                isPolly: true,
                isAnonymous: false,
                isSecurity: false,
                method: HttpMethod.Get,
                requestUri: $"api/Accelerate/All/{(int)engine}",
                cancellationToken: default);
        return r;
    }

    /// <summary>
    /// 获取基础框架最新版本
    /// </summary>
    /// <param name="client"></param>
    /// <param name="errorAppendText"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<ScriptInfoDTOCompat?>> Basics_Compat(
        this IMicroServiceClient.IScriptClient client,
        string? errorAppendText = null)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<ScriptInfoDTOCompat>(
                isAnonymous: true,
                method: HttpMethod.Get,
                requestUri: "api/script/basics",
                cancellationToken: default,
                responseContentMaybeNull: true,
                errorAppendText: errorAppendText);
        return r;
    }

    /// <summary>
    /// 脚本工坊接口
    /// </summary>
    /// <param name="client"></param>
    /// <param name="name">脚本名称</param>
    /// <param name="pageIndex">页码</param>
    /// <param name="pageSize">数量</param>
    /// <param name="errorAppendText"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<PagedModel<ScriptDTOCompat>?>> ScriptTable_Compat(
        this IMicroServiceClient.IScriptClient client,
        string? name = null, int pageIndex = 1, int pageSize = 15, string? errorAppendText = null)
    {
        var apiUrl = $"api/script/table/{pageIndex}/{pageSize}/{name ?? string.Empty}";
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<PagedModel<ScriptDTOCompat>>(
            method: HttpMethod.Get,
            requestUri: apiUrl,
            cancellationToken: default,
            responseContentMaybeNull: true,
            errorAppendText: errorAppendText);
        return r;
    }

    /// <summary>
    /// 获取全部脚本更新
    /// </summary>
    /// <param name="client"></param>
    /// <param name="ids">脚本 Id 组</param>
    /// <param name="errorAppendText"></param>
    /// <returns></returns>
    public static async Task<IApiRsp<IList<ScriptInfoDTOCompat>?>> ScriptUpdateInfo_Compat(
        this IMicroServiceClient.IScriptClient client,
        IEnumerable<Guid> ids, string? errorAppendText = null)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<IEnumerable<Guid>, IList<ScriptInfoDTOCompat>>(
                isAnonymous: true,
                method: HttpMethod.Post,
                request: ids,
                requestUri: "api/script/updates",
                cancellationToken: default,
                errorAppendText: errorAppendText);
        return r;
    }

    /// <summary>
    /// 常量 OfficialWebsite_Advertisement_Jump 为跳转地址
    /// 常量 OfficialWebsite_Advertisement_Image 为图片显示地址地址
    /// 移除默认值 返回全部有效期内的方法
    /// </summary>
    /// <param name="client"></param>
    /// <param name="type">广告类型默认不传返回全部</param>
    /// <returns>按 Order 排序 id 仅展示，接口只会返回没过期的</returns>
    public static async Task<IApiRsp<List<AdvertisementDTOCompat>?>> All_Compat(
        this IMicroServiceClient.IAdvertisementClient client,
        AdvertisementType? type = null)
    {
        var apiUrl = $"api/Advertisement/All/{(int)DeviceInfo2.Platform()}/{(int)DeviceInfo2.Idiom()}{(type.HasValue ? $"?type={type}" : "")}";
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<List<AdvertisementDTOCompat>>(
                isPolly: true,
                isAnonymous: true,
                isSecurity: true,
                method: HttpMethod.Get,
                requestUri: apiUrl,
                cancellationToken: default);
        return r;
    }

    public static async Task<IApiRsp<PagedModel<RankingResponseCompat>?>> RangeQuery_Compat(
        this IMicroServiceClient.ISponsorClient client,
        PageQueryRequest<RankingRequestCompat> request)
    {
        var r = await ((MicroServiceClientBase)client).Conn.SendAsync<PageQueryRequest<RankingRequestCompat>, PagedModel<RankingResponseCompat>>(
               isPolly: true,
               isAnonymous: true,
               isSecurity: false,
               method: HttpMethod.Post,
               requestUri: "api/ExternalTransaction/table",
               request: request,
               cancellationToken: default);
        return r;
    }
}
