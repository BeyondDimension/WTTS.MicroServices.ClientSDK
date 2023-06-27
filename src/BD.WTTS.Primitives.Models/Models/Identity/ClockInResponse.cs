// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 签到响应
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ClockInResponse
{
    /// <summary>
    /// 经验值
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public uint Experience { get; set; }

    /// <summary>
    /// 体力值
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public int Strength { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public byte Level { get; set; }

    /// <summary>
    /// 下级经验
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public uint NextExperience { get; set; }
}