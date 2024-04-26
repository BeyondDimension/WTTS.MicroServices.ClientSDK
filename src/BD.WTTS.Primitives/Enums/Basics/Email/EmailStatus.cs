namespace BD.WTTS.Enums;

/// <summary>
/// 邮件状态
/// </summary>
public enum EmailStatus : byte
{
    /// <summary>
    /// 待发送
    /// </summary>
    [Description("待发送")]
    Unsent = 0,

    /// <summary>
    /// 已发送
    /// </summary>
    [Description("已发送")]
    Sent = 1,

    /// <summary>
    /// 发送失败
    /// </summary>
    [Description("发送失败")]
    Failed = 2,
}