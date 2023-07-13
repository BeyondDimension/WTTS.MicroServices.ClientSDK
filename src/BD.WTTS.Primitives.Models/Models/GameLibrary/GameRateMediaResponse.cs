namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameRateMediaResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid AgencyId { get; set; }

    [MPKey(1), MP2Key(1)]
    public string AgencyName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public decimal MetaRate { get; set; }

    [MPKey(3), MP2Key(3)]
    public decimal UserRate { get; set; }

    [MPKey(4), MP2Key(4)]
    public string Url { get; set; } = string.Empty;
}
