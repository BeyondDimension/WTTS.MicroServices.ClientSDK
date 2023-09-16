// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GiftsCardBusinessOrderDto
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid UserId { get; set; }

    /// <summary>
    /// 充值商品类型 Id
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 通用订单 Id
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public Guid? GenericOrderId { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public decimal AmountReceived { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public OrderStatus PaymentStatus { get; set; }

    /// <summary>
    /// 充值商品类型
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public GoodsRechageStatus GoodsRechargeStatus { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    [MPKey(8), MP2Key(8)]
    public DateTimeOffset? PaymentTime { get; set; }

    /// <summary>
    /// 充值完成时间
    /// </summary>
    [MPKey(9), MP2Key(9)]
    public DateTimeOffset? RechargeCompletionTime { get; set; }

    /// <summary>
    /// 用户 SteamId
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public long UserSteamId { get; set; }

    /// <summary>
    /// 用户添加 Bot 好友时间
    /// </summary>
    [MPKey(11), MP2Key(11)]
    public DateTimeOffset? UsersAddSteamBotFriendTime { get; set; }

    /// <summary>
    /// 成交时汇率
    /// </summary>
    [MPKey(12), MP2Key(12)]
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    /// <summary>
    /// 充值金额
    /// </summary>
    [MPKey(13), MP2Key(13)]
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 充值地区
    /// </summary>
    [MPKey(14), MP2Key(14)]
    public string RechargeArea { get; set; } = string.Empty;

    /// <summary>
    /// 交易记录 Id
    /// </summary>
    [MPKey(15), MP2Key(15)]
    public Guid? TransactionId { get; set; }

    /// <summary>
    /// 用户好友邀请链接
    /// </summary>
    [MPKey(16), MP2Key(16)]
    public string FriendInvitationLink { get; set; } = string.Empty;

    /// <summary>
    /// 手续费
    /// </summary>
    [MPKey(17), MP2Key(17)]
    public decimal Premium { get; set; }
}
