namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class ServerSideForwardDestMappingDTO
{
    public ServerSideForwardDestMappingDTO(ServerSideForwardDestDTO from, ServerSideForwardDestDTO to)
    {
        From = from;
        To = to;
    }

    [MPKey(0), MP2Key(0)]
    public ServerSideForwardDestDTO From { get; set; }

    [MPKey(1), MP2Key(1)]
    public ServerSideForwardDestDTO To { get; set; }
}