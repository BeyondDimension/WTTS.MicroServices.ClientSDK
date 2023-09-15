// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class RaffleConditionDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Name { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string? Describe { get; set; }

    [MPKey(3), MP2Key(3)]
    public ConditionType ConditionType { get; set; }

    [MPKey(4), MP2Key(4)]
    [Required]
    public string LimitationValue { get; set; } = string.Empty;
}
