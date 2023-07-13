namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class UserWalletResponse
{

    /// <summary>
    /// 用户 Id
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 账号余额
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public decimal AccountBalance { get; set; }

    /// <summary>
    /// 付费积分
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public long ProPoints { get; set; }

    /// <summary>
    /// 免费积分
    /// <para>历史用户信息表中的 EngineOil 字段（机油、体力、疲劳值、积分1）</para>
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public long FreePoints { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public DateTimeOffset UpdateTime { get; set; }
}
