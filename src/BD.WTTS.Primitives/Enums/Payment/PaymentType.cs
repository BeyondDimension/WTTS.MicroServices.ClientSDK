// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 支付类型
/// </summary>
public enum PaymentType : byte
{
    [Description("支付宝")]
    Alipay = 1,

    [Description("微信支付")]
    WeChatPay = 2,

    [Description("云闪付支付")]
    UnionPay = 3,
}
