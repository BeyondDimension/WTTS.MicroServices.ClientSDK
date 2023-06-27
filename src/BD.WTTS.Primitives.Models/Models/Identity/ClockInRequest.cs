// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 签到请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ClockInRequest
{
    /// <summary>
    /// 当前创建时间，仅用来验证时间差
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public DateTimeOffset CreationTime { get; set; }
}