// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BusinessOrderRequest
{
    [MPKey(0), MP2Key(0)]
    public Guid UserId { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid GoodsRechargeCategoryId { get; set; }

    [MPKey(2), MP2Key(2)]
    public decimal AmountReceivable { get; set; }

    [MPKey(3), MP2Key(3)]
    public long UserSteamId { get; set; }

    [MPKey(4), MP2Key(4)]
    public decimal RechargeAmount { get; set; }

    [MPKey(5), MP2Key(5)]
    public string RechargeArea { get; set; } = string.Empty;

    [MPKey(6), MP2Key(6)]
    public string? UserSteamTransactionLink { get; set; }

    [MPKey(7), MP2Key(7)]
    public OrderType OrderType { get; set; }

    [MPKey(8), MP2Key(8)]
    public ClientOSPlatform Source { get; set; }

    [MPKey(9), MP2Key(9)]
    public GoodsRechargeType GoodsRechargeType { get; set; }

    [MPKey(10), MP2Key(10)]
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    [MPKey(11), MP2Key(11)]
    public decimal Premium { get; set; }
}
