#if !MVVM_VM
namespace BD.WTTS.Helpers;

/// <summary>
/// 用于匿名统计的设备 Id 生成助手类
/// </summary>
public static partial class DeviceIdHelper
{
    public static bool IsDeviceIdR(string? value)
        => value != null && value.Length == DeviceIdRLength && value.All(x => String2.DigitsLetters.Contains(x));

    public static bool IsDeviceIdN(string? value)
        => value != null && value.Length == Hashs.String.Lengths.SHA256 && value.All(x => (String2.UpperCaseLetters + String2.Digits).Contains(x));
}
#endif