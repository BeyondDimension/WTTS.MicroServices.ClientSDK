// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 游戏平台
/// </summary>
[Flags]
public enum GamePlatform
{
    Windows = 1 << 1,

    Linux = 1 << 2,

    Android = 1 << 3,

    iOS = 1 << 4,

    macOS = 1 << 5,

    /// <summary>
    /// 索尼 PlayStation 商店
    /// </summary>
    PlayStation = 1 << 6,

    Xbox = 1 << 7,

    /// <summary>
    /// 任天堂 Nintendo Switch
    /// </summary>
    Switch = 1 << 8,

    SteamVR = 1 << 9,

    PSVR = 1 << 10,

    HTCVive = 1 << 11,
}
