namespace BD.WTTS.Models;

public class OrderInfoDTO : IKeyModel<Guid>
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
    public DateTimeOffset PaymentTime { get; set; }

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
}

public class OrderPaymentCompositionInfoDTO
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// 支付类型
    /// </summary>
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// 用户优惠劵信息
    /// </summary>
    public UserCouponInfoDTO? UserCouponInfo { get; set; }

    /// <summary>
    /// 支付金额
    /// </summary>
    public decimal PaymentAmount { get; set; }

    public string? Remarks { get; set; }
}

public class UserCouponInfoDTO
{
    /// <summary>
    /// 优惠劵 Id
    /// </summary>
    public Guid? CouponId { get; set; }

    /// <summary>
    /// 优惠劵名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 优惠劵类型
    /// </summary>
    public CouponType CouponType { get; set; }

    /// <summary>
    /// 劵面值
    /// </summary>
    public decimal Value { get; set; }
}