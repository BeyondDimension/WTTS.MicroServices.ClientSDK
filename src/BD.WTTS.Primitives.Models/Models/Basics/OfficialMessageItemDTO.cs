namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class OfficialMessageItemDTO
#if MVVM_VM
    : BaseNotifyPropertyChanged
#endif
{
#if MVVM_VM
    private bool _Unread;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool Unread
    {
        get => _Unread;
        set => this.RaiseAndSetIfChanged(ref _Unread, value);
    }
#endif

    /// <summary>
    /// 标题
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 内容
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 消息链接
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? MessageLink { get; set; }

    /// <summary>
    /// 推送时间/消息日期
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public DateTimeOffset PushTime { get; set; }
}