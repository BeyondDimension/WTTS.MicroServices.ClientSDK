namespace BD.WTTS.Models;

/// <summary>
/// 订单业务支付方式
/// </summary>
public class OrderBusinessPaymentMethod
{
    /// <inheritdoc cref="Enums.PaymentMethod" />
    public PaymentMethod PaymentMethod { get; set; }

    /// <inheritdoc cref="Enums.PaymentType" />
    public PaymentType PaymentType { get; set; }
}