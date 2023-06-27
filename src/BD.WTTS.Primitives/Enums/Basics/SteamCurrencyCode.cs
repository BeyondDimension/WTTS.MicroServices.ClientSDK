// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 货币类型/货币种类 (Steam 平台)
/// </summary>
public enum SteamCurrencyCode
{
    USD = 1,
    GBP = 2,
    EUR = 3,
    CHF = 4,
    RUB = 5,
    PLN = 6,
    BRL = 7,
    JPY = 8,
    NOK = 9,
    IDR = 10,
    MYR = 11,
    PHP = 12,
    SGD = 13,
    THB = 14,
    VND = 0xF,
    KRW = 0x10,

    /// <summary>
    /// 土耳其里拉
    /// 1 人民币 = 2.56 土耳其里拉
    /// </summary>
    TRY = 17,
    UAH = 18,
    MXN = 19,
    CAD = 20,
    AUD = 21,
    NZD = 22,
    CNY = 23,
    INR = 24,
    CLP = 25,
    PEN = 26,
    COP = 27,
    ZAR = 28,
    HKD = 29,
    TWD = 30,
    SAR = 0x1F,
    AED = 0x20,

    /// <summary>
    /// 阿根廷比索
    /// 1 人民币 = 20.28 阿根廷比索
    /// </summary>
    ARS = 34,
    ILS = 35,
    BYN = 36,
    KZT = 37,
    KWD = 38,
    QAR = 39,
    CRC = 40,
    UYU = 41,
}
