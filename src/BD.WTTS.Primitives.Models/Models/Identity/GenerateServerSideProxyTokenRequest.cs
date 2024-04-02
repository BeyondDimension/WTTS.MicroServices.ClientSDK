namespace BD.WTTS.Models.Identity;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GenerateServerSideProxyTokenRequest
{
    [MPKey(0), MP2Key(0)]
    public string? LocalMACAddress { get; set; }
}