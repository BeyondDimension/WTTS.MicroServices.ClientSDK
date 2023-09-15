// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleResultDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid UserId { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid PrizeId { get; set; }

    [MPKey(2), MP2Key(2)]
    public Guid ActivityId { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? UserNickName { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? PrizeName { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? ActivityName { get; set; }

    [MPKey(6), MP2Key(6)]
    public string? Remarks { get; set; }

    [MPKey(7), MP2Key(7)]
    public DateTimeOffset CreationTime { get; set; }
}
