// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 插件分类DTO
/// </summary>
[MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Explicit)]
public sealed partial class PluginUpdateRequest
{
    [MP2Key(0), MPKey(0)]
    public Guid Id { get; set; }

    [MP2Key(1), MPKey(1)]
    public string? VersionNumber { get; set; }

    [MP2Key(2), MPKey(2)]
    public DateTimeOffset UpdateTime { get; set; }
}