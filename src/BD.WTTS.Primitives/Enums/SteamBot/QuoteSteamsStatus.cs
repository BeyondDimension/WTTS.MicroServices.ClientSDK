// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot  交易报价 Steam报价状态
/// </summary>
public enum QuoteSteamsStatus : byte
{
    无效报价 = 1,

    报价等待接受 = 2,

    报价已接受 = 3,

    报价被还价 = 4,

    报价已过期 = 5,

    报价已取消 = 6,

    报价被拒绝 = 7,

    报价物品无效 = 8,

    报价被暂挂 = 9,
}
