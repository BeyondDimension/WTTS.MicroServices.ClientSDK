// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户钱包变更类型
/// </summary>
public enum UserWalletChangeType : byte
{
    /// <summary>
    /// 账号余额
    /// </summary>
    [Description("账号余额")]
    AccountBalance = 1,

    /// <summary>
    /// 付费积分
    /// </summary>
    [Description("付费积分")]
    ProPoints = 2,

    /// <summary>
    /// 免费积分
    /// </summary>
    [Description("免费积分")]
    FreePoints = 3,
}