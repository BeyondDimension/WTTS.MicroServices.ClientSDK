// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class NoticeDTOCompat : IKeyModel<Guid>
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid? ContentId { get; set; }

    [MPKey(2), MP2Key(2)]
    public string Picture { get; set; } = string.Empty;

#if MVVM_VM
    [MPIgnore, MP2Ignore]
    public Task<ImageSource.ClipStream?>? PictureStream => ImageSource.GetAsync(Picture);
#endif

    [MPKey(3), MP2Key(3)]
    public string Title { get; set; } = string.Empty;

    [MPKey(4), MP2Key(4)]
    public string Author { get; set; } = string.Empty;

    [MPKey(5), MP2Key(5)]
    public string Introduction { get; set; } = string.Empty;

    [MPKey(6), MP2Key(6)]
    public DateTimeOffset CreationTime { get; set; }

    [MPKey(7), MP2Key(7)]
    public DateTimeOffset EnableTime { get; set; }

    [MPKey(8), MP2Key(8)]
    public bool IsOpenBrowser { get; set; }

    [MPKey(9), MP2Key(9)]
    public DateTimeOffset OverdueTime { get; set; }

    /// <summary>
    /// 通知渠道
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public NotificationType Type { get; set; } = NotificationType.Announcement;

    [MPKey(11), MP2Key(11)]
    public string Url { get; set; } = string.Empty;

    [MPKey(12), MP2Key(12)]
    public string? Context { get; set; } = string.Empty;

#if MVVM_VM
    /// <summary>
    /// 是否过期
    /// </summary> 
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool Overdue => DateTimeOffset.Now > OverdueTime;

    /// <summary>
    /// 是否已读
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    [Reactive]
    public bool HasRead { get; set; }
#endif
}
