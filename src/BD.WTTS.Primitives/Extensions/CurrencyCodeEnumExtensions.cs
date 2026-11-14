// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class CurrencyCodeEnumExtensions
{
    /// <summary>
    /// 将 货币类型/货币种类 转换为中文名称
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string ToChineseString(this CurrencyCode currencyCode)
    {
        var key = CurrencyNameResourceKey(currencyCode);
        return key == null ? currencyCode.ToString() :
            R.Strings.ResourceManager.GetString(key, CultureInfo.InvariantCulture) ?? currencyCode.ToString();
    }

    static string? CurrencyNameResourceKey(CurrencyCode currencyCode) => currencyCode switch
    {
        CurrencyCode.AED => nameof(R.Strings.L10nSdk_Currency_AED),
        CurrencyCode.ARS => nameof(R.Strings.L10nSdk_Currency_ARS),
        CurrencyCode.AUD => nameof(R.Strings.L10nSdk_Currency_AUD),
        CurrencyCode.BRL => nameof(R.Strings.L10nSdk_Currency_BRL),
        CurrencyCode.CAD => nameof(R.Strings.L10nSdk_Currency_CAD),
        CurrencyCode.CHF => nameof(R.Strings.L10nSdk_Currency_CHF),
        CurrencyCode.CLP => nameof(R.Strings.L10nSdk_Currency_CLP),
        CurrencyCode.CNY => nameof(R.Strings.L10nSdk_Currency_CNY),
        CurrencyCode.COP => nameof(R.Strings.L10nSdk_Currency_COP),
        CurrencyCode.CRC => nameof(R.Strings.L10nSdk_Currency_CRC),
        CurrencyCode.EUR => nameof(R.Strings.L10nSdk_Currency_EUR),
        CurrencyCode.GBP => nameof(R.Strings.L10nSdk_Currency_GBP),
        CurrencyCode.HKD => nameof(R.Strings.L10nSdk_Currency_HKD),
        CurrencyCode.IDR => nameof(R.Strings.L10nSdk_Currency_IDR),
        CurrencyCode.ILS => nameof(R.Strings.L10nSdk_Currency_ILS),
        CurrencyCode.INR => nameof(R.Strings.L10nSdk_Currency_INR),
        CurrencyCode.JPY => nameof(R.Strings.L10nSdk_Currency_JPY),
        CurrencyCode.KRW => nameof(R.Strings.L10nSdk_Currency_KRW),
        CurrencyCode.KWD => nameof(R.Strings.L10nSdk_Currency_KWD),
        CurrencyCode.KZT => nameof(R.Strings.L10nSdk_Currency_KZT),
        CurrencyCode.MXN => nameof(R.Strings.L10nSdk_Currency_MXN),
        CurrencyCode.MYR => nameof(R.Strings.L10nSdk_Currency_MYR),
        CurrencyCode.NOK => nameof(R.Strings.L10nSdk_Currency_NOK),
        CurrencyCode.NZD => nameof(R.Strings.L10nSdk_Currency_NZD),
        CurrencyCode.PEN => nameof(R.Strings.L10nSdk_Currency_PEN),
        CurrencyCode.PHP => nameof(R.Strings.L10nSdk_Currency_PHP),
        CurrencyCode.PLN => nameof(R.Strings.L10nSdk_Currency_PLN),
        CurrencyCode.QAR => nameof(R.Strings.L10nSdk_Currency_QAR),
        CurrencyCode.RUB => nameof(R.Strings.L10nSdk_Currency_RUB),
        CurrencyCode.SAR => nameof(R.Strings.L10nSdk_Currency_SAR),
        CurrencyCode.SGD => nameof(R.Strings.L10nSdk_Currency_SGD),
        CurrencyCode.THB => nameof(R.Strings.L10nSdk_Currency_THB),
        CurrencyCode.TRY => nameof(R.Strings.L10nSdk_Currency_TRY),
        CurrencyCode.TWD => nameof(R.Strings.L10nSdk_Currency_TWD),
        CurrencyCode.UAH => nameof(R.Strings.L10nSdk_Currency_UAH),
        CurrencyCode.USD => nameof(R.Strings.L10nSdk_Currency_USD),
        CurrencyCode.UYU => nameof(R.Strings.L10nSdk_Currency_UYU),
        CurrencyCode.VND => nameof(R.Strings.L10nSdk_Currency_VND),
        CurrencyCode.ZAR => nameof(R.Strings.L10nSdk_Currency_ZAR),
        CurrencyCode.BYN => nameof(R.Strings.L10nSdk_Currency_BYN),
        _ => null,
    };

    /// <summary>
    /// 将 货币类型/货币种类 转换为用于显示的字符串
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string ToDisplayString(this CurrencyCode currencyCode)
    {
        var currencyCodeStr = currencyCode.ToString();
        var key = CurrencyNameResourceKey(currencyCode);
        var currencyName = key == null ? null : R.Strings.ResourceManager.GetString(key, R.Strings.Culture);
        if (string.IsNullOrEmpty(currencyName) || currencyCodeStr == currencyName) return currencyCodeStr;
        return $"{currencyName} {currencyCodeStr}";
    }

    /// <summary>
    /// 将 货币类型/货币种类 转换为 Steam 地区/国家
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string? ToSteamCountry(this CurrencyCode currencyCode) => currencyCode switch
    {
        CurrencyCode.ARS => "阿根廷",
        CurrencyCode.TRY => "土耳其",
        CurrencyCode.BRL => "巴西",
        CurrencyCode.CNY => "中国",
        CurrencyCode.JPY => "日本",
        CurrencyCode.GBP => "美国",
        CurrencyCode.HKD => "香港",
        CurrencyCode.RUB => "俄罗斯联邦",
        CurrencyCode.INR => "印度",
        _ => null,
    };

    /// <summary>
    /// 将 货币类型/货币种类 转换为 Steam CCCode
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string? ToSteamCCCode(this CurrencyCode currencyCode) => currencyCode switch
    {
        CurrencyCode.ARS => "AR",
        CurrencyCode.TRY => "TR",
        CurrencyCode.BRL => "BR",
        CurrencyCode.CNY => "CN",
        CurrencyCode.JPY => "JP",
        CurrencyCode.GBP => "US",
        CurrencyCode.HKD => "HK",
        CurrencyCode.RUB => "RU",
        CurrencyCode.INR => "IN",
        CurrencyCode.USD => "US",
        _ => null,
    };

    /// <summary>
    /// 将 货币类型/货币种类 从 (WTTS 平台) 转换为 (Steam 平台)
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static SteamCurrencyCode ToSteamCurrencyCode(this CurrencyCode currencyCode) => currencyCode switch
    {
        CurrencyCode.USD => SteamCurrencyCode.USD,
        CurrencyCode.CNY => SteamCurrencyCode.CNY,
        CurrencyCode.GBP => SteamCurrencyCode.GBP,
        _ => (SteamCurrencyCode)currencyCode,
    };

    /// <summary>
    /// 将 货币类型/货币种类 从 (Steam 平台) 转换为 (WTTS 平台)
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static CurrencyCode ToCurrencyCode(this SteamCurrencyCode currencyCode) => currencyCode switch
    {
        SteamCurrencyCode.USD => CurrencyCode.USD,
        SteamCurrencyCode.CNY => CurrencyCode.CNY,
        SteamCurrencyCode.GBP => CurrencyCode.GBP,
        _ => (CurrencyCode)currencyCode,
    };

    /// <summary>
    /// 根据 货币类型/货币种类 获取 区域信息
    /// </summary>
    /// <param name="eCurrencyCode"></param>
    /// <returns></returns>
    public static CultureInfo? GetCultureInfo(this CurrencyCode eCurrencyCode)
           => CultureInfo.GetCultures(CultureTypes.SpecificCultures)
           .FirstOrDefault(culture => new RegionInfo(culture.Name).ISOCurrencySymbol == eCurrencyCode.ToString());

    /// <summary>
    /// 根据 货币类型/货币种类 获取 区域信息
    /// </summary>
    /// <param name="interface"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    public static CurrencyCode GetCurrencyCode(this IReadOnlyCurrencyCodeString @interface, CurrencyCode @default = CurrencyCode.CNY)
        => Enum.TryParse(@interface.CurrencyCode, true, out CurrencyCode currencyCode) ? currencyCode : @default;
}