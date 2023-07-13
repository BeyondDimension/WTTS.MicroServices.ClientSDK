namespace BD.WTTS.Models;

/// <summary>
/// 我拥有的游戏
/// </summary>
public class MyOwnedGameItem
{

    public string? HeaderImage { get; set; }

    /// <summary>
    /// 游戏名称
    /// </summary>
    public string? Name { get; set; }

    public string? Developer { get; set; }

    public string? Publisher { get; set; }

    /// <summary>
    /// 游戏平台
    /// </summary> 
    public GameOSPlatform Platform { get; set; }

    /// <summary>
    /// 游戏类型
    /// </summary> 
    public GameType Type { get; set; }

    /// <summary>
    /// 平台名称
    /// </summary>
    public string? DealerPlatformName { get; set; }

    /// <summary>
    /// 游戏在对应零售商平台的 Id，例如 Steam 的 AppId
    /// </summary>
    public string DealerGameId { get; set; } = string.Empty;

    /// <summary>
    /// 游戏时长
    /// </summary>
    public TimeSpan GameDuration { get; set; }

    /// <summary>
    /// 最后运行时间
    /// </summary>
    public DateTimeOffset? LastRunTime { get; set; }
}
