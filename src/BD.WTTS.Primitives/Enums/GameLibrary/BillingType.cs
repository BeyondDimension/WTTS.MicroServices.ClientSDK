// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 计费类型
/// </summary>
public enum BillingType : byte
{
    /// <summary>
    /// 在商店购买
    /// </summary>
    商店购买 = 1,

    /// <summary>
    /// 使用 CDKey 兑换，卖 CDKey 的零售商手上买的
    /// </summary>
    CDKey,

    /// <summary>
    /// 免费领取
    /// </summary>
    免费入库,

    /// <summary>
    /// 礼物(玩家通行证)，朋友送的
    /// </summary>
    礼物,
}
