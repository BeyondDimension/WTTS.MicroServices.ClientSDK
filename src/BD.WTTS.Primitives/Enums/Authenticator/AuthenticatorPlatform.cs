namespace BD.WTTS.Enums;

/// <summary>
/// 令牌平台
/// </summary>
public enum AuthenticatorPlatform : byte
{
    Steam = 1,

    Microsoft = 5,

    BattleNet = 11,

    Google = 12,

    HOTP = 13,
}
