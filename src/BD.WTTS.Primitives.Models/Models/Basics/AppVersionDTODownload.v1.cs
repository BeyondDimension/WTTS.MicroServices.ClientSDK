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
}