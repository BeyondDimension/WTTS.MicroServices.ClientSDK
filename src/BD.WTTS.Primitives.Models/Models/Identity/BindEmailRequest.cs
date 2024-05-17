// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 绑定邮箱
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BindEmailRequest
{
    /// <summary>
    /// 邮箱地址
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// 短信验证码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? SmsCode { get; set; } = string.Empty;
}