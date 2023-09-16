// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GoodsRechargeCategoryDto
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// 充值商品类型
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public GoodsRechargeType GoodsRechargeType { get; set; }

    /// <summary>
    /// 售卖额度最小值
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public decimal MinimumSellingAmount { get; set; }

    /// <summary>
    /// 售卖额度地区
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string SellQuotaRegion { get; set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public string? Describe { get; set; }

    /// <summary>
    /// 手续费比率
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public float FeeRatio { get; set; }
}
