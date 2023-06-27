// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 客户端分发渠道
/// </summary>
public enum ClientDistributionChannel : byte
{
    /// <summary>
    /// 官方发行
    /// </summary>
    Official = 0,

    /// <summary>
    /// 微软应用商店
    /// <para>https://www.microsoft.com/zh-cn/Store</para>
    /// </summary>
    MicrosoftStore,

    /// <summary>
    /// 苹果应用商店
    /// <para>https://www.apple.com.cn/app-store</para>
    /// </summary>
    AppleAppStore,

    /// <summary>
    /// https://www.coolapk.com
    /// </summary>
    酷安,

    /// <summary>
    /// https://www.wandoujia.com
    /// </summary>
    豌豆荚,

    /// <summary>
    /// https://sj.qq.com
    /// </summary>
    应用宝,

    /// <summary>
    /// https://app.mi.com
    /// </summary>
    小米应用商店,

    /// <summary>
    /// https://consumer.huawei.com/cn/mobileservices/appgallery
    /// </summary>
    华为应用市场,

    /// <summary>
    /// https://lestore.lenovo.com/detail/L102646
    /// </summary>
    联想应用商店,

    // 更多发行渠道，当前不考虑制作单独的渠道包
}