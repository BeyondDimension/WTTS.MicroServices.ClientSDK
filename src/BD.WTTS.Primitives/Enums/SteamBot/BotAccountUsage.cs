// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 账号用途
/// </summary>
[Flags]
public enum BotAccountUsage
{
    点数交易号 = 1 << 1,

    余额交易号 = 1 << 2,

    礼物交易号 = 1 << 3,

    饰品交易号 = 1 << 4,
}
