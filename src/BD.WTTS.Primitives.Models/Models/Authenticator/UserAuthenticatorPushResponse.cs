namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorPushResponse
{
    public UserAuthenticatorPushResponse(bool result, string message)
    {
        Result = result;
        Message = message;
    }

    /// <summary>
    /// 是否完全成功
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public bool Result { get; set; }

    /// <summary>
    /// 同步结果消息
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string Message { get; set; } = string.Empty;
}