namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameTagResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Name { get; set; } = string.Empty;
}
