namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorIndependentPasswordSetRequest
{
    /// <summary>
    /// 密码问题
    /// </summary>
    [MPKey(0), MP2Key(0)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestion)]
    public string PwdQuestion { get; set; } = string.Empty;

    /// <summary>
    /// 问题答案
    /// </summary>
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestionAnswer)]
    public string Answer { get; set; } = string.Empty;
}