// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 获取赞助用户排行分页列表查询条件请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class QueryRankRecordsRequest
{
    /// <summary>
    /// 排序类型是否是金额
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public bool IsAmount { get; set; } = true;

    /// <summary>
    /// 时间范围 - 起
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public DateTimeOffset TimeRangeStart { get; set; }

    /// <summary>
    /// 捐助平台
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public SponsorPlatformType SponsorPlatform { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public CurrencyCode CurrencyCode { get; set; } = CurrencyCode.CNY;

    /// <summary>
    /// 时间范围 - 止
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public DateTimeOffset TimeRangeEnd { get; set; }
}