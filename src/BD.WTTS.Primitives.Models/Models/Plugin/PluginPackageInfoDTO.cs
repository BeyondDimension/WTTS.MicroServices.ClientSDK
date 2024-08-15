namespace BD.WTTS.Models;

/// <summary>
/// 插件包详情
/// </summary>
[MPObj, MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public sealed partial class PluginPackageInfoDTO
{
    public Guid Id { get; set; }

    public string PluginPackageHash { get; set; } = "";

    public string VersionNumber { get; set; } = "";

    public ClientPlatform SupportedPlatform { get; set; }

    public string Changelog { get; set; } = "";

    public string DownloadAddress { get; set; } = "";

    public string MinimumSupportedAppVersion { get; set; } = "";

    public DateTimeOffset UpdateTime { get; set; }

    public DateTimeOffset CreationTime { get; set; }
}
