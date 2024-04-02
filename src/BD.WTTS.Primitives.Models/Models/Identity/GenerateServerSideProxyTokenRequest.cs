namespace BD.WTTS.Models.Identity;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GenerateServerSideProxyTokenRequest
{
    [MPKey(0), MP2Key(0)]
    public string? LocalMACAddress { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? RequestIPAddress { get; set; }
}