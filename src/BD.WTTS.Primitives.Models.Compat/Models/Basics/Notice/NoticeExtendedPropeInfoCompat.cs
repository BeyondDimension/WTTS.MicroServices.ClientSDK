// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class NoticeExtendedPropeInfoCompat
{
    /// <summary>
    /// 字体粗细
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public FontWeight FontWeight { get; set; }

    /// <summary>
    /// 字体颜色 
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public uint FontColor { get; set; }

    /// <summary>
    /// 对齐方式
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public FontAlign FontAlign { get; set; } = FontAlign.Left;

    /// <summary>
    /// 下划线 or 删除线
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public FontDecoration FontDecoration { get; set; } = FontDecoration.None;
}