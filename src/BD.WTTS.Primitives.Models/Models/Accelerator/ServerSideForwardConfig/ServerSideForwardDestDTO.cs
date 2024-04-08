namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class ServerSideForwardDestDTO(
    [property: MPKey(0), MP2Key(0)] string Scheme,
    [property: MPKey(1), MP2Key(1)] string Host
    );