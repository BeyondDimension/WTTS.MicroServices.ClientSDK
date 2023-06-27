// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 登录或注册接口请求模型
/// </summary>
[GenerateTypeScript]
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class LoginOrRegisterRequest : IReadOnlyPhoneNumber, IReadOnlySmsCode, IDeviceId
{
    [MPKey(0), MP2Key(0)]
    public string? PhoneNumber { get; set; }

    [MPKey(1), MP2Key(1)]
    public string? SmsCode { get; set; }

    [MPKey(2), MP2Key(2)]
    public LoginChannel Channel { get; set; } = LoginChannel.Client;

    [MPKey(3), MP2Key(3)]
    public Guid DeviceIdG { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? DeviceIdR { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? DeviceIdN { get; set; }
}