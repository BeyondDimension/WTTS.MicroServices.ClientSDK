// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 客户端文件
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVerFileDTO
{
    /// <summary>
    /// 下载地址
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? DownloadUrl { get; set; }

    /// <summary>
    /// 下载方式
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public DownloadMethod DownloadMethod { get; set; }

    /// <summary>
    /// 下载渠道
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public UpdateChannelType DownloadChannel { get; set; }

    #region CloudFileInfo

    [MPKey(3), MP2Key(3)]
    public string? FileName { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? SHA256 { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? SHA384 { get; set; }

    [MPKey(6), MP2Key(6)]
    public string? FilePath { get; set; }

    [MPKey(7), MP2Key(7)]
    public string? FileExtension { get; set; }

    [MPKey(8), MP2Key(8)]
    public CloudFileType FileType { get; set; }

    [MPKey(9), MP2Key(9)]
    public long FileSize { get; set; }

    #endregion CloudFileInfo
}