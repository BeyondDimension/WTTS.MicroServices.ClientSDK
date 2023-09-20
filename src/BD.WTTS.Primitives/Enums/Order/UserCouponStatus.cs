// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户优惠劵状态
/// </summary>
public enum UserCouponStatus : byte
{
    启用 = 1,
    禁用,
    撤回,
    已使用,
}
