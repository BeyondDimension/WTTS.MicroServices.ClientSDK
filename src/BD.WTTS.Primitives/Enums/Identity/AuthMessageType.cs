// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 验证码类型
/// </summary>
public enum AuthMessageType : byte
{
    /// <summary>
    /// 邮箱地址（邮箱验证码）
    /// </summary>
    Email = 100,

    /// <summary>
    /// 手机号码（短信验证码）
    /// </summary>
    PhoneNumber = 102,
}
