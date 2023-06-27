// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户类型
/// </summary>
[Flags]
public enum UserType : long
{
#if DEBUG
    /// <summary>
    /// 封禁用户
    /// </summary>
    [Obsolete("封禁不应使用此字段判定", true)]
    Ban = -1,
#endif

    /// <summary>
    /// 普通用户
    /// </summary>
    Ordinary = 1,

    /// <summary>
    /// 赞助用户
    /// </summary>
    Sponsor = 2,
}
