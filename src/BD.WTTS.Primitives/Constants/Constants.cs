// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class Constants
{
    /// <summary>
    /// 当前应用程序的硬编码名称，此值不可更改！
    /// <para></para>
    /// 通常用于文件，文件夹名，等不可变值。
    /// <para></para>
    /// 可更变名称的值为 AssemblyInfo.Trademark
    /// </summary>
    public const string HARDCODED_APP_NAME = "Steam++";

    /// <inheritdoc cref="HARDCODED_APP_NAME"/>
    public const string HARDCODED_APP_NAME_NEW = "WattToolkit";

    public const string CERTIFICATE_TAG = "#Steam++";

    public const string APP_LIST_FILE = "apps.json";

    public const string AUTHDATA_FILE = "authenticators.dat";

    public const string SCRIPT_DIR = "scripts";

    public const string LOGS_DIR = "logs";

    public const string CUSTOM_URL_SCHEME_NAME = "spp";

    public const string CUSTOM_URL_SCHEME = $"{CUSTOM_URL_SCHEME_NAME}://";

    /// <summary>
    /// 简体中文的区域性名称。
    /// </summary>
    public const string CultureName_SimplifiedChinese = "zh-Hans";
    public const string CultureName_TraditionalChinese = "zh-Hant";
    public const string CultureName_Chinese = "zh";
    public const string CultureName_China = "zh-CN";
    public const string CultureName_China_HongKong = "zh-HK";
    public const string CultureName_China_Taiwan = "zh-TW";

    public const string CultureName_English = "en";
    public const string CultureName_USA = "en-US";
    public const string CultureName_UK = "en-UK";

    public const string CultureName_Korean = "ko";

    public const string CultureName_Japanese = "ja";

    public const string CultureName_Russian = "ru";

    public const string CultureName_Spanish = "es";

    public const string CultureName_Italian = "it";

    public const string CultureName_Polish = "pl";

    public static string[] GetSupportedCultures()
    {
        // https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/localization/select-language-culture?view=aspnetcore-7.0#configure-localization-middleware
        var supportedCultures = new[]
        {
            CultureName_China,
            CultureName_China_HongKong,
            CultureName_China_Taiwan,
            CultureName_Chinese,
            CultureName_Russian,
            CultureName_Korean,
            CultureName_Japanese,
            CultureName_USA,
            CultureName_UK,
            CultureName_English,
            CultureName_Polish,
        };
        return supportedCultures;
    }
}
