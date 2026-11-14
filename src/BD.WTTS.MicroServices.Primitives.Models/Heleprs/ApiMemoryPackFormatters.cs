#if WTTS_NATIVE_AOT
namespace BD.WTTS;

// Register official closed contracts before MemoryPack's first formatter lookup.
// Explicit collection formatters avoid runtime generic construction in native builds.
internal static class ApiMemoryPackFormatters
{
    [ModuleInitializer]
    internal static void Register()
    {
        MemoryPackFormatterProvider.Register<ApiRsp>();
        MemoryPackFormatterProvider.Register<ApiRsp<string>>();
        MemoryPackFormatterProvider.Register<ApiRsp<bool>>();
        MemoryPackFormatterProvider.Register<ApiRsp<int>>();
        MemoryPackFormatterProvider.Register<ApiRsp<Guid[]>>();
        MemoryPackFormatterProvider.Register<ApiRsp<byte[]>>();
        MemoryPackFormatterProvider.Register<ApiRsp<PagedModel<ArticleItemDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<PagedModel<OfficialMessageItemDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<AppVersionDTO>>();
        MemoryPackFormatterProvider.Register<ApiRsp<LoginOrRegisterResponse>>();
        MemoryPackFormatterProvider.Register<ApiRsp<JWTEntity>>();
        MemoryPackFormatterProvider.Register<ApiRsp<ClockInResponse>>();
        MemoryPackFormatterProvider.Register<ApiRsp<IEnumerable<DateTimeOffset>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<IdentityUserInfoDTO>>();
        MemoryPackFormatterProvider.Register<ApiRsp<XunYouVipEndTimeResponse>>();
        MemoryPackFormatterProvider.Register<ApiRsp<List<AccelerateProjectGroupDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<ScriptInfoDTO>>();
        MemoryPackFormatterProvider.Register<ApiRsp<ScriptDTO>>();
        MemoryPackFormatterProvider.Register<ApiRsp<PagedModel<ScriptDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<List<ScriptInfoDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<PagedModel<ScriptEvaluationDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<List<AdvertisementDTO>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<UserAuthenticatorResponse[]>>();
        MemoryPackFormatterProvider.Register<ApiRsp<UserAuthenticatorPushResponse>>();
        MemoryPackFormatterProvider.Register<ApiRsp<UserAuthenticatorDeleteBackupResponse[]>>();
        MemoryPackFormatterProvider.Register<ApiRsp<PagedModel<QueryRankRecordsResponse>>>();
        MemoryPackFormatterProvider.Register<ApiRsp<List<XunYouGoodDTO>>>();

        MemoryPackFormatterProvider.Register<PagedModel<ArticleItemDTO>>();
        MemoryPackFormatterProvider.Register<PagedModel<OfficialMessageItemDTO>>();
        MemoryPackFormatterProvider.Register<PagedModel<ScriptDTO>>();
        MemoryPackFormatterProvider.Register<PagedModel<ScriptEvaluationDTO>>();
        MemoryPackFormatterProvider.Register<PagedModel<QueryRankRecordsResponse>>();
        MemoryPackFormatterProvider.Register<ArticleItemDTO>();
        MemoryPackFormatterProvider.Register<ArticleTagDTO>();
        MemoryPackFormatterProvider.Register<ArticleCategoryDTO>();
        MemoryPackFormatterProvider.Register<OfficialMessageItemDTO>();
        MemoryPackFormatterProvider.Register<AppVersionDTO>();
        MemoryPackFormatterProvider.Register<AppVersionDTODownload>();
        MemoryPackFormatterProvider.Register<LoginOrRegisterResponse>();
        MemoryPackFormatterProvider.Register<JWTEntity>();
        MemoryPackFormatterProvider.Register<ClockInResponse>();
        MemoryPackFormatterProvider.Register<IdentityUserInfoDTO>();
        MemoryPackFormatterProvider.Register<XunYouVipEndTimeResponse>();
        MemoryPackFormatterProvider.Register<XunYouVipEndTimeResponseData>();
        MemoryPackFormatterProvider.Register<XunYouVipEndTimeResponseDataSVIP>();
        MemoryPackFormatterProvider.Register<AccelerateProjectGroupDTO>();
        MemoryPackFormatterProvider.Register<AccelerateProjectDTO>();
        MemoryPackFormatterProvider.Register<ScriptInfoDTO>();
        MemoryPackFormatterProvider.Register<ScriptDTO>();
        MemoryPackFormatterProvider.Register<ScriptEvaluationDTO>();
        MemoryPackFormatterProvider.Register<AdvertisementDTO>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorResponse>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorPushResponse>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorDeleteBackupResponse>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorPushItem>();
        MemoryPackFormatterProvider.Register<QueryRankRecordsResponse>();
        MemoryPackFormatterProvider.Register<QueryRankRecordsRequest>();
        MemoryPackFormatterProvider.Register<XunYouGoodDTO>();
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.ListFormatter<AccelerateProjectGroupDTO>());
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.ListFormatter<ScriptInfoDTO>());
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.ListFormatter<AdvertisementDTO>());
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.ListFormatter<XunYouGoodDTO>());
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.InterfaceEnumerableFormatter<DateTimeOffset>());
        MemoryPackFormatterProvider.Register(new MemoryPack.Formatters.InterfaceEnumerableFormatter<Guid>());

        MemoryPackFormatterProvider.Register<LoginOrRegisterRequest>();
        MemoryPackFormatterProvider.Register<RefreshTokenRequest>();
        MemoryPackFormatterProvider.Register<ChangePhoneNumberValidationRequest>();
        MemoryPackFormatterProvider.Register<ChangePhoneNumberNewRequest>();
        MemoryPackFormatterProvider.Register<ClockInRequest>();
        MemoryPackFormatterProvider.Register<EditUserProfileRequest>();
        MemoryPackFormatterProvider.Register<BindPhoneNumberRequest>();
        MemoryPackFormatterProvider.Register<SendSmsRequest>();
        MemoryPackFormatterProvider.Register<GetAccelerateProjectGroupRequest>();
        MemoryPackFormatterProvider.Register<AddOrUpdateEvaluationRequest>();
        MemoryPackFormatterProvider.Register<JudgeEvaluationRequest>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorPushRequest>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorIndependentPasswordSetRequest>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorIndependentPasswordResetRequest>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorIndependentPasswordVerifyRequest>();
        MemoryPackFormatterProvider.Register<UserAuthenticatorDeleteBackupRecoverRequest>();
        MemoryPackFormatterProvider.Register<PageQueryRequest<QueryRankRecordsRequest>>();
        MemoryPackFormatterProvider.Register<SyncSteamUserAppInfoRequest>();
        MemoryPackFormatterProvider.Register<QuerySteamAppIdExistOwnedGamesRequest>();
        MemoryPackFormatterProvider.Register<QuerySteamAppIdExistsWishListRequest>();
    }
}
#endif
