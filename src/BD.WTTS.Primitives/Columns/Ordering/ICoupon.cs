// ReSharper disable once CheckNamespace
namespace BD.WTTS.Columns;

/// <summary>
/// 优惠劵模型接口
/// </summary>
public interface ICoupon
{
    /// <summary>
    /// 优惠劵名称，最大长度不能超过 <see cref="Constants.Lengths.Max_CouponName"/>
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// 优惠劵类型
    /// </summary>
    CouponType CouponType { get; set; }

    #region Effective 有效期

    /// <summary>
    /// 有效开始时间
    /// </summary>
    DateTimeOffset EffectiveStartTime { get; set; }

    /// <summary>
    /// 有效结束时间
    /// </summary>
    DateTimeOffset EffectiveEndTime { get; set; }

    #endregion

    #region Restricted 限定

    /// <summary>
    /// 限定费用类型 Id
    /// </summary>
    Guid? RestrictedFeeTypeId { get; set; }

    /// <summary>
    /// 限定费用类型名称
    /// </summary>
    string? RestrictedFeeTypeName { get; set; }

    /// <summary>
    /// 限定用户类型
    /// </summary>
    CouponRestrictedUserType RestrictedUserType { get; set; }

    /// <summary>
    /// 限定金额可用
    /// </summary>
    decimal RestrictedAmountAvailable { get; set; }

    #endregion

    /// <summary>
    /// 劵面值，此优惠劵的面值
    /// </summary>
    decimal Value { get; set; }
}

public static class CouponExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetCoupon(this ICoupon coupon, ICoupon value)
    {
        coupon.Name = value.Name;
        coupon.CouponType = value.CouponType;
        coupon.EffectiveStartTime = value.EffectiveStartTime;
        coupon.EffectiveEndTime = value.EffectiveEndTime;
        coupon.RestrictedFeeTypeId = value.RestrictedFeeTypeId;
        coupon.RestrictedFeeTypeName = value.RestrictedFeeTypeName;
        coupon.RestrictedUserType = value.RestrictedUserType;
        coupon.RestrictedAmountAvailable = value.RestrictedAmountAvailable;
        coupon.Value = value.Value;
    }
}