// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GoodsRechargeCategoryDto
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string ProductName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public GoodsRechargeType GoodsRechargeType { get; set; }

    [MPKey(3), MP2Key(3)]
    public decimal MinimumSellingAmount { get; set; }

    [MPKey(4), MP2Key(4)]
    public string SellQuotaRegion { get; set; } = string.Empty;

    [MPKey(5), MP2Key(5)]
    public string? Describe { get; set; }

    [MPKey(6), MP2Key(6)]
    public float FeeRatio { get; set; }
}
