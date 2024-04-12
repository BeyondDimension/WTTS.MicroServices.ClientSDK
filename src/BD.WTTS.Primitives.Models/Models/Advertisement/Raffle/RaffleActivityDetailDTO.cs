// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleActivityDetailDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string ActivityName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string? GameStoreLink { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? BackgroundImg { get; set; }

    [MPKey(4), MP2Key(4)]
    public DateTimeOffset StartTime { get; set; }

    [MPKey(5), MP2Key(5)]
    public DateTimeOffset EndTime { get; set; }

    [MPKey(6), MP2Key(6)]
    public bool Recalibration { get; set; }

    [MPKey(7), MP2Key(7)]
    public string ActivityRules { get; set; } = string.Empty;

    [MPKey(8), MP2Key(8)]
    public string RewardRules { get; set; } = string.Empty;

    [MPKey(9), MP2Key(9)]
    public ActivityType ActivityType { get; set; }

    [MPKey(10), MP2Key(10)]
    public DateTimeOffset RaffleOpeningTime { get; set; }

    [MPKey(11), MP2Key(11)]
    public DateTimeOffset? RaffleRevealTime { get; set; }

    /// <summary>
    /// 奖品列表
    /// </summary>
    [MPKey(12), MP2Key(12)]
    public RaffleActivityPrizeDTO[]? Prizes { get; set; }

    /// <summary>
    /// 条件列表
    /// </summary>
    [MPKey(13), MP2Key(13)]
    public RaffleConditionDTO[]? Conditions { get; set; }

    [MPKey(14), MP2Key(14)]
    public string? DealerGameId { get; set; }

    [MPKey(15), MP2Key(15)]
    public Guid? GameId { get; set; }

    [MPKey(16), MP2Key(16)]
    public string? GameName { get; set; }

    [MPKey(17), MP2Key(17)]
    public Guid? GamePlatformId { get; set; }

    [MPKey(18), MP2Key(18)]
    public string? GamePlatformName { get; set; }

    [MPKey(19), MP2Key(19)]
    public DateTimeOffset? RaffleRevealEndTime { get; set; }

    [MPKey(20), MP2Key(20)]
    public List<PrizeLevelItemDTO> PrizeLevelSetting { get; set; } = new();
}
