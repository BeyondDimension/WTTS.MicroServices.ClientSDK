using System.Runtime.Serialization.Formatters;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

// https://github.com/dotnetcore/FastGithub/blob/2.1.4/FastGithub.Configuration/DomainConfig.cs

/// <inheritdoc cref="IDomainConfig"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class DomainConfig : IDomainConfig
{
    [MPKey(0), MP2Key(0)]
    public bool TlsSni { get; init; }

    [MPKey(1), MP2Key(1)]
    public string? TlsSniPattern { get; init; }

    [MPKey(2), MP2Key(2)]
    public bool TlsIgnoreNameMismatch { get; init; }

    [MPKey(3), MP2Key(3)]
    [MessagePackFormatter(typeof(IPAddressFormatter))]
    [IPAddressFormatter]
    public IPAddress? IPAddress { get; init; }

    [MPKey(4), MP2Key(4)]
    public TimeSpan? Timeout { get; init; }

    [MPKey(5), MP2Key(5)]
    public Uri? Destination { get; init; }

    [MPKey(6), MP2Key(6)]
    public ResponseConfig? Response { get; init; }

    [MPKey(7), MP2Key(7)]
    public string? ForwardDestination { get; init; }

    [MPKey(8), MP2Key(8)]
    public string? UserAgent { get; init; }

    [MPKey(9), MP2Key(9)]
    public IReadOnlyDictionary<DomainPattern, IDomainConfig>? Items { get; init; }

    IResponseConfig? IDomainConfig.Response => Response;
}

/// <summary>
/// 域名配置
/// </summary>
public interface IDomainConfig
{
    /// <summary>
    /// 是否发送 SNI
    /// </summary>
    bool TlsSni { get; }

    /// <summary>
    /// 自定义 SNI 值的表达式
    /// </summary>
    string? TlsSniPattern { get; }

    /// <summary>
    /// 是否忽略服务器证书域名不匹配
    /// <para>当不发送 SNI 时服务器可能发回域名不匹配的证书</para>
    /// </summary>
    bool TlsIgnoreNameMismatch { get; }

    /// <summary>
    /// 使用的 IP 地址
    /// </summary>
    IPAddress? IPAddress { get; }

    /// <summary>
    /// 使用的域名
    /// </summary>
    string? ForwardDestination { get; }

    /// <summary>
    /// 请求超时时长
    /// </summary>
    TimeSpan? Timeout { get; }

    /// <summary>
    /// 目的地
    /// <para>格式为相对或绝对 <see cref="Uri"/></para>
    /// </summary>
    Uri? Destination { get; }

    /// <summary>
    /// UserAgent
    /// </summary>
    string? UserAgent { get; }

    /// <summary>
    /// 自定义响应
    /// </summary>
    IResponseConfig? Response { get; }

    /// <summary>
    /// 子匹配项
    /// </summary>
    IReadOnlyDictionary<DomainPattern, IDomainConfig>? Items { get; }
}

public static class DomainConfigExtensions
{
    // https://github.com/dotnetcore/FastGithub/blob/2.1.4/FastGithub.Configuration/DomainConfig.cs#L52

    /// <summary>
    /// 获取 <see cref="TlsSniPattern"/>
    /// </summary>
    /// <param name="domainConfig"></param>
    /// <returns></returns>
    public static TlsSniPattern GetTlsSniPattern(this IDomainConfig domainConfig)
    {
        if (domainConfig.TlsSni == false)
        {
            return TlsSniPattern.None;
        }
        if (string.IsNullOrEmpty(domainConfig.TlsSniPattern))
        {
            return TlsSniPattern.Domain;
        }
        return new TlsSniPattern(domainConfig.TlsSniPattern);
    }
}

partial class AccelerateProjectDTO : IDomainConfig
{
    bool IDomainConfig.TlsSni => !string.IsNullOrEmpty(FakeServerName);

    string? IDomainConfig.TlsSniPattern => FakeServerName;

    bool IDomainConfig.TlsIgnoreNameMismatch => true;

    IPAddress? IDomainConfig.IPAddress
    {
        //get
        //{
        //if (ProxyType == ProxyType.Local && !ForwardDomainIsNameOrIP)
        //{
        //    IPAddress2.TryParse(ForwardDomainIP, out var ip);
        //    return ip;
        //}
        //    return null;
        //}
        get;
    }

    string? IDomainConfig.ForwardDestination
    {
        //get
        //{
        //if (ProxyType == ProxyType.Local && ForwardDomainIsNameOrIP)
        //{
        //    return ForwardDomainName;
        //}
        //    return null;
        //}
        get;
    }

    TimeSpan? IDomainConfig.Timeout => null;

    Uri? IDomainConfig.Destination
    {
        get
        {
            if (ProxyType == ProxyType.Redirect)
            {
                var b = new UriBuilder
                {
                    Scheme = Port == 443 ? Uri.UriSchemeHttps : Uri.UriSchemeHttp,
                    Host = ForwardDomainNames,
                    Port = Port,
                };
                return b.Uri;
            }
            return null;
        }
    }

    string? IDomainConfig.UserAgent => FakeUserAgent;

    IResponseConfig? IDomainConfig.Response => null;

    IReadOnlyDictionary<DomainPattern, IDomainConfig>? IDomainConfig.Items => Items?.ToDictionary(x => new DomainPattern(x.MatchDomainNames), y => (IDomainConfig)y);
}