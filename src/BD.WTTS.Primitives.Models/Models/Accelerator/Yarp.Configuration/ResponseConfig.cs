// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

// https://github.com/dotnetcore/FastGithub/blob/2.1.4/FastGithub.Configuration/ResponseConfig.cs

/// <inheritdoc cref="IResponseConfig"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ResponseConfig : IResponseConfig
{
    [MPKey(0), MP2Key(0)]
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;

    [MPKey(1), MP2Key(1)]
    public string ContentType { get; init; } = "text/plain;charset=utf-8";

    [MPKey(2), MP2Key(2)]
    public string? ContentValue { get; init; }
}

/// <summary>
/// 响应配置
/// </summary>
public interface IResponseConfig
{
    /// <summary>
    /// HTTP 状态码
    /// </summary>
    HttpStatusCode StatusCode { get; }

    /// <summary>
    /// 内容类型
    /// </summary>
    string ContentType { get; }

    /// <summary>
    /// 内容的值
    /// </summary>
    string? ContentValue { get; }
}

partial class AccelerateProjectDTO : IResponseConfig
{
    HttpStatusCode IResponseConfig.StatusCode => ProxyType switch { ProxyType.DirectFailure => HttpStatusCode.NotFound, ProxyType.DirectSuccess => HttpStatusCode.OK, _ => default };

    string IResponseConfig.ContentType => throw new NotImplementedException();

    string? IResponseConfig.ContentValue => throw new NotImplementedException();
}