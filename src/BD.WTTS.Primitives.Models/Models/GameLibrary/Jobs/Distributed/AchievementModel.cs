namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial record struct AchievementModel(
    string Url,
    string Name,
    string Describe,
    string UnlockCondition
    );
