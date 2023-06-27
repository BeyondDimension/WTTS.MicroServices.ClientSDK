// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 刷新 JWT 请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class RefreshTokenRequest : IDeviceId
{
    [MPKey(0), MP2Key(0)]
    public string? RefreshToken { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid DeviceIdG { get; set; }

    [MPKey(2), MP2Key(2)]
    public string? DeviceIdR { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? DeviceIdN { get; set; }
}
