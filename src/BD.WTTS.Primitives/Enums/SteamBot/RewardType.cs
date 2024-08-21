// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 点数打赏 打赏类型
/// </summary>
public enum RewardType : byte
{
    /// <summary>
    /// 评测
    /// </summary>
    RecommendID = 1,

    /// <summary>
    /// 物品
    /// </summary>
    FileDetailsID = 2,

    /// <summary>
    /// SteamID
    /// </summary>
    SteamID = 3,

    /// <summary>
    /// 主题ID
    /// </summary>
    ForumTopicID = 4
}
