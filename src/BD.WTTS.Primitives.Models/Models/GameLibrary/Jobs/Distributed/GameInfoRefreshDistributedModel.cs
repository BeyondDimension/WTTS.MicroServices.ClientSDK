namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial record struct GameInfoRefreshDistributedModel(
    GameInfoModel Game,
    ImmutableArray<ConfigurationModel> Configurations,
    ImmutableArray<LanguageModel> Languages,
    ImmutableArray<string> TagNames,
    ImmutableArray<StaticResourceModel> StaticResources,
    ImmutableArray<RateMediaAgencyModel> RateMediaAgencies,
    ImmutableArray<AchievementModel> Achievements);
