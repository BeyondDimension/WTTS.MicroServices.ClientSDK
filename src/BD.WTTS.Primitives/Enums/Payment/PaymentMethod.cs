// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 支付方式
/// </summary>
public enum PaymentMethod : byte
{
    [Description("现金")]
    Cash = 1,

    [Description("在线支付")]
    Online = 2,

    [Description("余额")]
    Balance = 3,

    [Description("优惠卷")]
    Coupons = 4,

    [Description("银行转账")]
    BankTransfer = 5,

    [Description("POS机")]
    PointOfSalesTerminal = 6,
}