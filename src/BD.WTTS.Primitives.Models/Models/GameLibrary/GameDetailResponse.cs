namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameDetailResponse
{
    [MPKey(0), MP2Key(0)]
    public string Name { get; set; } = string.Empty;

    [MPKey(1), MP2Key(1)]
    public string Describe { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    public string Developer { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public string Publisher { get; set; } = string.Empty;

    [MPKey(4), MP2Key(4)]
    public GameOSPlatform Platform { get; set; }

    [MPKey(5), MP2Key(5)]
    public GameType Type { get; set; }

    [MPKey(6), MP2Key(6)]
    public DateTime? ReleaseDate { get; set; }

    [MPKey(7), MP2Key(7)]
    public string HeaderImage { get; set; } = string.Empty;

    [MPKey(8), MP2Key(8)]
    public int AchievementCount { get; set; }

    [MPKey(9), MP2Key(9)]
    public List<GameTagResponse>? Tags { get; set; }

    [MPKey(10), MP2Key(10)]
    public List<GameLanguageResponse>? Languages { get; set; }

    [MPKey(11), MP2Key(11)]
    public List<GameRateMediaResponse>? RateMedias { get; set; }

    [MPKey(12), MP2Key(12)]
    public List<GameConfigurationRequireResponse>? ConfigurationRequires { get; set; }

    [MPKey(13), MP2Key(13)]
    public List<GameSubResponse>? Subs { get; set; }

    [MPKey(14), MP2Key(14)]
    public List<GameResourceResponse>? Resources { get; set; }
}
