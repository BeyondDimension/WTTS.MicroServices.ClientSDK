using static BD.WTTS.ApiConstants;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 脚本
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ScriptDTO
#if MVVM_VM
        : BaseNotifyPropertyChanged
#endif
{
#if MVVM_VM

    public ScriptDTO()
    {
        this.WhenAnyValue(x => x.IsUpdate, c => c.IsLoading, v => v.IsExist)
            .Subscribe(_ =>
            {
                this.RaisePropertyChanged(nameof(DownloadLoading));
                this.RaisePropertyChanged(nameof(DownloadButtonLoading));
            });
    }

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool IsBasics { get; set; } = false;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string FilePath { get; set; } = string.Empty;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string CachePath { get; set; } = string.Empty;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? FileName => Path.GetFileName(FilePath);

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? JsPathUrl { get; set; }

    private bool _IsUpdate;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool IsUpdate
    {
        get => _IsUpdate;
        set => this.RaiseAndSetIfChanged(ref _IsUpdate, value);
    }

    private bool _IsExist;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool IsExist
    {
        get => _IsExist;
        set => this.RaiseAndSetIfChanged(ref _IsExist, value);
    }

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool DownloadLoading => !IsUpdate && IsLoading;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool DownloadButtonLoading => !IsExist && !DownloadLoading;

    private bool _IsLoading;

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool IsLoading
    {
        get => _IsLoading;
        set => this.RaiseAndSetIfChanged(ref _IsLoading, value);
    }

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? NewVersion { get; set; }

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public DateTimeOffset? UpdateTime { get; set; }

#endif

    [MPIgnore, MP2Ignore]
    [N_JsonIgnore]
    [S_JsonIgnore]
    public int LocalId { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string Name
#if MVVM_VM
    {
        get => _Name;
        set => this.RaiseAndSetIfChanged(ref _Name, value);
    }

    string _Name
#else
    { get; set; }
#endif
 = string.Empty;

    /// <summary>
    /// 脚本作者
    /// </summary>
    [MPKey(1), MP2Key(1)]

    public string? AuthorName { get; set; }

    /// <summary>
    /// 版本号
    /// </summary>
    [MPKey(2), MP2Key(2)]
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

    /// <summary>
    /// 源链接
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string SourceLink { get; set; } = string.Empty;

    /// <summary>
    /// 下载链接
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string DownloadLink { get; set; } = string.Empty;

    /// <summary>
    /// 更新链接
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public string UpdateLink
#if MVVM_VM
    {
        get => _UpdateLink;
        set => this.RaiseAndSetIfChanged(ref _UpdateLink, value);
    }

    string _UpdateLink
#else
    { get; set; }
#endif
= string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public string? Describe { get; set; }

    /// <summary>
    /// 匹配域名数组
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public string MatchDomainNames { get; set; } = string.Empty;

    string? mMatchDomainNames;
    string[]? mMatchDomainNamesArray;
    readonly object mMatchDomainNamesArrayLock = new();

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[] MatchDomainNamesArray
        => GetSplitValues(mMatchDomainNamesArrayLock, MatchDomainNames, ref mMatchDomainNames, ref mMatchDomainNamesArray);

    /// <summary>
    /// 是否默认禁用
    /// </summary>
    [MPKey(8), MP2Key(8)]
    public bool Disable
#if MVVM_VM
    {
        get => mDisable;
        set => this.RaiseAndSetIfChanged(ref mDisable, value);
    }

    bool mDisable;
#else
    { get; set; }
#endif

    /// <summary>
    /// 脚本图标地址
    /// </summary>
    [MPKey(9), MP2Key(9)]
    public string? IconUrl { get; set; }

    /// <summary>
    /// 依赖油猴 GreasyFork 函数
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public bool DependentGreasyForkFunction { get; set; }

    /// <summary>
    /// 排除域名数组，分号分割多个
    /// </summary>
    [MPKey(11), MP2Key(11)]
    public string ExcludeDomainNames { get; set; } = string.Empty;

    string? mExcludeDomainNames;
    string[]? mExcludeDomainNamesArray;
    readonly object mExcludeDomainNamesArrayLock = new();

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[]? ExcludeDomainNamesArray
        => ExcludeDomainNames == null ? null : GetSplitValues(mExcludeDomainNamesArrayLock, ExcludeDomainNames, ref mExcludeDomainNames, ref mExcludeDomainNamesArray);

    [MPKey(12), MP2Key(12)]
    public List<Guid>? AccelerateProjects { get; set; }

    /// <summary>
    /// 依赖外部 JS，分号分割多个
    /// </summary>
    [MPKey(13), MP2Key(13)]
    public string? RequiredJs { get; set; }

    string? mRequiredJs;
    string[]? mRequiredJsArray;
    readonly object mRequiredJsArrayLock = new();

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string[]? RequiredJsArray
        => RequiredJs == null ? null : GetSplitValues(mRequiredJsArrayLock, RequiredJs, ref mRequiredJs, ref mRequiredJsArray);

    [MPKey(14), MP2Key(14)]
    public Guid? Id { get; set; }

    [MPKey(15), MP2Key(15)]
    public long Order { get; set; }

    [MPKey(16), MP2Key(16)]
    public bool IsCompile { get; set; }
}

partial class ScriptDTO : IDescribe
{

}