namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameSubResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string SubName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public BillingType BillingType { get; set; }

    [MPKey(3), MP2Key(3)]
    public LicenseType LicenseType { get; set; }

    [MPKey(4), MP2Key(4)]
    public DateTime? ReleaseDateTime { get; set; }

    [MPKey(5), MP2Key(5)]
    public List<GamePriceResponse>? Prices { get; set; }
}
