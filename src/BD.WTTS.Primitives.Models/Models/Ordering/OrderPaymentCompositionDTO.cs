namespace BD.WTTS.Models;

public class OrderPaymentCompositionDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 支付金额
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// 支付单号
    /// </summary>
    public string PaymentNumber { get; set; } = string.Empty;

    /// <summary>
    /// 支付方式
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// 支付类型
    /// </summary>
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    public bool PaymentStatus { get; set; }

    /// <summary>
    /// 订单 Id
    /// </summary>
    public Guid OrderId { get; set; }
}