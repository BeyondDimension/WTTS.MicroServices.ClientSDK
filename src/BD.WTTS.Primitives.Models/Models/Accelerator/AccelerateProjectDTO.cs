using static BD.WTTS.ApiConstants;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 加速项目
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class AccelerateProjectDTO
#if MVVM_VM
    : BaseNotifyPropertyChanged
#endif
{
#if MVVM_VM
    public AccelerateProjectDTO()
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
                  .AutoRefresh(x => x.Checked)
                  .WhenValueChanged(x => x.Checked)
                  .Subscribe(_ =>
                  {
                      bool? b = null;
                      var count = items.Count(s => s.Checked);
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
            Checked = mThreeStateEnable is null or true;
            if (Items != null)
                foreach (var item in Items)
                    if (item.ThreeStateEnable != Checked)
                        item.ThreeStateEnable = Checked;
            this.RaisePropertyChanged();
        }
    }
#endif

    string DebuggerDisplay => $"{Name}, {ForwardDomainNames}";

    /// <summary>
    /// 名称
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 端口号
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public ushort Port { get; set; }

    /// <summary>
    /// 匹配域名地址，分号分割多个
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string MatchDomainNames { get; set; } = string.Empty;

    string? mDomainNames;
    string[]? mDomainNamesArray;
    readonly object mDomainNamesArrayLock = new();

    /// <summary>
    /// 匹配域名地址数组
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[] DomainNamesArray
        => GetSplitValues(mDomainNamesArrayLock, MatchDomainNames, ref mDomainNames, ref mDomainNamesArray);

    string? _ForwardDomainName;

    /// <summary>
    /// 转发到域名地址
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string ForwardDomainNames
    {
        get => _ForwardDomainName ?? string.Empty;
        set => _ForwardDomainName = value;
    }

    /// <summary>
    /// 忽略 SSL 证书验证
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public bool IgnoreSSLCertVerification { get; set; }

    /// <summary>
    /// 伪装 ServerName
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public string? FakeServerName { get; set; }

    /// <summary>
    /// 代理类型
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public ProxyType ProxyType { get; set; }

    /// <summary>
    /// 启用重定向
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool Redirect
    {
        get => ProxyType == ProxyType.Redirect;
        set => ProxyType = value ? ProxyType.Redirect : default;
    }

    /// <summary>
    /// 监听域名，原 Hosts
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public string ListenDomainNames { get; set; } = string.Empty;

    string? LDomainNames;
    string[]? LDomainNamesArray;
    readonly object LDomainNamesArrayLock = new();

    /// <summary>
    /// 监听域名数组
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[] ListeningDomainNamesArray
        => GetSplitValues(LDomainNamesArrayLock, ListenDomainNames, ref LDomainNames, ref LDomainNamesArray);

    /// <summary>
    /// 是否选中
    /// </summary>
    [MPKey(8), MP2Key(8)]
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

    [MPKey(9), MP2Key(9)]
    public Guid Id { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public long Order { get; set; }

    /// <summary>
    /// 伪装 UserAgent
    /// </summary>
    [MPKey(11), MP2Key(11)]
    public string? FakeUserAgent { get; set; }

    /// <summary>
    /// 子级加速项目
    /// </summary>
    [MPKey(12), MP2Key(12)]
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
    /// 版本号
    /// </summary>
    [MPKey(13), MP2Key(13)]
    public string Version
#if MVVM_VM
    {
        get => _Version;
        set => this.RaiseAndSetIfChanged(ref _Version, value);
    }

    string _Version
#else
    { get; set; }
#endif
= string.Empty;
}
