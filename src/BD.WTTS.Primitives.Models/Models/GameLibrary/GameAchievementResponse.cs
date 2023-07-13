namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameAchievementResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Name { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string? Describe { get; set; }

    [MPKey(3), MP2Key(3)]
    public string UnlockCondition { get; set; } = string.Empty;

    [MPKey(4), MP2Key(4)]
    public string Url { get; set; } = string.Empty;
}
