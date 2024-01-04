namespace BD.WTTS.Models;

/// <summary>
/// 订单支付成功信息
/// </summary>
/// <param name="PaymentId">支付Id（支付组成Id）</param>
/// <param name="OrderNumber">订单号</param>
/// <param name="PaymentPlatform">支付平台</param>
/// <param name="PaymentPlatformOrderNumber">支付平台的订单号/交易号</param>
/// <param name="AmountReceived">实收金额</param>
/// <param name="PaymentTime">支付时间</param>
/// <param name="AgreementNo"></param>
public record MerchantDeductionSuccessInfo(Guid PaymentId, string OrderNumber, PaymentType PaymentPlatform, string PaymentPlatformOrderNumber, decimal AmountReceived, DateTimeOffset PaymentTime, string AgreementNo)
    : OrderPaymentSuccessInfo(PaymentId, OrderNumber, PaymentPlatform, PaymentPlatformOrderNumber, AmountReceived, PaymentTime);