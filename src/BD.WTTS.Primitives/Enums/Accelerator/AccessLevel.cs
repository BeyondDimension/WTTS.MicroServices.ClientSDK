// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 服务端代理访问级别
/// </summary>
public enum AccessLevel
{
    /// <summary>
    /// 匿名
    /// </summary>
    Anonymous = 0,

    /// <summary>
    /// 会员
    /// </summary>
    Member = 1,

    /// <summary>
    /// 赞助用户
    /// </summary>
    Sponsor = 2,
}
