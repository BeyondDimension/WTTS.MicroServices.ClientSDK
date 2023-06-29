// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 余额交易 交易状态
/// </summary>
public enum BalanceTradingStatus : byte
{
    /// <summary>
    /// 创建
    /// </summary>
    Created,

    /// <summary>
    /// 等待中
    /// </summary>
    Waiting,

    /// <summary>
    /// 生成中
    /// </summary>
    Generating,

    /// <summary>
    /// 待支付 
    /// </summary>
    PendingPayment,

    /// <summary>
    /// 交易完成
    /// </summary>
    Completed,

    /// <summary>
    /// 交易关闭
    /// </summary>
    Closed,

    /// <summary>
    /// 人工处理
    /// </summary>
    Manual
}
