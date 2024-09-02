namespace BD.WTTS.Models;

/// <summary>
/// 用户拥有的插件DTO
/// </summary>
[MPObj, MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public sealed partial class UserOwnedPluginDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid PluginId { get; set; }

    /// <summary>
    /// 插件唯一名称
    /// </summary>
    public string UniqueName { get; set; } = "";

    /// <summary>
    /// Logo 图标
    /// </summary>
    public string LogoIcon { get; set; } = "";

    /// <summary>
    /// 发布者显示名称
    /// </summary>
    public string PublisherDisplayName { get; set; } = "";

    /// <summary>
    /// 订阅结束时间
    /// </summary>
    public DateTimeOffset? SubscriptionEndTime { get; set; }
}