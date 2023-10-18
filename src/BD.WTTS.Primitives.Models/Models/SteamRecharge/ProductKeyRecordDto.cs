namespace BD.WTTS.Models;

/// <summary>
/// key 记录
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ProductKeyRecordDto
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Key { get; set; } = default!;

    [MPKey(2), MP2Key(2)]
    public string ProductName { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public string ProductDesc { get; set; } = string.Empty;

    [MPKey(4), MP2Key(4)]
    public decimal Amount { get; set; }

    [MPKey(5), MP2Key(5)]
    public bool IsUsed { get; set; }

    [MPKey(6), MP2Key(6)]
    public bool Disable { get; set; }

    [MPKey(7), MP2Key(7)]
    public DateTimeOffset CreationTime { get; set; }

    [MPKey(8), MP2Key(8)]
    public DateTimeOffset? UsageTime { get; set; }
}
