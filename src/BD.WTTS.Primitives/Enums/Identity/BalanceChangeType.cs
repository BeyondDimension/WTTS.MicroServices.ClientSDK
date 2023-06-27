// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

public enum BalanceChangeType : short
{
    /// <summary>
    /// 充值
    /// </summary>
    [Description("充值")]
    Recharge = 1,

    /// <summary>
    /// 购买商品
    /// </summary>
    [Description("购买商品")]
    Shop = 2,
}