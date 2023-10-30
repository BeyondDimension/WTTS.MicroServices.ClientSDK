// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 交易报价 交易状态
/// </summary>
public enum QuotesTradingStatus : byte
{
    待发起 = 1,

    待接受 = 2,

    待确认 = 3,

    待完成 = 4,

    已失败 = 5,
}
