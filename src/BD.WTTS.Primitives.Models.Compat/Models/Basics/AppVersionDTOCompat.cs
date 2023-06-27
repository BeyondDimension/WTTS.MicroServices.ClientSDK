// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class AppVersionDTOCompat : IKeyModel<Guid>, IExplicitHasValue
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? Version { get; set; }

    /// <summary>
    /// 本次更新描述
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? Description { get; set; }

    /// <summary>
    /// (增量更新V1)新版本文件增量更新，由服务端比较版本差异返回差集，当文件哈希值相同时或路径不同时无法正确更新
    /// </summary>
    [MPKey(3), MP2Key(3)]
    [Obsolete("use AllFiles")]
    public IEnumerable<AppVersionDTOIncrementalUpdateDownloadCompat>? IncrementalUpdate { get; set; }

    /// <summary>
    /// 下载类型与下载地址
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public IEnumerable<AppVersionDTODownloadCompat>? Downloads { get; set; }

    /// <summary>
    /// (单选)支持的平台
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public Platform Platform { get; set; }

    /// <summary>
    /// (多或单选)支持的CPU构架
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public ArchitectureFlags SupportedAbis { get; set; }

    /// <summary>
    /// (增量更新V2)新版本的完整文件列表清单，由客户端计算当前文件哈希比对清单，出现不一致时下载文件，注意文件哈希值相同但路径不同的情况下不要重复下载
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public IEnumerable<AppVersionDTOIncrementalUpdateDownloadCompat>? AllFiles { get; set; }

    /// <summary>
    /// 是否禁用自动化更新，当此值为 <see langword="true"/> 时，仅提供跳转官网的手动更新方式
    /// </summary>
    [MPKey(8), MP2Key(8)]
    public bool DisableAutomateUpdate { get; set; }

    /// <summary>
    /// (增量更新V2)当前版本的完整文件列表清单
    /// </summary>
    [MPKey(9), MP2Key(9)]
    public IEnumerable<AppVersionDTOIncrementalUpdateDownloadCompat>? CurrentAllFiles { get; set; }

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return !string.IsNullOrWhiteSpace(Version) &&
            !string.IsNullOrWhiteSpace(Description) &&
            Downloads != null && Downloads.All(x => x.HasValue());
    }
}