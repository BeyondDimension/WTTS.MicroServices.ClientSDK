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

partial class ScriptDTO : IScriptConfig
{
    DomainPattern? IScriptConfig.ExcludeDomainPattern => string.IsNullOrWhiteSpace(ExcludeDomainNames) ? null : new DomainPattern(ExcludeDomainNames);
}