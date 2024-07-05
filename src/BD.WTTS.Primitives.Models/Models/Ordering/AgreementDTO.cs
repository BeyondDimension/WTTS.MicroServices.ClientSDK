namespace BD.WTTS.Models;

public sealed class AgreementDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 签约时间
    /// </summary>
    public DateTimeOffset? SigningTime { get; set; }

    /// <summary>
    /// 解约时间
    /// </summary>
    public DateTimeOffset? UnSigningTime { get; set; }

    /// <summary>
    /// 平台类型
    /// </summary>
    public PaymentType Platform { get; set; }

    /// <summary>
    /// 签约协议号
    /// </summary>
    public string AgreementNo { get; set; } = "";

    /// <summary>
    /// 外部协议号
    /// </summary>
    public string ExtAgreementNo { get; set; } = "";

    /// <summary>
    /// 生效时间
    /// </summary>
    public DateTimeOffset? ValidTime { get; set; }

    /// <summary>
    /// 失效时间
    /// </summary>
    public DateTimeOffset? InvalidTime { get; set; }

    /// <summary>
    /// 周期数
    /// </summary>
    public int Period { get; set; }

    /// <summary>
    /// 周期类型
    /// </summary>
    public string PeriodType { get; set; } = "";

    /// <summary>
    /// 扣款执行日期
    /// </summary>
    public DateTimeOffset ExecuteTime { get; set; }

    /// <summary>
    /// 最后扣款时间
    /// </summary>
    public DateTimeOffset? NextDeductionTime { get; set; }

    /// <summary>
    /// 单次扣款金额
    /// </summary>
    public decimal SingleAmount { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public AgreementStatus Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// 业务类型
    /// </summary>
    public OrderBusinessType BusinessType { get; set; }
}