// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 好友状态
/// </summary>
public enum FriendStatus : byte
{
    None = 0,
    Blocked = 1,

    /// <summary>
    /// 好友申请被等待接受中
    /// </summary>
    RequestRecipient = 2,
    Friend = 3,

    /// <summary>
    /// 发送好友申请中
    /// </summary>
    RequestInitiator = 4,

    /// <summary>
    /// 请求被忽略
    /// </summary>
    Ignored = 5,

    IgnoredFriend = 6,
}
