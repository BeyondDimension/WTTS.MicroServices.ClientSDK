// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleResultItemDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid UserId { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid? PrizeId { get; set; }

    [MPKey(2), MP2Key(2)]
    public string? UserNickName { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? PrizeName { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? ParticipationNumber { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? ParticipationRemarks { get; set; }
}
