// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class PrizeLevelItemDTO
{
    [MPKey(0), MP2Key(0)]
    public byte Level { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Title { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public float Probability { get; set; }
}