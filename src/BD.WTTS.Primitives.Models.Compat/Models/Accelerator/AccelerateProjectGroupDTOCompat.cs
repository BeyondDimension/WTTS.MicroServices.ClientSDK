// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 加速项目组（旧版）
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class AccelerateProjectGroupDTOCompat
#if MVVM_VM
    : BaseNotifyPropertyChanged
#endif
{
    string DebuggerDisplay => $"{Name}, {ImageId}";

#if MVVM_VM
    public AccelerateProjectGroupDTOCompat()
    {
        this.WhenAnyValue(x => x.Items)
              .DistinctUntilChanged()
              .Subscribe(s =>
              {
                  if (s.Any_Nullable())
                      ObservableItems = new ObservableCollection<AccelerateProjectDTOCompat>(s);
              });

        this.WhenAnyValue(v => v.ObservableItems)
              .Subscribe(items => items?
                    .ToObservableChangeSet()
                    //.DistinctUntilChanged()
                    .AutoRefresh(x => x.Enable)
                    //.ToCollection()
                    //.Select<IReadOnlyCollection<AccelerateProjectDTO>, bool?>(x =>
                    //{
                    //    var count = x.Count(s => s.Enable);
                    //    if (x == null || count == 0)
                    //        return false;
                    //    if (count == x.Count)
                    //        return true;
                    //    return null;
                    //})
                    .WhenValueChanged(x => x.Enable)
                    .Subscribe(_ =>
                    {
                        bool? b = null;
                        var count = items.Count(s => s.Enable);
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

    private ObservableCollection<AccelerateProjectDTOCompat>? _ObservableItems;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public ObservableCollection<AccelerateProjectDTOCompat>? ObservableItems
    {
        get => _ObservableItems;
        set => this.RaiseAndSetIfChanged(ref _ObservableItems, value);
    }

    /// <summary>
    /// 显示图片，使用 System.Application.ImageUrlHelper.GetImageApiUrlById(Guid) 转换为Url
    /// </summary>
    private Task<string?>? _ImageStream;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public Task<string?>? ImageStream
    {
        get => _ImageStream;
        set => this.RaiseAndSetIfChanged(ref _ImageStream, value);
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
            Enable = mThreeStateEnable == true;
            if (Items != null)
                foreach (var item in Items)
                    if (item.Enable != Enable)
                        item.Enable = Enable;
            this.RaisePropertyChanged();
        }
    }
#endif

    /// <summary>
    /// 显示名称
    /// </summary>
    [MPKey(0), MP2Key(0)]
    [N_JsonProperty("0")]
    [S_JsonProperty("0")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 当前组中所有的加速项目集合
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [N_JsonProperty("1")]
    [S_JsonProperty("1")]
    public List<AccelerateProjectDTOCompat>? Items
#if MVVM_VM
    {
        get => mItems;
        set => this.RaiseAndSetIfChanged(ref mItems, value);
    }

    List<AccelerateProjectDTOCompat>? mItems;
#else
    { get; set; } = new();
#endif

    /// <summary>
    /// 显示图片，使用 ImageUrlHelper.GetImageApiUrlById(Guid) 转换为Url
    /// </summary>
    [MPKey(2), MP2Key(2)]
    [N_JsonProperty("2")]
    [S_JsonProperty("2")]
    public Guid ImageId { get; set; }

#if !MVVM_VM
    string? _IconUrl;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? IconUrl
    {
        get => _IconUrl;
        set
        {
            _IconUrl = value;
            ImageId = ImageUrlHelper.GetImageGuid(value);
        }
    }
#endif

    /// <summary>
    /// 是否默认启用
    /// </summary>
    [MPKey(3), MP2Key(3)]
    [N_JsonProperty("3")]
    [S_JsonProperty("3")]
    public bool Enable
#if MVVM_VM
    {
        get => mEnable;
        set => this.RaiseAndSetIfChanged(ref mEnable, value);
    }

    bool mEnable;
#else
    { get; set; }
#endif

    [MPKey(4), MP2Key(4)]
    [N_JsonProperty("4")]
    [S_JsonProperty("4")]
    public int Order { get; set; }
}
