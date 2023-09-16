// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleActivityDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string ActivityName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string? Describe { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? CoverUrl { get; set; }

    [MPKey(4), MP2Key(4)]
    public DateTimeOffset StartTime { get; set; }

    [MPKey(5), MP2Key(5)]
    public DateTimeOffset EndTime { get; set; }

    [MPKey(6), MP2Key(6)]
    public ActivityType ActivityType { get; set; }

    [MPKey(7), MP2Key(7)]
    public DateTimeOffset RaffleOpeningTime { get; set; }

    [MPKey(8), MP2Key(8)]
    public DateTimeOffset? RaffleRevealTime { get; set; }

    [MPKey(9), MP2Key(9)]
    public DateTimeOffset? RaffleRevealEndTime { get; set; }

}
