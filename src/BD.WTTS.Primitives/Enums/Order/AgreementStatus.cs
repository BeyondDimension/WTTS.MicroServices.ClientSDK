// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 协议状态
/// </summary>
public enum AgreementStatus
{
    /// <summary>
    /// 未签约
    /// </summary>
    [Description("未签约")]
    UnSigned = 0,

    /// <summary>
    /// 已签约
    /// </summary>
    [Description("已签约")]
    Signed = 1,

    /// <summary>
    /// 解约中
    /// </summary>
    [Description("解约中")]
    Terminating = 2,

    /// <summary>
    /// 已解约
    /// </summary>
    [Description("已解约")]
    Terminated = 3,
}