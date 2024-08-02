namespace BD.WTTS.Models;

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct GameInfoRefreshDistributedModel(
    GameInfoModel Game,
    ImmutableArray<ConfigurationModel> Configurations,
    ImmutableArray<LanguageModel> Languages,
    ImmutableArray<string> TagNames,
    ImmutableArray<StaticResourceModel> StaticResources,
    ImmutableArray<RateMediaAgencyModel> RateMediaAgencies,
    ImmutableArray<AchievementModel> Achievements);

[MemoryPackable(SerializeLayout.Sequential)]
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

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct ConfigurationModel(
    GameOSPlatform GameOSPlatform,
    GameConfigurationLevel GameConfigurationLevel,
    string OS,
    string CPU,
    long Memory,
    string GraphicsCard,
    long DiskSpace,
    string DirectXVersion,
    string Notes,
    string Network,
    string SoundCard
    );

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct LanguageModel(
    string Name,
    string IetfLanguageTag,
    string Remarks
    );

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct StaticResourceModel(
    GameResourceType Type,
    string Url
    );

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct RateMediaAgencyModel(
    string MediaAgencyName,
    decimal MetaRate,
    decimal UserMetaRate,
    string Url
    );

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct AchievementModel(
    string Url,
    string Name,
    string Describe,
    string UnlockCondition
    );
