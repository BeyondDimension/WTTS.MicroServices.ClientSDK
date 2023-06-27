namespace BD.WTTS.Enums;

/// <summary>
/// 插件费用类型
/// </summary>
public enum PluginFeeType
{
    /// <summary>
    /// 免费
    /// </summary>
    Free = 0,

    /// <summary>
    /// 一次性付费
    /// </summary>
    OneTimePayment = 1,

    /// <summary>
    /// 订阅制-按月
    /// </summary>
    Subscription_Monthly = 2,

    /// <summary>
    /// 订阅制-按季
    /// </summary>
    Subscription_Quarterly = 3,

    /// <summary>
    /// 订阅制-按年
    /// </summary>
    Subscription_Yearly = 4,
}