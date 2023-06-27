// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户钱包支付方向
/// </summary>
public enum UserWalletPaymentDirection : byte
{
    /// <summary>
    /// 收入
    /// </summary>
    In = 1,

    /// <summary>
    /// 支出
    /// </summary>
    Out = 2,
}