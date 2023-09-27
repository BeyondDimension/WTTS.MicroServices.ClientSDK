namespace BD.WTTS.Models;

public class OrderDetailDTO : IKeyModel<Guid>
{
    public Guid Id { get; set; }

    /// <summary>
    /// 订单号
    /// </summary>
    public long OrderNumber { get; set; }

    /// <summary>
    /// 订单类型
    /// </summary>
    public OrderType Type { get; set; }

    /// <summary>
    /// 订单来源终端
    /// </summary>
    public ClientOSPlatform Source { get; set; }

    /// <summary>
    /// 订单超时时间
    /// </summary>
    public DateTimeOffset Timeout { get; set; }

    /// <summary>
    /// 订单状态
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// 用户 Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    public decimal AmountReceived { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTimeOffset? PaymentTime { get; set; }

    /// <summary>
    /// 业务类型，关联的支付业务类型枚举
    /// </summary>
    public OrderBusinessType BusinessType { get; set; }

    /// <summary>
    /// 业务 Id，业务类型订单的 Id
    /// </summary>
    public Guid BusinessId { get; set; }

    public string? Remarks { get; set; }

    /// <summary>
    /// 订单支付组成
    /// </summary>
    public List<OrderPaymentCompositionInfoDTO>? PaymentCompositions { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }

    /// <summary>
    /// 业务订单信息
    /// </summary>
    public object? BusinessOrderInfo { get; set; }
}