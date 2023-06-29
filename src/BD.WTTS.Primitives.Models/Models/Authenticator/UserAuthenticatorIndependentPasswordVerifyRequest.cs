namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorIndependentPasswordVerifyRequest
{
    /// <summary>
    /// 问题答案
    /// </summary>
    /// </summary>
    [MPKey(0), MP2Key(0)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestionAnswer)]
    public string Answer { get; set; } = string.Empty;
}