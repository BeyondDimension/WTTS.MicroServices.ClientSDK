// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 退款状态
/// </summary>
public enum RefundStatus
{
    /// <summary>
    /// 未退款
    /// </summary>
    [Description("未退款")]
    NoRefund = 1,

    /// <summary>
    /// 已退款
    /// </summary>
    [Description("已退款")]
    Refund = 2,

    /// <summary>
    /// 同意退款但原路退还失败
    /// </summary>
    [Description("同意退款但原路退还失败")]
    Fail = 3,

    /// <summary>
    /// 被拒绝
    /// </summary>
    [Description("被拒绝")]
    Refused = 4,

    /// <summary>
    /// 退款中
    /// </summary>
    [Description("退款中")]
    Refunding = 5,
}