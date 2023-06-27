// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVersionDTOIncrementalUpdateDownloadCompat : IExplicitHasValue
{
    [MPKey(0), MP2Key(0)]
    public string? SHA256 { get; set; }

    [MPKey(1), MP2Key(1)]
    public long Length { get; set; }

    [MPKey(2), MP2Key(2)]
    public string? FileId { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? FileRelativePath { get; set; }

    bool IExplicitHasValue.ExplicitHasValue()
    {
        return !string.IsNullOrWhiteSpace(SHA256) &&
            !string.IsNullOrWhiteSpace(FileId) &&
            Length > 0;
    }
}