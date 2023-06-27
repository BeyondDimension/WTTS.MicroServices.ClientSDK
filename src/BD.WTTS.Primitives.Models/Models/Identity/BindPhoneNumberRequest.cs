// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 绑定手机号码
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class BindPhoneNumberRequest : IReadOnlyPhoneNumber, IReadOnlySmsCode
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? SmsCode { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? PhoneNumber { get; set; }
}