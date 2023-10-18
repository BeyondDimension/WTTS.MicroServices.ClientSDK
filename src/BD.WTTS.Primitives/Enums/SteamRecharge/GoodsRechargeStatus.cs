namespace BD.WTTS.Enums;

/// <summary>
/// 充值状态
/// </summary>
public enum GoodsRechargeStatus : byte
{
    /// <summary>
    /// 待充值
    /// </summary>
    [Description("待充值")]
    Pending = 1,

    /// <summary>
    /// 已充值
    /// </summary>
    [Description("已充值")]
    Recharged = 2,

    /// <summary>
    /// 充值进行中
    /// </summary>
    [Description("充值进行中")]
    InProgress = 3,

    /// <summary>
    /// 充值异常
    /// </summary>
    [Description("充值异常")]
    Exception = 4,

    /// <summary>
    /// 充值关闭
    /// </summary>
    [Description("充值关闭")]
    Closed = 5,
}