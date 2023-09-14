// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleActivityDetailDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string ActivityName { get; set; } = "";

    [MPKey(2), MP2Key(2)]
    public string? Describe { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? CoverUrl { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? BackgroundImg { get; set; }

    [MPKey(5), MP2Key(5)]
    public DateTimeOffset StartTime { get; set; }

    [MPKey(6), MP2Key(6)]
    public DateTimeOffset EndTime { get; set; }

    [MPKey(7), MP2Key(7)]
    public bool Recalibration { get; set; }

    [MPKey(8), MP2Key(8)]
    public string ActivityRules { get; set; } = "";

    [MPKey(9), MP2Key(9)]
    public string RewardRules { get; set; } = "";

    [MPKey(10), MP2Key(10)]
    public ActivityType ActivityType { get; set; }

    [MPKey(11), MP2Key(11)]
    public DateTimeOffset RaffleOpeningTime { get; set; }

    [MPKey(12), MP2Key(12)]
    public DateTimeOffset RaffleRevealTime { get; set; }

    /// <summary>
    /// 奖品列表
    /// </summary>
    [MPKey(13), MP2Key(13)]
    public RaffleActivityPrizeDTO[]? Prizes { get; set; }

    /// <summary>
    /// 条件列表
    /// </summary>
    [MPKey(14), MP2Key(14)]
    public RaffleConditionDTO[]? Conditions { get; set; }
}
