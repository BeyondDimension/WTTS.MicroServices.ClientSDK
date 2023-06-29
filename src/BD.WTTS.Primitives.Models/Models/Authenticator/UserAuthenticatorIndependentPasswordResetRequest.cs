namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorIndependentPasswordResetRequest
{
    /// <summary>
    /// 问题答案
    /// </summary>
    [MPKey(0), MP2Key(0)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestionAnswer)]
    public string Answer { get; set; } = string.Empty;

    /// <summary>
    /// 新密码问题
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestion)]
    public string NewPwdQuestion { get; set; } = string.Empty;

    /// <summary>
    /// 新问题答案
    /// </summary>
    /// </summary>
    [MPKey(2), MP2Key(2)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestionAnswer)]
    public string NewAnswer { get; set; } = string.Empty;
}