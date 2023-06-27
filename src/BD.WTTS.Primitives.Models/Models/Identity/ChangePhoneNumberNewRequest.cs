// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 换绑手机 - 绑定新手机号
/// <list type="bullet">
/// <item>【TextBox 输入新手机号码的短信验证码】</item>
/// <item>【Button 完成】</item>
/// </list>
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ChangePhoneNumberNewRequest : IReadOnlyPhoneNumber, IReadOnlySmsCode
{
    /// <summary>
    /// 要绑定的新手机号码
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 新手机号码的短信验证码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? SmsCode { get; set; }

    /// <summary>
    /// 上一个接口返回的 CODE
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? Code { get; set; }
}