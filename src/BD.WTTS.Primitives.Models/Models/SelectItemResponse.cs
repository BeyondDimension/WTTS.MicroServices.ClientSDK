// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class SelectItemResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Value { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Label { get; set; } = string.Empty;
}