// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVersionDTODownload_v1 : IExplicitHasValue
{
    /// <inheritdoc cref="CloudFileType"/>
    [MPKey(0), MP2Key(0)]
    public CloudFileType DownloadType { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? SHA256 { get; set; }

    [MPKey(2), MP2Key(2)]
    public long Length { get; set; }

    [MPKey(3), MP2Key(3)]
    public string DownloadUrl { get; set; } = "";

    [MPKey(4), MP2Key(4)]
    public UpdateChannelType DownloadChannelType { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? SHA384 { get; set; }

    /// <summary>
    /// 是否增量更新
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public bool IncrementalUpdate { get; set; }

    /// <summary>
    /// 匹配域名地址数组
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[] DownloadUrlArray
        => ApiConstants.GetSplitValues(DownloadUrl);

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return ((SHA256 != null && SHA256.Length == Hashs.String.Lengths.SHA256) || (SHA384 != null && SHA384.Length == Hashs.String.Lengths.SHA384)) &&
            String2.IsHttpUrl(DownloadUrl, true) &&
            Length > 0 &&
            DownloadType.IsDefined() &&
            DownloadChannelType != UpdateChannelType.Auto && DownloadChannelType.IsDefined();
    }
}
