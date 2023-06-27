// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// 获取登录凭证
/// </summary>
public interface IReadOnlyAuthToken
{
    /// <inheritdoc cref="IReadOnlyAuthToken"/>
    JWTEntity? AuthToken { get; }
}