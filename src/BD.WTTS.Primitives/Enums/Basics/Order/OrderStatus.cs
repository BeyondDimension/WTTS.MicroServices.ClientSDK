// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 订单状态
/// </summary>
public enum OrderStatus : byte
{
    [Description("待付款")]
    WaitPay = 1,

    [Description("已付款")]
    Paid,

    [Description("已过期")]
    Expired,

    [Description("已取消")]
    Canceled,

    [Description("已关闭")]
    Closed,

    [Description("已完成")]
    Completed,

    [Description("已退款")]
    Refunded,
}