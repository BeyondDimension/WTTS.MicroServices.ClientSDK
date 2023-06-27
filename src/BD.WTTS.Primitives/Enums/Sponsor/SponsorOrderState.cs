// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 赞助订单状态
/// </summary>
public enum SponsorOrderState : byte
{
    /// <summary>
    /// 等待支付
    /// </summary>
    WaitPay = 1,

    /// <summary>
    /// 处理中
    /// </summary>
    Processing = 2,

    /// <summary>
    /// 等待发货
    /// </summary>
    WaitDeliver = 4,

    /// <summary>
    /// 订单取消
    /// </summary>
    Cancel = 10,

    /// <summary>
    /// 已退款
    /// </summary>
    Refund = 100,

    /// <summary>
    /// 订单完成
    /// </summary>
    OK = 200,
}

#if DEBUG
[Obsolete("use DonateOrderState", true)]
public static class EOrderState
{
    public const SponsorOrderState WaitPay = SponsorOrderState.WaitPay;
    public const SponsorOrderState Processing = SponsorOrderState.Processing;
    public const SponsorOrderState WaitDeliver = SponsorOrderState.WaitDeliver;
    public const SponsorOrderState Cancel = SponsorOrderState.Cancel;
    public const SponsorOrderState Refund = SponsorOrderState.Refund;
    public const SponsorOrderState OK = SponsorOrderState.OK;
}
#endif