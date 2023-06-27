// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 换绑手机 - 安全验证
/// <list type="bullet">
/// <item>【Lable 当前用户的手机号 中间四位隐藏】</item>
/// <item>【TextBox 输入短信验证码】【Button 获取验证码】</item>
/// <item>【TextBox 输入新的手机号码】</item>
/// <item>【Button 提交】</item>
/// </list>
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ChangePhoneNumberValidationRequest : IReadOnlySmsCode, IReadOnlyPhoneNumber
{
    /// <summary>
    /// 当前手机号的短信验证码
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? SmsCode { get; set; }

    /// <summary>
    /// 要绑定的新手机号码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? PhoneNumber { get; set; }
}