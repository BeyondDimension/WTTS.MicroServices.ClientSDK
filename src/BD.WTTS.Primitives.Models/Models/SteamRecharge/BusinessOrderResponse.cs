// ReSharper disable once CheckNamespace

namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BusinessOrderResponse
{
    /// <summary>
    /// 余额交易业务订单
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public BalanceTradeBusinessOrderDto? BalanceTradeBusinessOrder { get; set; }

    /// <summary>
    /// 礼品卡交易业务订单
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public GiftsCardBusinessOrderDto? GiftsCardBusinessOrder { get; set; }
}
