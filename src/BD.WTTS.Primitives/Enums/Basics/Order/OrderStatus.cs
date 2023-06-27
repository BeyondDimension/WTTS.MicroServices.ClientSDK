// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 订单状态
/// </summary>
public enum OrderStatus : byte
{
    待付款 = 1,
    已付款,
    已过期,
    已取消,
    已关闭,
    已完成,
    已退款,
}
