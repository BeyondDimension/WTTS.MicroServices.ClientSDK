// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 用户活跃度测量类型
/// </summary>
public enum ActiveUserStatisticsType : ushort
{
    /// <summary>
    /// 日活(1天)
    /// </summary>
    AU_1 = 1,

    /// <summary>
    /// 周活(7天)
    /// </summary>
    AU_7 = 7,

    /// <summary>
    /// 月活(30天)
    /// </summary>
    AU_30 = 30,

    /// <summary>
    /// 月活(整月)
    /// </summary>
    AU_Month = 1_001,
}