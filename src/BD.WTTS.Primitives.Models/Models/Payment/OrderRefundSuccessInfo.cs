namespace BD.WTTS.Models;

/// <summary>
/// 订单退款成功信息
/// </summary>
/// <param name="RefundBillId">退款单Id</param>
/// <param name="PaymentId">支付Id（支付组成Id）</param>
/// <param name="PaymentPlatform">支付平台</param>
public record OrderRefundSuccessInfo(Guid RefundBillId, Guid PaymentId, PaymentType PaymentPlatform);