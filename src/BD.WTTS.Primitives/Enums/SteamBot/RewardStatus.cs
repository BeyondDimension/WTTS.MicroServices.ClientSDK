// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 点数打赏 打赏状态
/// </summary>
public enum RewardStatus : byte
{
    /// <summary>
    /// 等待打赏
    /// </summary>
    Waiting,

    /// <summary>
    /// 打赏中
    /// </summary>
    InProgress,

    /// <summary>
    /// 完成
    /// </summary>
    Completed,

    /// <summary>
    /// 异常
    /// </summary>
    Exception,
}
