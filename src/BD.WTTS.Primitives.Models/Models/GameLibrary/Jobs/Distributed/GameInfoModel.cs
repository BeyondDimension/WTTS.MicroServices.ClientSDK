namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial record struct GameInfoModel(
    GameType Type,
    string Name,
    string Describe,
    DateTime? ReleaseDate,
    string Developer,
    string Publisher,
    string HeaderImage,
    GameOSPlatform Platform,
    ImmutableArray<int>? ChildApps = null
    );
