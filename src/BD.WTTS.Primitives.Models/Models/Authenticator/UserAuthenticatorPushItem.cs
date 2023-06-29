namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorPushItem
{
    /// <summary>
    /// 云令牌Id
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public Guid? Id { get; set; }

    /// <summary>
    /// 令牌名
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [StringLength(Constants.Lengths.Max_AuthenticatorName)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 令牌类型
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public UserAuthenticatorTokenType TokenType { get; set; }

    /// <summary>
    /// 令牌序列化储存内容
    /// </summary>
    [MPKey(3), MP2Key(3)]
    [MaxLength(Constants.Lengths.Max_AuthenticatorToken)]
    public byte[]? Token { get; set; } = null!;

    /// <summary>
    /// 备注
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string? Remarks { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public long Order { get; set; }

    /// <summary>
    /// 是否要删除
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 令牌数据是否错误
    /// </summary>
    [MPIgnore, MP2Ignore]
    public bool IsWrong { get; set; }

    /// <summary>
    /// 令牌所属平台
    /// </summary>
    [MPIgnore, MP2Ignore]
    public int GamePlatform { get; set; }
}