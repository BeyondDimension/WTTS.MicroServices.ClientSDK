namespace BD.WTTS.Enums;

/// <summary>
/// 用户令牌值类型
/// </summary>
public enum UserAuthenticatorTokenType : byte
{
    /// <summary>
    /// 生成一个基于时间的密码，它在每隔30秒钟左右就会更改
    /// </summary>
    TOTP = 1,

    /// <summary>
    /// 基于计数器的，每次使用后，计数器会递增，并生成下一个密码
    /// </summary>
    HOTP = 2,
}
