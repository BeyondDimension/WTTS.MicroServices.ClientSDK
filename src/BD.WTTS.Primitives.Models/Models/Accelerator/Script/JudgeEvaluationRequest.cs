// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 脚本评价评判
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class JudgeEvaluationRequest
{
    [MPKey(0), MP2Key(0)]
    public Guid ScriptEvaluationId { get; set; }

    [MPKey(1), MP2Key(1)]
    public ScriptEvaluationJudgeType JudgeType { get; set; }

    [MPKey(2), MP2Key(2)]
    public Guid UserId { get; set; }

    [MPKey(3), MP2Key(3)]
    public DateTimeOffset CreationTime { get; set; }
}
