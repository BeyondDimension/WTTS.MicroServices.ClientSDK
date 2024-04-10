namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class ServerSideForwardDestMappingDTO
{
    [MPConstructor, MP2Constructor]
    public ServerSideForwardDestMappingDTO(ServerSideForwardDestDTO from, ServerSideForwardDestDTO to)
    {
        From = from;
        To = to;
    }

    public ServerSideForwardDestMappingDTO() : this(new(string.Empty, string.Empty), new(string.Empty, string.Empty))
    {
    }

    [MPKey(0), MP2Key(0)]
    public ServerSideForwardDestDTO From { get; set; }

    [MPKey(1), MP2Key(1)]
    public ServerSideForwardDestDTO To { get; set; }
}