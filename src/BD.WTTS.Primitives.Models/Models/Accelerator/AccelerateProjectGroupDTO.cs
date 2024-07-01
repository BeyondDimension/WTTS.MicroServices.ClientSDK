// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 加速项目组
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class AccelerateProjectGroupDTO
#if MVVM_VM
    : BaseNotifyPropertyChanged
#endif
{
    string DebuggerDisplay => $"{Name}, {IconUrl}";

#if MVVM_VM
    public AccelerateProjectGroupDTO()
    {
        this.WhenAnyValue(x => x.Items)
              .Subscribe(s =>
              {
                  if (s.Any_Nullable())
                      ObservableItems = new ObservableCollection<AccelerateProjectDTO>(s);
              });

        this.WhenAnyValue(v => v.ObservableItems)
              .Subscribe(items => items?
                    .ToObservableChangeSet()
                    .AutoRefresh(x => x.ThreeStateEnable)
                    .WhenValueChanged(x => x.ThreeStateEnable)
                    .Subscribe(_ =>
                    {
                        bool? b = null;
                        var count = items.Count(s => s.ThreeStateEnable is true);
                        if (!items.Any_Nullable() || count == 0)
                            b = false;
                        else if (count == items.Count)
                            b = true;

                        if (ThreeStateEnable != b)
                        {
                            mThreeStateEnable = b;
                            this.RaisePropertyChanged(nameof(ThreeStateEnable));
                        }
                    }));
    }

    private ObservableCollection<AccelerateProjectDTO>? _ObservableItems;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public ObservableCollection<AccelerateProjectDTO>? ObservableItems
    {
        get => _ObservableItems;
        set => this.RaiseAndSetIfChanged(ref _ObservableItems, value);
    }

    /// <summary>
    /// 是否有子项目选中的第三状态（仅客户端）
    /// </summary>
    bool? mThreeStateEnable = false;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool? ThreeStateEnable
    {
        get => mThreeStateEnable;
        set
        {
            mThreeStateEnable = value;
            Checked = mThreeStateEnable == true;
            if (Items != null)
                foreach (var item in Items)
                    if (item.ThreeStateEnable != Checked)
                        item.ThreeStateEnable = Checked;
            this.RaisePropertyChanged();
        }
    }
#endif

    /// <summary>
    /// 名称
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 当前组中所有的加速项目集合
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public List<AccelerateProjectDTO>? Items
#if MVVM_VM
    {
        get => mItems;
        set => this.RaiseAndSetIfChanged(ref mItems, value);
    }

    List<AccelerateProjectDTO>? mItems;
#else
    { get; set; } = new();
#endif

    /// <summary>
    /// 图标 Url
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string? IconUrl { get; set; }

    /// <summary>
    /// 是否选中
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public bool Checked
#if MVVM_VM
    {
        get => mChecked;
        set => this.RaiseAndSetIfChanged(ref mChecked, value);
    }

    bool mChecked;
#else
    { get; set; }
#endif

    /// <summary>
    /// 排序
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public long Order { get; set; }

}