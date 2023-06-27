// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVersionDTODownloadCompat : IExplicitHasValue
{
    /// <inheritdoc cref="AppDownloadType"/>
    [MPKey(0), MP2Key(0)]
    public AppDownloadType DownloadType { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? SHA256 { get; set; }

    [MPKey(2), MP2Key(2)]
    public long Length { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? FileIdOrUrl { get; set; }

    [MPKey(4), MP2Key(4)]
    public UpdateChannelType DownloadChannelType { get; set; }

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return !string.IsNullOrWhiteSpace(SHA256) &&
            Length > 0;
    }
}