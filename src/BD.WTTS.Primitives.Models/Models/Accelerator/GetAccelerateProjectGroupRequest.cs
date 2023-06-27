// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 获取加速项目分组请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class GetAccelerateProjectGroupRequest
{
    /// <summary>
    /// 时间占位符
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;

    [MPKey(1), MP2Key(1)]
    public AdvertisementType? ADType { get; set; }

    [MPKey(2), MP2Key(2)]
    public Platform Platform { get; set; }
#if MVVM_VM
        = DeviceInfo2.Platform();
#endif

    [MPKey(3), MP2Key(3)]
    public DeviceIdiom DeviceIdiom { get; set; }
#if MVVM_VM
        = DeviceInfo2.Idiom();
#endif

    [MPKey(4), MP2Key(4)]
    public byte Version { get; set; }
}
