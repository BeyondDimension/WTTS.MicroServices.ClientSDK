// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 用户资料模型类
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class IdentityUserInfoDTO :
#if MVVM_VM
    BaseNotifyPropertyChanged,
#endif
    IUserDTO, IBirthDateTimeZone
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
#if MVVM_VM
    [Reactive]
#endif
    public string NickName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public Guid Avatar { get; set; }

    /// <summary>
    /// 经验值
    /// </summary>
    [MPKey(3), MP2Key(3)]
#if MVVM_VM
    [Reactive]
#endif
    public uint Experience { get; set; }

    /// <summary>
    /// 余额
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public decimal Balance { get; set; }

    /// <summary>
    /// 账号等级
    /// </summary>
    [MPKey(5), MP2Key(5)]
#if MVVM_VM
    [Reactive]
#endif
    public byte Level { get; set; }

    [MPKey(6), MP2Key(6)]
#if MVVM_VM
    [Reactive]
#endif
    public long? SteamAccountId { get; set; }

    [MPKey(7), MP2Key(7)]
    public Gender Gender { get; set; }

    #region BirthDate(Only the current login user has value)

    [MPKey(8), MP2Key(8)]
    public DateTime? BirthDate { get; set; }

    [MPKey(9), MP2Key(9)]
    public sbyte BirthDateTimeZone { get; set; }

    #endregion

    /// <summary>
    /// 计算 年龄
    /// </summary>
    [MPKey(10), MP2Key(10)]
    public byte? CalcAge { get; set; }

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string Age
    {
        get
        {
            byte value;
            if (CalcAge.HasValue) value = CalcAge.Value;
            else value = BirthDateHelper.CalcAge(this.GetBirthDate()?.DateTime);
            return BirthDateHelper.ToString(value);
        }
    }

    /// <summary>
    /// 所在地
    /// </summary>
    [MPKey(11), MP2Key(11)]
    public int? AreaId { get; set; }

    [MPKey(12), MP2Key(12)]
#if MVVM_VM
    [Reactive]
#endif
    public string? MicrosoftAccountEmail { get; set; }

    [MPKey(13), MP2Key(13)]
#if MVVM_VM
    [Reactive]
#endif
    public string? AppleAccountEmail { get; set; }

    [MPKey(14), MP2Key(14)]
#if MVVM_VM
    [Reactive]
#endif
    public string? QQNickName { get; set; }

    /// <summary>
    /// 通过快速登录获取的头像 Url
    /// </summary>
    [MPKey(15), MP2Key(15)]
#if MVVM_VM
    [Reactive]
#endif
    public Dictionary<ExternalLoginChannel, string>? AvatarUrl { get; set; }

    /// <summary>
    /// 用户类型
    /// </summary>
    [MPKey(16), MP2Key(16)]
#if MVVM_VM
    [Reactive]
#endif
    public UserType UserType { get; set; }

    /// <summary>
    /// 下级所需经验
    /// </summary>
    [MPKey(17), MP2Key(17)]
#if MVVM_VM
    [Reactive]
#endif
    public uint NextExperience { get; set; }

    /// <summary>
    /// 是否签到
    /// </summary>
    [MPKey(18), MP2Key(18)]
#if MVVM_VM
    [Reactive]
#endif
    public bool IsSignIn { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [MPKey(19), MP2Key(19)]
#if MVVM_VM
    [Reactive]
#endif
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 个性签名
    /// </summary>
    [MPKey(20), MP2Key(20)]
#if MVVM_VM
    [Reactive]
#endif
    public string? PersonalizedSignature { get; set; }
}
