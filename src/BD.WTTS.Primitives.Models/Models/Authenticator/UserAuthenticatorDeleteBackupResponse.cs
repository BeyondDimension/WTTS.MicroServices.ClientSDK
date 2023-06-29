namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class UserAuthenticatorDeleteBackupResponse
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public DateTimeOffset CreationTime { get; set; }

    /// <summary>
    /// 最后同步时间
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public DateTimeOffset LastSyncTime { get; set; }

    /// <summary>
    /// 令牌名
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 令牌类型
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public UserAuthenticatorTokenType TokenType { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public string? Remarks { get; set; }

    /// <summary>
    /// 是否恢复
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public bool IsRecovered { get; set; }

    /// <summary>
    /// 恢复时间
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public DateTimeOffset? RecoveryTime { get; set; }
}