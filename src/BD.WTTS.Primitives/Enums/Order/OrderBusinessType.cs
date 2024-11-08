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

    [Description("迅游订单")]
    XunYouOrder = 4,

    [Description("点数交易充值")]
    PointRewardRecharge = 5,

    [Description("用户点数交易充值")]
    PointRewardUserRecharge = 6
}