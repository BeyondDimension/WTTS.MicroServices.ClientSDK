// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 发送邮箱验证码接口请求模型
/// </summary>
[GenerateTypeScript]
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class SendEmailCodeRequest
{
    [MPKey(0), MP2Key(0)]
    public string Email { get; set; } = string.Empty;

    [MPKey(1), MP2Key(1)]
    public SmsCodeType Type { get; set; }
}