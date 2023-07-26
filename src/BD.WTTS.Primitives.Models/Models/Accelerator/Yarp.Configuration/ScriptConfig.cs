// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

// https://github.com/dotnetcore/FastGithub/blob/2.1.4/FastGithub.Configuration/DomainConfig.cs

/// <summary>
/// 脚本配置
/// </summary>
public interface IScriptConfig
{
    /// <summary>
    /// 本地脚本 Id
    /// </summary>
    int LocalId { get; }

    /// <summary>
    /// 排除匹配域名
    /// </summary>
    DomainPattern? ExcludeDomainPattern { get; }

}

[MP2Obj(SerializeLayout.Explicit)]
public readonly partial record struct ScriptIPCDTO(
    [property: MP2Key(0)]
    int LocalId,
    [property: MP2Key(1)]
    string CachePath,
    [property: MP2Key(2)]
    string[] MatchDomainNamesArray,
    [property: MP2Key(3)]
    string ExcludeDomainNames,
    [property: MP2Key(4)]
    long Order
    ) : IScriptConfig
{
    DomainPattern? IScriptConfig.ExcludeDomainPattern => string.IsNullOrWhiteSpace(ExcludeDomainNames) ? null : new DomainPattern(ExcludeDomainNames);
}