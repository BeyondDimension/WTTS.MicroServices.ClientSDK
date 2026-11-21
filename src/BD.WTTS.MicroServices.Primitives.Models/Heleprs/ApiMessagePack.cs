using MessagePack.Resolvers;

namespace BD.WTTS;

/// <summary>MessagePack options for the SDK's indexed API contracts and LZ4 block-array envelope.</summary>
public static class ApiMessagePack
{
    public static MessagePackSerializerOptions Options { get; } = Serializable.lz4Options.WithResolver(
        CompositeResolver.Create(
            BuiltinResolver.Instance,
            ApiMessagePackResolver.Instance,
            ApiModelMessagePackResolver.Instance,
#if WTTS_NATIVE_AOT
            BD.Common.Models.CommonMessagePackResolver.Instance
#else
            // Standalone/JIT SDK users can supply additional contracts and use older BD.Common packages.
            StandardResolver.Instance
#endif
        ));
}

[GeneratedMessagePackResolver]
internal partial class ApiMessagePackResolver;

// Only closed generic wire roots that cannot be inferred from the DTO declarations.
// The generator walks the substituted members (including PagedModel<T>.DataSource).
// This type is never serialized as a wrapper on the wire.
[MPObj(AllowPrivate = true)]
internal sealed class ApiMessagePackContracts
{
    [MPKey(0)] public ApiRsp<string>? String { get; set; }

    [MPKey(1)] public ApiRsp<bool>? Boolean { get; set; }

    [MPKey(2)] public ApiRsp<int>? Integer { get; set; }

    [MPKey(3)] public ApiRsp<Guid[]>? Guids { get; set; }

    [MPKey(4)] public ApiRsp<byte[]>? Bytes { get; set; }

    [MPKey(5)] public ApiRsp<PagedModel<ArticleItemDTO>>? Articles { get; set; }

    [MPKey(6)] public ApiRsp<PagedModel<OfficialMessageItemDTO>>? OfficialMessages { get; set; }

    [MPKey(7)] public ApiRsp<AppVersionDTO>? AppVersion { get; set; }

    [MPKey(8)] public ApiRsp<LoginOrRegisterResponse>? Login { get; set; }

    [MPKey(9)] public ApiRsp<JWTEntity>? Token { get; set; }

    [MPKey(10)] public ApiRsp<ClockInResponse>? ClockIn { get; set; }

    [MPKey(11)] public ApiRsp<IEnumerable<DateTimeOffset>>? ClockInDates { get; set; }

    [MPKey(12)] public ApiRsp<IdentityUserInfoDTO>? UserInfo { get; set; }

    [MPKey(13)] public ApiRsp<XunYouVipEndTimeResponse>? VipEndTime { get; set; }

    [MPKey(14)] public ApiRsp<List<AccelerateProjectGroupDTO>>? AccelerateGroups { get; set; }

    [MPKey(15)] public ApiRsp<ScriptInfoDTO>? ScriptInfo { get; set; }

    [MPKey(16)] public ApiRsp<ScriptDTO>? Script { get; set; }

    [MPKey(17)] public ApiRsp<PagedModel<ScriptDTO>>? Scripts { get; set; }

    [MPKey(18)] public ApiRsp<List<ScriptInfoDTO>>? ScriptInfos { get; set; }

    [MPKey(19)] public ApiRsp<PagedModel<ScriptEvaluationDTO>>? ScriptEvaluations { get; set; }

    [MPKey(20)] public ApiRsp<List<AdvertisementDTO>>? Advertisements { get; set; }

    [MPKey(21)] public ApiRsp<UserAuthenticatorResponse[]>? Authenticators { get; set; }

    [MPKey(22)] public ApiRsp<UserAuthenticatorPushResponse>? AuthenticatorPush { get; set; }

    [MPKey(23)] public ApiRsp<UserAuthenticatorDeleteBackupResponse[]>? DeletedAuthenticators { get; set; }

    [MPKey(24)] public ApiRsp<PagedModel<QueryRankRecordsResponse>>? SponsorRanks { get; set; }

    [MPKey(25)] public ApiRsp<List<XunYouGoodDTO>>? XunYouGoods { get; set; }

    [MPKey(26)] public IEnumerable<Guid>? ScriptIdsRequest { get; set; }

    [MPKey(27)] public PageQueryRequest<QueryRankRecordsRequest>? SponsorRanksRequest { get; set; }
}
