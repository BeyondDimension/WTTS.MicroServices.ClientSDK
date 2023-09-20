namespace BD.WTTS.Enums;

public enum WeChatPayTradeType
{
    [Description("JSAPI(小程序支付)")]
    JSAPI = 1,
    [Description("JSAPI_OFFICIAL(公众号支付)")]
    JSAPI_OFFICIAL = 2,
    [Description("NATIVE(扫码支付)")]
    NATIVE = 3,
    [Description("APP(APP支付)")]
    APP = 4,
    [Description("MWEB(H5支付)")]
    MWEB = 5
}
