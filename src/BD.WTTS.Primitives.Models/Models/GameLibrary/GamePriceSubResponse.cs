namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GamePriceSubResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid DealerId { get; set; }

    [MPKey(2), MP2Key(2)]
    public string DealerPlatformName { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public decimal Price { get; set; }

    [MPKey(4), MP2Key(4)]
    public decimal Discount { get; set; }

    [MPKey(5), MP2Key(5)]
    public DateTimeOffset? DiscountExpireTime { get; set; }

    [MPKey(6), MP2Key(6)]
    public decimal CurrentPrice { get; set; }

    [MPKey(7), MP2Key(7)]
    public decimal LowestPrice { get; set; }

    [MPKey(8), MP2Key(8)]
    public Guid RegionId { get; set; }

    [MPKey(9), MP2Key(9)]
    public string RegionName { get; set; } = string.Empty;

    [MPKey(10), MP2Key(10)]
    public CurrencyCode CurrencyCode { get; set; }

    [MPKey(11), MP2Key(11)]
    public Guid SubId { get; set; }

    [MPKey(12), MP2Key(12)]
    public DateTimeOffset CreationTime { get; set; }

    [MPKey(13), MP2Key(13)]
    public decimal DiscountPercent { get { return Math.Round(this.Discount / this.Price * 100, 0); } set { DiscountPercent = value; } }

    [MPKey(14), MP2Key(14)]
    public List<GameHistoricalPriceStatisticResponse>? GameHistoricalPriceStatistics { get; set; }
}
