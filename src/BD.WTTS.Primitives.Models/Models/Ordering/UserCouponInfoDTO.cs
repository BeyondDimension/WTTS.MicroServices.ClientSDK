namespace BD.WTTS.Models;

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