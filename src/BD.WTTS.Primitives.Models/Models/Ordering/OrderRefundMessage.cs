namespace BD.WTTS.Models;

/// <summary>
/// 订单退款消息内容
/// </summary>
/// <param name="OrderNumber">订单号</param>
/// <param name="RefundNumber">退款单号</param>
public record OrderRefundMessage(string OrderNumber, string RefundNumber);