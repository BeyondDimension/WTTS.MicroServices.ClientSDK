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
    const string HomepageURL = "HomepageURL";
    const string DownloadURL = "DownloadURL";
    const string UpdateURL = "UpdateURL";
    const string Exclude = "Exclude";
    const string Grant = "Grant";
    const string Require = "Require";
    const string Include = "Include";
    const string DescRegex = @"(?<={0})[\s\S]*?(?=\n)";

    public ScriptDTO()
    {
        this.WhenAnyValue(x => x.IsUpdate, c => c.IsLoading, v => v.IsExist)
            .Subscribe(_ =>
            {
                this.RaisePropertyChanged(nameof(DownloadLoading));
                this.RaisePropertyChanged(nameof(DownloadButtonLoading));
            });
    }

    public static bool TryParse(string path, [NotNullWhen(true)] out ScriptDTO? proxyScript)
    {
        var content = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(content))
        {
            var userScript = content.Substring("==UserScript==", "==/UserScript==");
            if (!string.IsNullOrEmpty(userScript))
            {
                var script = new ScriptDTO
                {
                    FilePath = path,
                    Content = content.Replace("</script>", "<\\/script>"),
                    //Content = content.Replace("</script>", "<\\/script>").Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", ""),
                    Name = Regex.Match(userScript, string.Format(DescRegex, "@Name"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    //NameSpace = Regex.Matches(userScript, string.Format(DescRegex, $"@NameSpace"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true).ToArray(),
                    Version = Regex.Match(userScript, string.Format(DescRegex, "@Version"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    Describe = Regex.Match(userScript, string.Format(DescRegex, "@Description"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    AuthorName = Regex.Match(userScript, string.Format(DescRegex, "@Author"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    SourceLink = Regex.Match(userScript, string.Format(DescRegex, "@HomepageURL"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    //SupportURL = Regex.Match(userScript, string.Format(DescRegex, $"@SupportURL"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    DownloadLink = Regex.Match(userScript, string.Format(DescRegex, $"@{DownloadURL}"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    UpdateLink = Regex.Match(userScript, string.Format(DescRegex, $"@{UpdateURL}"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true),
                    ExcludeDomainNames = string.Join(GeneralSeparator, Regex.Matches(userScript, string.Format(DescRegex, $"@{Exclude}"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true)),
                    DependentGreasyForkFunction = Regex.Matches(userScript, string.Format(DescRegex, $"@{Grant}"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true).Any_Nullable(),
                    RequiredJs = string.Join(GeneralSeparator, Regex.Matches(userScript, string.Format(DescRegex, $"@{Require}"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true)),
                };
                var matchs = string.Join(GeneralSeparator, Regex.Matches(userScript, string.Format(DescRegex, $"@Match"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true));
                var includes = string.Join(GeneralSeparator, Regex.Matches(userScript, string.Format(DescRegex, $"@{Include}"), RegexOptions.IgnoreCase).GetValues(s => s.Success == true));
                script.MatchDomainNames = string.IsNullOrEmpty(matchs) ? includes : matchs;
                // 忽略脚本 Enable 启动标签默认启动
                //var enable = Regex.Match(userScript, string.Format(DescRegex, "@Enable"), RegexOptions.IgnoreCase).GetValue(s => s.Success == true);
                script.Disable = true;
                //script.Enable = bool.TryParse(enable, out var e) && e;
                proxyScript = script;
                return true;
            }
        }
        proxyScript = null;
        return false;
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
    public string Content { get; set; } = string.Empty;

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