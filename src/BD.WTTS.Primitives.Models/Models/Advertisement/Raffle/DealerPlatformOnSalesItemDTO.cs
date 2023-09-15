// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class DealerPlatformOnSalesItemDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid DealerId { get; set; }

    [MPKey(1), MP2Key(1)]
    public string DealerGameId { get; set; } = string.Empty;
}
