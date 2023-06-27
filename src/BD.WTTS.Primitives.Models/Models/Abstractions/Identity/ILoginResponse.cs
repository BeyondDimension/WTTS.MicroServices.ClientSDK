// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// 登录响应内容
/// </summary>
public interface ILoginResponse : IReadOnlyAuthToken, IReadOnlyPhoneNumber
{
    /// <summary>
    /// 用户Id
    /// </summary>
    Guid UserId { get; }
}

public interface ILoginOrRegisterResponse : ILoginResponse, IExplicitHasValue
{
    /// <inheritdoc cref="Enums.ExternalLoginChannel"/>
    ExternalLoginChannel? ExternalLoginChannel { get; set; }
}