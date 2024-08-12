namespace BD.WTTS.Models;

[MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public sealed partial class PluginUpdateDetailDTO
{
    /// <summary>
    /// 插件 Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 更新地址 有更新会有 Url
    /// </summary>
    public string? UpdateUrl { get; set; }

    /// <summary>
    /// 最低支持版本 有数据代表不支持程序版本不满足
    /// </summary>
    public string? MinVersion { get; set; }

    public string? Message { get; set; }
}
