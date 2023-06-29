namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorPushRequest
{
    /// <summary>
    /// 令牌差异
    /// </summary>
    [MPKey(0), MP2Key(0)]
    [Required]
    public UserAuthenticatorPushItem[] Difference { get; set; } = Array.Empty<UserAuthenticatorPushItem>();

    /// <summary>
    /// 令牌独立密码答案
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [Required]
    public string Answer { get; set; } = string.Empty;
}