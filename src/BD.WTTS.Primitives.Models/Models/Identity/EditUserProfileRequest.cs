using static BD.WTTS.R.Strings;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 请求 - 编辑用户个人资料/我的资料
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class EditUserProfileRequest
{
    [MPKey(0), MP2Key(0)]
    public string NickName { get; set; } = string.Empty;

    [MPKey(1), MP2Key(1)]
    public Guid? Avatar { get; set; }

    [MPKey(2), MP2Key(2)]
    public Gender Gender { get; set; }

    [MPKey(3), MP2Key(3)]
    public DateTime? BirthDate { get; set; }

    [MPKey(4), MP2Key(4)]
    public sbyte BirthDateTimeZone { get; set; }

    [MPKey(5), MP2Key(5)]
    public int? AreaId { get; set; }

    public string? GetErrorMessage()
    {
        if (string.IsNullOrEmpty(NickName))
            return 请输入昵称;
        if (NickName.Length > IUserDTO.MaxLength_NickName)
            return 昵称最大长度不能超过_.Format(IUserDTO.MaxLength_NickName);
        return null;
    }
}
