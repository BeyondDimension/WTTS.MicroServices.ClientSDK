// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 订单类型
/// </summary>
public enum OrderType : byte
{
    普通订单 = 1,
    测试订单,
    营销刷单,
    活动订单,
}
