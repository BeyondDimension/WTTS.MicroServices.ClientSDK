// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class CurrencyCodeEnumExtensions
{
    /// <summary>
    /// 将 货币类型/货币种类 转换为中文名称
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string ToChineseString(this CurrencyCode currencyCode) => currencyCode switch
    {
        CurrencyCode.AED => "阿联酋迪拉姆",
        CurrencyCode.ARS => "阿根廷比索",
        CurrencyCode.AUD => "澳元",
        CurrencyCode.BRL => "巴西雷亚尔",
        CurrencyCode.CAD => "加元",
        CurrencyCode.CHF => "瑞士法郎",
        CurrencyCode.CLP => "智利比索",
        CurrencyCode.CNY => "人民币",
        CurrencyCode.COP => "哥伦比亚比索",
        CurrencyCode.CRC => "哥斯达尼家科朗",
        CurrencyCode.EUR => "欧元",
        CurrencyCode.GBP => "英镑",
        CurrencyCode.HKD => "港元",
        CurrencyCode.IDR => "卢比",
        CurrencyCode.ILS => "新谢克尔",
        CurrencyCode.INR => "印度卢比",
        CurrencyCode.JPY => "日元",
        CurrencyCode.KRW => "韩元",
        CurrencyCode.KWD => "科威特第纳尔",
        CurrencyCode.KZT => "腾格",
        CurrencyCode.MXN => "墨西哥比索",
        CurrencyCode.MYR => "马来西亚林吉特",
        CurrencyCode.NOK => "挪威克朗",
        CurrencyCode.NZD => "新西兰",
        CurrencyCode.PEN => "新索尔",
        CurrencyCode.PHP => "菲律宾比索",
        CurrencyCode.PLN => "兹罗提",
        CurrencyCode.QAR => "卡塔尔里亚尔",
        CurrencyCode.RUB => "俄罗斯卢布",
        CurrencyCode.SAR => "沙特里亚尔",
        CurrencyCode.SGD => "新加坡",
        CurrencyCode.THB => "泰铢",
        CurrencyCode.TRY => "土耳其里拉",
        CurrencyCode.TWD => "新台币",
        CurrencyCode.UAH => "格里夫尼亚",
        CurrencyCode.USD => "美元",
        CurrencyCode.UYU => "乌拉圭比索",
        CurrencyCode.VND => "越南盾",
        CurrencyCode.ZAR => "兰特",
        CurrencyCode.BYN => "白俄罗斯卢布",

        _ => currencyCode.ToString(),
    };

    /// <summary>
    /// 将 货币类型/货币种类 转换为用于显示的字符串
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static string ToDisplayString(this CurrencyCode currencyCode)
    {
        var currencyCodeStr = currencyCode.ToString();
        var currencyCodeCNStr = currencyCode.ToChineseString();
        if (currencyCodeStr == currencyCodeCNStr) return currencyCodeStr;
        return $"{currencyCodeCNStr} {currencyCodeStr}";
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