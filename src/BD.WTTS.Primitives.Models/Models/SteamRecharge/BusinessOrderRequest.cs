// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BusinessOrderRequest
{
    [MPKey(0), MP2Key(0)]
    public Guid UserId { get; set; }

    [Required]
    [MPKey(1), MP2Key(1)]
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 用户 SteamId
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public long UserSteamId { get; set; }

    /// <summary>
    /// 充值金额
    /// </summary>
    [Required]
    [MPKey(4), MP2Key(4)]
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 充值地区
    /// </summary>
    [Required]
    [MPKey(5), MP2Key(5)]
    public string RechargeArea { get; set; } = string.Empty;

    /// <summary>
    /// 用户交易链接，礼品卡为【用户好友邀请链接】，余额充值为【用户库存交易链接】
    /// </summary>
    [Required]
    [MPKey(6), MP2Key(6)]
    public string? UserSteamTransactionLink { get; set; }

    /// <summary>
    /// 订单类型
    /// </summary>
    [Required]
    [MPKey(7), MP2Key(7)]
    public OrderType OrderType { get; set; }

    /// <summary>
    /// 订单来源
    /// </summary>
    [Required]
    [MPKey(8), MP2Key(8)]
    public ClientOSPlatform Source { get; set; }

    /// <summary>
    /// 商品充值类型
    /// </summary>
    [Required]
    [MPKey(9), MP2Key(9)]
    public GoodsRechargeType GoodsRechargeType { get; set; }

    /// <summary>
    /// 成交时汇率
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    /// <summary>
    /// 手续费
    /// </summary>
    [MPKey(11), MP2Key(11)]
    public decimal Premium { get; set; }
}
