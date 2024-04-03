// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

public partial class ForthwithRaffleResultDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    #region inventory

    /// <summary>
    /// 奖品内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    #endregion inventory

    #region prize

    /// <summary>
    /// 名称
    /// </summary>
    public string PrizeName { get; set; } = string.Empty;

    /// <summary>
    /// 奖品级别
    /// </summary>
    public byte PrizeLevel { get; set; }

    /// <summary>
    /// 参考价格
    /// </summary>
    public decimal? PriceIndication { get; set; }

    /// <summary>
    /// 中奖概率。1为100%，0.5为50%，
    /// </summary>
    public float? WinningProbability { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; set; }

    /// <summary>
    /// 奖品图
    /// </summary>
    public string? PrizeImg { get; set; }

    #endregion prize
}