// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 通知纪录
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[Obsolete("use NoticeDTO or NotificationBuilder")]
public sealed partial class NotificationRecordDTOCompat
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 通知标题
    /// <para>https://developer.android.google.cn/reference/androidx/core/app/NotificationCompat.Builder?hl=zh-cn#setContentTitle(java.lang.CharSequence)</para>
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 通知正文
    /// <para>https://developer.android.google.cn/reference/androidx/core/app/NotificationCompat.Builder?hl=zh-cn#setContentText(java.lang.CharSequence)</para>
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string Content { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public NotificationType Type { get; set; }

    /// <summary>
    /// 公告内容
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string? Announcement { get; set; }
}