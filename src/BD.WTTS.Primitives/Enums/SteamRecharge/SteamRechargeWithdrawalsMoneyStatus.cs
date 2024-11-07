namespace BD.WTTS.Enums;

/// <summary>
/// Steam 充值提现状态
/// </summary>
public enum SteamRechargeWithdrawalsMoneyStatus : byte
{
    /// <summary>
    /// 等待提取
    /// </summary>
    [Description("等待核算")]
    Waiting = 0,

    /// <summary>
    /// 未提取
    /// </summary>
    [Description("未提取")]
    Pending = 1,

    /// <summary>
    /// 已提取
    /// </summary>
    [Description("已提取")]
    Success = 2,
}
