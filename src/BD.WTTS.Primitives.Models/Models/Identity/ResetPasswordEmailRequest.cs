// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 重置密码接口请求模型
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ResetPasswordRequest
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public AuthMessageType Type { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 邮件地址
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? Email { get; set; }

    /// <summary>
    /// 验证码
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string OTPCode { get; set; } = string.Empty;

    /// <summary>
    /// 新密码
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 确认新密码
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public string Password2 { get; set; } = string.Empty;
}