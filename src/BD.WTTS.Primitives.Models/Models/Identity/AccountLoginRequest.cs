// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 账号密码登录接口请求模型
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class AccountLoginRequest : IDeviceId
{
    /// <summary>
    /// 用户名/手机号码/邮箱
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? Account { get; set; }

    /// <summary>
    /// 登录密码
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? Password { get; set; }

    [MPKey(2), MP2Key(2)]
    public LoginChannel Channel { get; set; } = LoginChannel.Client;

    [MPKey(3), MP2Key(3)]
    public Guid DeviceIdG { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? DeviceIdR { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? DeviceIdN { get; set; }
}
