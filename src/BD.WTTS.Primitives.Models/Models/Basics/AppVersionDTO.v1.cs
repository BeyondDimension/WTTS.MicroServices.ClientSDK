// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class AppVersionDTO_v1 : IKeyModel<Guid>, IExplicitHasValue
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string Version { get; set; } = "";

    /// <summary>
    /// 版本说明
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string ReleaseNote { get; set; } = "";

    /// <summary>
    /// (单选)支持的平台
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public Platform Platform { get; set; }

    /// <summary>
    /// (多或单选)支持的CPU构架
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public ArchitectureFlags SupportedAbis { get; set; }

    /// <summary>
    /// 是否禁用自动化更新，当此值为 <see langword="true"/> 时，仅提供跳转官网的手动更新方式
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public bool DisableAutomateUpdate { get; set; }

    /// <summary>
    /// 下载类型与下载地址
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public List<AppVersionDTODownload_v1>? Downloads { get; set; }

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return !string.IsNullOrWhiteSpace(Version) &&
            !string.IsNullOrWhiteSpace(ReleaseNote) &&
            (DisableAutomateUpdate || (Downloads != null && Downloads.Any(x => x.HasValue())));
    }
}