// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 支付类型
/// </summary>
public enum PaymentType : byte
{
    余额 = 1,
    在线支付,
    优惠劵,
    银行转账,
}
