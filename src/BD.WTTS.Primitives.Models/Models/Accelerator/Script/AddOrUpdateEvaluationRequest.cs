// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 新增或修改脚本评价
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class AddOrUpdateEvaluationRequest
{
    [MPKey(0), MP2Key(0)]
    public Guid? Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid ScriptId { get; set; }

    [MPKey(2), MP2Key(2)]
    public byte Rate { get; set; }

    [MPKey(3), MP2Key(3)]
    public string Content { get; set; } = string.Empty;

    [MPKey(4), MP2Key(4)]
    public Visibility Visibility { get; set; }
}
