namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameHistoricalPriceStatisticResponse
{
    [MPKey(0), MP2Key(0)]
    public decimal Discount { get; set; }

    [MPKey(1), MP2Key(1)]
    public decimal CurrentPrice { get; set; }

    [MPKey(2), MP2Key(2)]
    public CurrencyCode CurrencyCode { get; set; }

    [MPKey(3), MP2Key(3)]
    public DateTimeOffset StartTime { get; set; }

    [MPKey(4), MP2Key(4)]
    public Guid RegionId { get; set; }

    [MPKey(5), MP2Key(5)]
    public Guid SubId { get; set; }

    [MPKey(6), MP2Key(6)]
    public Guid DealerId { get; set; }
}
