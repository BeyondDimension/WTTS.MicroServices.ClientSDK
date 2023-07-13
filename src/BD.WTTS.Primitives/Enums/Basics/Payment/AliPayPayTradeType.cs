namespace BD.WTTS.Enums;

public enum AliPayPayTradeType
{
    /// <summary>
    /// JSAPI(支付宝小程序支付)
    /// </summary>
    [Description("JSAPI(支付宝小程序支付)")]
    JSAPI = 1,

    /// <summary>
    /// JSAPI_PC(电脑网站支付)
    /// </summary>
    [Description("JSAPI_PC(电脑网站支付)")]
    JSAPI_PC = 2,

    /// <summary>
    /// NATIVE(扫码支付)
    /// </summary>
    [Description("NATIVE(扫码支付)")]
    ScanQRCodes = 3,

    /// <summary>
    /// APP(APP支付)
    /// </summary>
    [Description("APP(APP支付)")]
    APP = 4,

    /// <summary>
    /// MWEB(H5支付)
    /// </summary>
    [Description("MWEB(H5支付)")]
    MWEB = 5
}