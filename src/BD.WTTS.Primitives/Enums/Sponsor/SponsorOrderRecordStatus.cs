namespace BD.WTTS.Enums;

/// <summary>
/// 赞助订单状态
/// </summary>
public enum SponsorOrderRecordStatus
{
    等待支付 = 1,
    处理中 = 2,
    等待发货 = 4,
    订单取消 = 10,
    已退款 = 100,
    已支付 = 200,
}
