namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GamePriceResponse
{
    [MPKey(0), MP2Key(0)]
    public decimal Price { get; set; }

    [MPKey(1), MP2Key(1)]
    public decimal Discount { get; set; }

    [MPKey(2), MP2Key(2)]
    public DateTimeOffset? DiscountExpireTime { get; set; }

    [MPKey(3), MP2Key(3)]
    public decimal CurrentPrice { get; set; }

    [MPKey(4), MP2Key(4)]
    public decimal LowestPrice { get; set; }

    [MPKey(5), MP2Key(5)]
    public Guid RegionId { get; set; }

    [MPKey(6), MP2Key(6)]
    public Guid DealerId { get; set; }

    [MPKey(7), MP2Key(7)]
    public CurrencyCode CurrencyCode { get; set; }
}
