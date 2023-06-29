namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorDeleteBackupRecoverRequest
{
    [MPKey(0), MP2Key(0)]
    [Required]
    public Guid[] Id { get; set; } = Array.Empty<Guid>();

    /// <summary>
    /// 问题答案
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [Required]
    [StringLength(Constants.Lengths.Max_PwdQuestionAnswer)]
    public string Answer { get; set; } = string.Empty;
}