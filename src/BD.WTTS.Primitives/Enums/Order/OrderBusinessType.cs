namespace BD.WTTS.Enums;

/// <summary>
/// 订单业务类型
/// </summary>
public enum OrderBusinessType
{
    [Description("礼品卡充值")]
    GiftCardRecharge = 1,

    [Description("自助礼品卡充值")]
    SelfServiceGiftCardRecharge = 2,

    [Description("余额交易充值")]
    BalanceTransactionRecharge = 3,
}