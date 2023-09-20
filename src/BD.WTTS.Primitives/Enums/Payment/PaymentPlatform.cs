// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 支付平台
/// </summary>
public enum PaymentPlatform
{
    [Description("支付宝")]
    Alipay = 1,

    [Description("微信支付")]
    WeChatPay = 2,
}