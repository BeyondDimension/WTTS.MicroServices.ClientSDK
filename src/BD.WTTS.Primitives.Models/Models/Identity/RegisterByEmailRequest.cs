// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 账号注册（通过邮箱）接口请求模型
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class RegisterByEmailRequest : IDeviceId
{
    [MPKey(0), MP2Key(0)]
    public string Email { get; set; } = string.Empty;

    [MPKey(1), MP2Key(1)]
    public string Password { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string Code { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public Guid DeviceIdG { get; set; }

    [MPKey(4), MP2Key(4)]
    public string? DeviceIdR { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? DeviceIdN { get; set; }
}