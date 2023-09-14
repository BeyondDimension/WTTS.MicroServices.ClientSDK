// ReSharper disable once CheckNamespace

namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BusinessOrderResponse
{
    [MPKey(0), MP2Key(0)]
    public BalanceTradeBusinessOrderDto? BalanceTradeBusinessOrder { get; set; }

    [MPKey(1), MP2Key(1)]
    public GiftsCardBusinessOrderDto? GiftsCardBusinessOrder { get; set; }
}
