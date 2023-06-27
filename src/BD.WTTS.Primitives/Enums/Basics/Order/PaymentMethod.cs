// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 支付方式
/// </summary>
public enum PaymentMethod : byte
{
    现金 = 1,
    在线支付,
    余额,
    优惠卷,
    银行转账,
    POS机,
}
