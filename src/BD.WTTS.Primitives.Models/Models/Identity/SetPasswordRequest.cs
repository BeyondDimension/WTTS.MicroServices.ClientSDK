// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 设置登录密码
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class SetPasswordRequest
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? SmsCode { get; set; }

    /// <summary>
    /// 当前密码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? CurrentPassword { get; set; }

    /// <summary>
    /// 新密码
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 确认新密码
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string Password2 { get; set; } = string.Empty;
}