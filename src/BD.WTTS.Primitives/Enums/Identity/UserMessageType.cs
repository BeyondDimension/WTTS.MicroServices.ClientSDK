// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户消息类型
/// </summary>
public enum UserMessageType : byte
{
    /// <summary>
    /// 回复消息
    /// </summary>
    Reply = 1,

    /// <summary>
    /// 艾特消息
    /// </summary>
    AtUser = 2,

    /// <summary>
    /// 点赞消息
    /// </summary>
    Like = 3,

    /// <summary>
    /// 私信消息
    /// </summary>
    PrivateLetter = 4,
}