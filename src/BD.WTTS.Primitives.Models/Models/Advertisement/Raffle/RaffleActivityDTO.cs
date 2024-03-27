// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleActivityDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 游戏 Id
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public Guid? GameId { get; set; }

    /// <summary>
    /// 游戏 Id
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? GameName { get; set; }

    /// <summary>
    /// 活动名称
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string ActivityName { get; set; } = "";

    /// <summary>
    /// 封面 Url
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string? CoverUrl { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public DateTimeOffset StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public DateTimeOffset EndTime { get; set; }

    /// <summary>
    /// 活动类型
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public ActivityType ActivityType { get; set; }

    /// <summary>
    /// 开奖时间
    /// </summary>
    [MPKey(8), MP2Key(8)]
    public DateTimeOffset RaffleOpeningTime { get; set; }

    /// <summary>
    /// 中奖公示时间
    /// </summary>
    [MPKey(9), MP2Key(9)]
    public DateTimeOffset? RaffleRevealTime { get; set; }

    /// <summary>
    /// 中奖公示结束时间
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public DateTimeOffset? RaffleRevealEndTime { get; set; }
}