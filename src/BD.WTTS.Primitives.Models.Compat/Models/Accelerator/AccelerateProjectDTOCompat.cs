using static BD.WTTS.ApiConstants;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 加速项目（旧版）
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class AccelerateProjectDTOCompat
#if MVVM_VM
    : BaseNotifyPropertyChanged
#endif
{
    string DebuggerDisplay => $"{Name}, {DomainNames}";

#if MVVM_VM
    public AccelerateProjectDTOCompat()
    {
        this.WhenAnyValue(v => v)
              .Subscribe(x =>
              {
                  if (Items.Any_Nullable())
                  {
                      foreach (var item in Items)
                      {
                          item.Enable = x.Enable;
                      }
                  }
              });
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
    /// 端口号
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [N_JsonProperty("1")]
    [S_JsonProperty("1")]
    public ushort PortId { get; set; }

    /// <summary>
    /// 域名，分号分割多个
    /// </summary>
    [MPKey(2), MP2Key(2)]
    [N_JsonProperty("2")]
    [S_JsonProperty("2")]
    public string DomainNames { get; set; } = string.Empty;

    string? mDomainNames;
    string[]? mDomainNamesArray;
    readonly object mDomainNamesArrayLock = new();

    /// <inheritdoc cref="DomainNames"/>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[] DomainNamesArray
        => GetSplitValues(mDomainNamesArrayLock, DomainNames, ref mDomainNames, ref mDomainNamesArray);

    string? _ForwardDomainName;

    /// <summary>
    /// 转发域名
    /// </summary>
    [MPKey(3), MP2Key(3)]
    [N_JsonProperty("3")]
    [S_JsonProperty("3")]
    public string ForwardDomainName
    {
        get => _ForwardDomainName ?? string.Empty;
        set => _ForwardDomainName = value;
    }

    string? _ForwardDomainIP;

    /// <summary>
    /// 转发域名 IP
    /// </summary>
    [MPKey(4), MP2Key(4)]
    [N_JsonProperty("4")]
    [S_JsonProperty("4")]
    public string ForwardDomainIP
    {
        get => _ForwardDomainIP ?? string.Empty;
        set => _ForwardDomainIP = value;
    }

#if !MVVM_VM
    string? _ForwardDomainNames;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? ForwardDomainNames
    {
        get => _ForwardDomainNames;
        set
        {
            _ForwardDomainNames = value;
            if (!string.IsNullOrEmpty(value))
            {
                var values = GetSplitValues(value);
                if (IPAddress2.TryParse(values.FirstOrDefault(), out var _))
                {
                    ForwardDomainIP = value;
                }
                else
                {
                    ForwardDomainName = value;
                }
            }
        }
    }
#endif

    /// <summary>
    /// 转发是域名(<see langword="true"/>)还是域名IP(<see langword="false"/>)
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool ForwardDomainIsNameOrIP => string.IsNullOrEmpty(_ForwardDomainIP);

    /// <summary>
    /// 服务器名
    /// </summary>
    [MPKey(5), MP2Key(5)]
    [N_JsonProperty("5")]
    [S_JsonProperty("5")]
    public string ServerName { get; set; } = string.Empty;

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
    /// Host 域名集合
    /// </summary>
    [MPKey(7), MP2Key(7)]
    [N_JsonProperty("7")]
    [S_JsonProperty("7")]
    public string Hosts { get; set; } = string.Empty;

    string? mHosts;
    string[]? mHostsArray;
    readonly object mHostsArrayLock = new();

    /// <inheritdoc cref="Hosts"/>
    [MPIgnore, MP2Ignore]
    [N_JsonIgnore]
    [S_JsonIgnore]
    public string[] HostsArray
        => GetSplitValues(mHostsArrayLock, Hosts, ref mHosts, ref mHostsArray);

    /// <summary>
    /// 是否默认启用
    /// </summary>
    [MPKey(8), MP2Key(8)]
    [N_JsonProperty("8")]
    [S_JsonProperty("8")]
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

    [MPKey(9), MP2Key(9)]
    [N_JsonProperty("9")]
    [S_JsonProperty("9")]
    public Guid Id { get; set; }

    [MPKey(10), MP2Key(10)]
    [N_JsonProperty("10")]
    [S_JsonProperty("10")]
    public int Order { get; set; }

    [MPKey(11), MP2Key(11)]
    [N_JsonProperty("11")]
    [S_JsonProperty("11")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// 子级加速项目
    /// </summary>
    [MPKey(12), MP2Key(12)]
    [N_JsonProperty("12")]
    [S_JsonProperty("12")]
    public List<AccelerateProjectDTOCompat>? Items { get; set; }
}
