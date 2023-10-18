namespace BD.WTTS.Models;

/// <summary>
/// 批量禁用产品密钥请求
/// </summary>
/// <param name="Keys">密钥数组</param>
/// <param name="OperatorId">操作人 Id</param>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record BatchDisableProductKeyRecordRequest
{
    [MPKey(0), MP2Key(0)]
    public string[] Keys { get; set; } = Array.Empty<string>();

    [MPKey(1), MP2Key(1)]
    public Guid? OperatorId { get; set; }
}
