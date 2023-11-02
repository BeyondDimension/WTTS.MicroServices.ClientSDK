namespace BD.WTTS.Models;

public class OrderItemInfoDTO : IKeyModel<Guid>
{
    public Guid Id { get; set; }

    /// <summary>
    /// 订单号
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// 订单状态
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// 订单超时时间
    /// </summary>
    public DateTimeOffset Timeout { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTimeOffset? PaymentTime { get; set; }

    /// <summary>
    /// 业务类型，关联的支付业务类型枚举
    /// </summary>
    public OrderBusinessType BusinessType { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 订单备注
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }
}