// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// V1版本
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class AppVersionDTODownloadV1 : AppVersionDTODownload
{
    /// <summary>
    /// 是否增量更新
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public bool IncrementalUpdate => ApplicableAppVerId.HasValue;
}