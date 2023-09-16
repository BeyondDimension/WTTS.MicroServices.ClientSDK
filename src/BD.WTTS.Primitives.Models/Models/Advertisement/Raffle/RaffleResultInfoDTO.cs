// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleResultInfoDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid PrizeId { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? PrizeName { get; set; }

    [MPKey(2), MP2Key(2)]
    public string? Remarks { get; set; }

    [MPKey(3), MP2Key(3)]
    public DateTimeOffset CreationTime { get; set; }
}
