// ReSharper disable once CheckNamespace
using BD.WTTS.Enums.SteamRecharge;

namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BusinessOrderByCDKeyRequest
{
    [MPKey(0), MP2Key(0)]
    [Required]
    public string? CDKey { get; set; }

    /// <summary>
    /// 用户交易链接，礼品卡为【用户好友邀请链接】，余额充值为【用户库存交易链接】
    /// </summary>
    [Required]
    [MPKey(1), MP2Key(1)]
    public string? UserSteamTransactionLink { get; set; }

    /// <summary>
    /// 商品充值类型
    /// </summary>
    [Required]
    [MPKey(2), MP2Key(2)]
    public GoodsRechargeType GoodsRechargeType { get; set; }

    /// <summary>
    /// 充值金额
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 充值地区
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string RechargeArea { get; set; } = string.Empty;

    /// <summary>
    /// 订单来源
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public BusinessSource BusinessSource { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 成交时汇率
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }
}
