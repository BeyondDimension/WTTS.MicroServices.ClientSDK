using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace BD.WTTS;

// Keep these roots aligned with MicroServiceClientBase.Clients: nested DTO members
// are discovered by the generator; no dependency assembly needs reflection roots.
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(ApiRsp))]
[JsonSerializable(typeof(ApiRsp<string>))]
[JsonSerializable(typeof(ApiRsp<bool>))]
[JsonSerializable(typeof(ApiRsp<int>))]
[JsonSerializable(typeof(ApiRsp<Guid[]>))]
[JsonSerializable(typeof(ApiRsp<byte[]>))]
[JsonSerializable(typeof(ApiRsp<PagedModel<ArticleItemDTO>>))]
[JsonSerializable(typeof(ApiRsp<PagedModel<OfficialMessageItemDTO>>))]
[JsonSerializable(typeof(ApiRsp<AppVersionDTO>))]
[JsonSerializable(typeof(ApiRsp<LoginOrRegisterResponse>))]
[JsonSerializable(typeof(ApiRsp<JWTEntity>))]
[JsonSerializable(typeof(ApiRsp<ClockInResponse>))]
[JsonSerializable(typeof(ApiRsp<IEnumerable<DateTimeOffset>>))]
[JsonSerializable(typeof(ApiRsp<IdentityUserInfoDTO>))]
[JsonSerializable(typeof(ApiRsp<XunYouVipEndTimeResponse>))]
[JsonSerializable(typeof(ApiRsp<List<AccelerateProjectGroupDTO>>))]
[JsonSerializable(typeof(ApiRsp<ScriptInfoDTO>))]
[JsonSerializable(typeof(ApiRsp<ScriptDTO>))]
[JsonSerializable(typeof(ApiRsp<PagedModel<ScriptDTO>>))]
[JsonSerializable(typeof(ApiRsp<List<ScriptInfoDTO>>))]
[JsonSerializable(typeof(ApiRsp<PagedModel<ScriptEvaluationDTO>>))]
[JsonSerializable(typeof(ApiRsp<List<AdvertisementDTO>>))]
[JsonSerializable(typeof(ApiRsp<UserAuthenticatorResponse[]>))]
[JsonSerializable(typeof(ApiRsp<UserAuthenticatorPushResponse>))]
[JsonSerializable(typeof(ApiRsp<UserAuthenticatorDeleteBackupResponse[]>))]
[JsonSerializable(typeof(ApiRsp<PagedModel<QueryRankRecordsResponse>>))]
[JsonSerializable(typeof(ApiRsp<List<XunYouGoodDTO>>))]
[JsonSerializable(typeof(ActiveUserRecordDTO))]
[JsonSerializable(typeof(AppVerSubmissionRequest))]
[JsonSerializable(typeof(LoginOrRegisterRequest))]
[JsonSerializable(typeof(RefreshTokenRequest))]
[JsonSerializable(typeof(ChangePhoneNumberValidationRequest))]
[JsonSerializable(typeof(ChangePhoneNumberNewRequest))]
[JsonSerializable(typeof(ClockInRequest))]
[JsonSerializable(typeof(EditUserProfileRequest))]
[JsonSerializable(typeof(BindPhoneNumberRequest))]
[JsonSerializable(typeof(SendSmsRequest))]
[JsonSerializable(typeof(GetAccelerateProjectGroupRequest))]
[JsonSerializable(typeof(IEnumerable<Guid>))]
[JsonSerializable(typeof(AddOrUpdateEvaluationRequest))]
[JsonSerializable(typeof(JudgeEvaluationRequest))]
[JsonSerializable(typeof(UserAuthenticatorPushRequest))]
[JsonSerializable(typeof(UserAuthenticatorIndependentPasswordSetRequest))]
[JsonSerializable(typeof(UserAuthenticatorIndependentPasswordResetRequest))]
[JsonSerializable(typeof(UserAuthenticatorIndependentPasswordVerifyRequest))]
[JsonSerializable(typeof(UserAuthenticatorDeleteBackupRecoverRequest))]
[JsonSerializable(typeof(PageQueryRequest<QueryRankRecordsRequest>))]
[JsonSerializable(typeof(SyncSteamUserAppInfoRequest))]
[JsonSerializable(typeof(QuerySteamAppIdExistOwnedGamesRequest))]
[JsonSerializable(typeof(QuerySteamAppIdExistsWishListRequest))]
[JsonSerializable(typeof(ShopBaseRequest))]
[JsonSerializable(typeof(ShopBaseResponse<ShopJwtToken>))]
[JsonSerializable(typeof(ShopBaseResponse<ShopRecommendGoodItem[]>))]
public sealed partial class ApiJsonSerializerContext : JsonSerializerContext
{
    static readonly ApiJsonSerializerContext shop = new(new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    });

    static readonly ApiJsonSerializerContext web = new(new JsonSerializerOptions(JsonSerializerDefaults.Web));

    public static JsonTypeInfo<T> GetWebMetadata<T>()
    {
        var metadata = web.GetTypeInfo(typeof(T));
        if (metadata != null) return (JsonTypeInfo<T>)metadata;
#if !WTTS_NATIVE_AOT
        return (JsonTypeInfo<T>)JsonSerializerOptions.Web.GetTypeInfo(typeof(T));
#else
        throw new NotSupportedException($"No generated API JSON metadata for {typeof(T)}.");
#endif
    }

    public static JsonTypeInfo GetMetadata(Type type, bool shopResponse = false)
    {
        var context = shopResponse ? shop : Default;
        var metadata = context.GetTypeInfo(type);
        if (metadata != null) return metadata;
#if !WTTS_NATIVE_AOT
        // External JIT plugins may introduce additional request/response models.
        return (shopResponse ? reflectionShopOptions : JsonSerializerOptions.Default).GetTypeInfo(type);
#else
        throw new NotSupportedException($"No generated API JSON metadata for {type}.");
#endif
    }

    public static JsonTypeInfo<T> GetMetadata<T>(bool shopResponse = false)
        => (JsonTypeInfo<T>)GetMetadata(typeof(T), shopResponse);

#if !WTTS_NATIVE_AOT
    static readonly JsonSerializerOptions reflectionShopOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
    };
#endif
}
