// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 客户端版本提交请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVerSubmissionRequest
{
    /// <summary>
    /// 版本号
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Version { get; set; } = "";

    /// <summary>
    /// 版本说明
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string ReleaseNote { get; set; } = "";

    /// <summary>
    /// 客户端构建
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public List<AppVerBuildDTO> Builds { get; set; } = new();
}
