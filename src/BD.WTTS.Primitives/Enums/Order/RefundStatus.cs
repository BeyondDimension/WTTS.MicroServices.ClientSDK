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
    NoRefund = 1,

    /// <summary>
    /// 已退款
    /// </summary>
    Refund = 2,

    /// <summary>
    /// 同意退款但原路退还失败
    /// </summary>
    Fail = 3,

    /// <summary>
    /// 被拒绝
    /// </summary>
    Refused = 4,

    /// <summary>
    /// 退款中
    /// </summary>
    Refunding = 5,
}