namespace BD.WTTS.Models;

/// <summary>
/// 用户拥有的插件DTO
/// </summary>
//[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserOwnedPluginDTO : IKeyModel<Guid>
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    #region PluginModule

    /// <summary>
    /// 插件唯一名称
    /// </summary>
    public string UniqueName { get; set; } = "";

    /// <summary>
    /// 分类 Id
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Logo 图标
    /// </summary>
    public string LogoIcon { get; set; } = "";

    /// <summary>
    /// 发布者显示名称
    /// </summary>
    public string PublisherDisplayName { get; set; } = "";

    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTimeOffset PublishTime { get; set; }

    /// <summary>
    /// 插件搜索词数组
    /// </summary>
    public string SearchTerms { get; set; } = "";

    #endregion PluginModule

    public UserOwnedPluginDTO[] PluginPackageDTOs { get; set; } = new UserOwnedPluginDTO[0];
}

//[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginPackageDTO : IKeyModel<Guid>
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    public string VersionNumber { get; set; } = "";

    /// <summary>
    /// 插件包 Hash
    /// </summary>
    public string PluginPackageHash { get; set; } = "";

    /// <summary>
    /// 静态资源 Id
    /// </summary>
    public Guid StaticResourceId { get; set; }

    /// <summary>
    /// 下载地址
    /// </summary>
    public string DownloadAddress { get; set; } = "";

    /// <summary>
    /// 程序最低支持版本
    /// </summary>
    public Guid TheMinimumSupportedVersionOfTheProgram { get; set; }

    /// <summary>
    /// 支持的系统
    /// </summary>
    public Platform SupportedSystems { get; set; }

    /// <summary>
    /// 支持的架构
    /// </summary>
    public ArchitectureFlags SupportedSchemas { get; set; }
}