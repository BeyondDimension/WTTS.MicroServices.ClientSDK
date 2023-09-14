// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BalanceTradeBusinessOrderDto
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid UserId { get; set; }

    [MPKey(2), MP2Key(2)]
    public Guid GoodsRechargeCategoryId { get; set; }

    [MPKey(3), MP2Key(3)]
    public Guid? GenericOrderId { get; set; }

    [MPKey(4), MP2Key(4)]
    public decimal AmountReceivable { get; set; }

    [MPKey(5), MP2Key(5)]
    public decimal AmountReceived { get; set; }

    [MPKey(6), MP2Key(6)]
    public OrderStatus PaymentStatus { get; set; }

    [MPKey(7), MP2Key(7)]
    public GoodsRechageStatus GoodsRechargeStatus { get; set; }

    [MPKey(8), MP2Key(8)]
    public DateTimeOffset? PaymentTime { get; set; }

    [MPKey(9), MP2Key(9)]
    public DateTimeOffset? RechargeCompletionTime { get; set; }

    [MPKey(10), MP2Key(10)]
    public long UserSteamId { get; set; }

    [MPKey(11), MP2Key(11)]
    public string UserSteamTransactionLink { get; set; } = string.Empty;

    [MPKey(12), MP2Key(12)]
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    [MPKey(13), MP2Key(13)]
    public decimal RechargeAmount { get; set; }

    [MPKey(14), MP2Key(14)]
    public string RechargeArea { get; set; } = string.Empty;

    [MPKey(15), MP2Key(15)]
    public decimal Premium { get; set; }

    [MPKey(16), MP2Key(16)]
    public Guid? MarketTransactionId { get; set; }

    #region Extention
    #endregion

}
