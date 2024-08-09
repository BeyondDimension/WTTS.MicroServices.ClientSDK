// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 插件分类DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginCategoryDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 分类编码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string CategoryCode { get; set; } = "";

    /// <summary>
    /// 分类名称
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string CategoryName { get; set; } = "";
}