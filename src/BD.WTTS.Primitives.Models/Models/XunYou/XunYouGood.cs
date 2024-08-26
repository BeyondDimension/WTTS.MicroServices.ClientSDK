// ReSharper disable once CheckNamespace

namespace BD.WTTS.Models.XunYou;

[MemoryPackable(GenerateType.VersionTolerant, SerializeLayout.Explicit)]
public partial class XunYouGoodDTO
{
    /// <summary>
    /// Id
    /// </summary>
    [MemoryPackOrder(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 商品名
    /// </summary>
    [MemoryPackOrder(1)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 价格
    /// </summary>
    [MemoryPackOrder(2)]
    public decimal Price { get; set; }

    /// <summary>
    /// 首次价格
    /// </summary>
    [MemoryPackOrder(3)]
    public decimal FirstPrice { get; set; }

    /// <summary>
    /// 充值天数
    /// </summary>
    [MemoryPackOrder(4)]
    public int RechargeDays { get; set; }

    /// <summary>
    /// 是否协议商品（自动扣款续费）
    /// </summary>
    [MemoryPackOrder(5)]
    public bool IsAgreement { get; set; }
}