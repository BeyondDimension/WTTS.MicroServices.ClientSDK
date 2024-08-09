namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
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
