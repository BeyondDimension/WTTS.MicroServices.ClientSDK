namespace BD.WTTS.Models;

/// <summary>
/// 订单退款消息内容
/// </summary>
public class OrderRefundMessage
{
    public Guid OrderId { get; set; }

    public Guid RefundBillId { get; set; }
}