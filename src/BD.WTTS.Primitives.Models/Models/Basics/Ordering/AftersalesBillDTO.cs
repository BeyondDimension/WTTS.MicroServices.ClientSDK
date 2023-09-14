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

public class AftersalesBillInfoDTO : IKeyModel<Guid>
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 订单 Id
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 售后单号
    /// </summary>
    public long AftersalesNumber { get; set; }

    /// <summary>
    /// 退款金额
    /// </summary>
    public decimal RefundAmount { get; set; }

    /// <summary>
    /// 审核状态
    /// </summary>
    public AuditStatus AuditStatus { get; set; }

    /// <summary>
    /// 退款原因
    /// </summary>
    public string RefundReason { get; set; } = "";

    /// <summary>
    /// 卖家备注
    /// </summary>
    public string SellerNote { get; set; } = "";

    /// <summary>
    /// 提交时间
    /// </summary>
    public DateTimeOffset SubmissionTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTimeOffset UpdateTime { get; set; }
}