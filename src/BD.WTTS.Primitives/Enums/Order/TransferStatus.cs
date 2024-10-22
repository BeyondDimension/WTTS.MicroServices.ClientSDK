// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 转账状态
/// </summary>
public enum TransferStatus
{
    /// <summary>
    /// 未转账
    /// </summary>
    [Description("未转账")]
    Pending = 0,

    /// <summary>
    /// 转账中
    /// </summary>
    [Description("转账中")]
    Transferring = 1,

    /// <summary>
    /// 转账成功
    /// </summary>
    [Description("转账成功")]
    Success = 2,

    /// <summary>
    /// 转账失败
    /// </summary>
    [Description("转账失败")]
    Failed = 3,
}