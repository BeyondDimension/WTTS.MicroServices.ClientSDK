// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ScriptEvaluationDTO : IKeyModel<Guid>
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public Guid UserId { get; set; }

    [MPKey(2), MP2Key(2)]
    public string NickName { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public Guid ScriptId { get; set; }

    [MPKey(4), MP2Key(4)]
    public string ScriptName { get; set; } = string.Empty;

    [MPKey(5), MP2Key(5)]
    public byte Rate { get; set; }

    [MPKey(6), MP2Key(6)]
    public string Content { get; set; } = string.Empty;

    [MPKey(7), MP2Key(7)]
    public long AppreciationCount { get; set; }

    [MPKey(8), MP2Key(8)]
    public long NegativeCount { get; set; }

    [MPKey(9), MP2Key(9)]
    public Visibility Visibility { get; set; }

    [MPKey(10), MP2Key(10)]
    public DateTimeOffset CreationTime { get; set; }

    [MPKey(11), MP2Key(11)]
    public ScriptEvaluationJudgeType UserJudgeType { get; set; }

    [MPKey(12), MP2Key(12)]
    public bool ContentShield { get; set; }
}
