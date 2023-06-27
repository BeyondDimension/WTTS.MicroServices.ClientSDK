// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 获取赞助用户排行分页列表查询条件请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class RankingRequestCompat
{
    /// <summary>
    /// 排序类型是否是金额
    /// </summary>
    [MPKey(0), MP2Key(0)]
#if __HAVE_N_JSON__
    [N_JsonProperty("0")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("0")]
#endif
    public bool IsAmount { get; set; } = true;

    /// <summary>
    /// 时间范围
    /// </summary>
    [MPKey(1), MP2Key(1)]
#if __HAVE_N_JSON__
    [N_JsonProperty("1")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("1")]
#endif
    public DateTimeOffset[]? TimeRange { get; set; }

    /// <summary>
    /// 捐助平台
    /// </summary>
    [MPKey(2), MP2Key(2)]
#if __HAVE_N_JSON__
    [N_JsonProperty("2")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("2")]
#endif
    public SponsorPlatformType Type { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [MPKey(3), MP2Key(3)]
#if __HAVE_N_JSON__
    [N_JsonProperty("3")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("3")]
#endif
    public CurrencyCode CampaignCurrency { get; set; } = CurrencyCode.CNY;
}