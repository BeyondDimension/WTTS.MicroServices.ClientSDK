namespace BD.WTTS.Models;

public class AftersalesBillAddDTO
{
    /// <summary>
    /// 订单 Id
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 退款原因
    /// </summary>
    public string RefundReason { get; set; } = "";
}