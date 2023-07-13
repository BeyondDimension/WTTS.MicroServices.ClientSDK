namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameResourceResponse
{
    [MPKey(0), MP2Key(0)]
    public GameResourceType Type { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid StaticResourcesId { get; set; }

    [MPKey(2), MP2Key(2)]
    public string Url { get; set; } = string.Empty;
}
