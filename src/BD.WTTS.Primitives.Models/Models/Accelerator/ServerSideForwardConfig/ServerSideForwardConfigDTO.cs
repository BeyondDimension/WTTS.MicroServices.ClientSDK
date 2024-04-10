namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class ServerSideForwardConfigDTO
{
    [MPKey(0), MP2Key(0)]
    public string Key { get; set; }

    [MPKey(1), MP2Key(1)]
    public string MatchPattern { get; set; }

    [MPKey(2), MP2Key(2)]
    public ServerSideForwardDestMappingDTO[] ForwardDestList { get; set; }

    [MPKey(3), MP2Key(3)]
    public UserType? AccessLevel { get; set; } = null;

    [MPKey(4), MP2Key(4)]
    public string? Remarks { get; set; }

    [MPConstructor, MP2Constructor]
    public ServerSideForwardConfigDTO(string key, string matchPattern, ServerSideForwardDestMappingDTO[] forwardDestList, UserType? accessLevel, string? remarks)
    {
        Key = key;
        MatchPattern = matchPattern;
        ForwardDestList = forwardDestList;
        AccessLevel = accessLevel;
        Remarks = remarks;
    }

    public ServerSideForwardConfigDTO() : this(string.Empty, string.Empty, Array.Empty<ServerSideForwardDestMappingDTO>(), null, null)
    {
    }
}