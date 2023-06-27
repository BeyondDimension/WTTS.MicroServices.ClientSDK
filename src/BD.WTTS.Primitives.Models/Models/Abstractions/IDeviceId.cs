// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

public interface IDeviceId
{
    /// <summary>
    /// 首次启动生成的设备标识符
    /// </summary>
    Guid DeviceIdG { get; set; }

    /// <inheritdoc cref="DeviceIdG"/>
    string? DeviceIdR { get; set; }

    /// <inheritdoc cref="DeviceIdG"/>
    string? DeviceIdN { get; set; }
}

#if !MVVM_VM
public static partial class DeviceIdExtensions
{
    public static string? GetDeviceId(this IDeviceId deviceId)
    {
        if (deviceId.DeviceIdG != default && DeviceIdHelper.IsDeviceIdR(deviceId.DeviceIdR) &&
            DeviceIdHelper.IsDeviceIdN(deviceId.DeviceIdN))
        {
            var r = ShortGuid.Encode(deviceId.DeviceIdG) + deviceId.DeviceIdR + deviceId.DeviceIdN;
            return r;
        }
        return null;
    }
}
#endif