// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// V1版本
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVersionDTODownloadV1 : IExplicitHasValue
{
    /// <inheritdoc cref="CloudFileType"/>
    [MPKey(0), MP2Key(0)]
    public CloudFileType DownloadType { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? SHA256 { get; set; }

    [MPKey(2), MP2Key(2)]
    public long Length { get; set; }

    [MPKey(3), MP2Key(3)]
    public string[] DownloadUrls { get; set; } = [];

    [MPKey(4), MP2Key(4)]
    public UpdateChannelType DownloadChannelType { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? SHA384 { get; set; }

    /// <summary>
    /// 是否增量更新
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public bool IncrementalUpdate { get; set; }

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return ((SHA256 != null && SHA256.Length == Hashs.String.Lengths.SHA256) || (SHA384 != null && SHA384.Length == Hashs.String.Lengths.SHA384)) &&
            DownloadUrls.All(url => String2.IsHttpUrl(url, true)) &&
            Length > 0 &&
            DownloadType.IsDefined() &&
            DownloadChannelType != UpdateChannelType.Auto && DownloadChannelType.IsDefined();
    }
}