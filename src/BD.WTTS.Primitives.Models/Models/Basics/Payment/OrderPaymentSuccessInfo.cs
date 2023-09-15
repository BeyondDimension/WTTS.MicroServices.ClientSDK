namespace BD.WTTS.Models;

public class OrderPaymentSuccessInfo
{
    /// <summary>
    /// 订单号
    /// </summary>
    public string OrderNumber { get; set; } = "";

    /// <summary>
    /// 支付平台
    /// </summary>
    public PaymentPlatform PaymentPlatform { get; set; }

    /// <summary>
    /// 支付平台的订单号/交易号
    /// </summary>
    public string PaymentPlatformOrderNumber { get; set; } = "";

    /// <summary>
    /// 实收金额
    /// </summary>
    public decimal AmountReceived { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTimeOffset PaymentTime { get; set; }
}