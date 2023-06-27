// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

[Flags]
public enum GameOSPlatform
{
    Windows = 1 << 1,

    Linux = 1 << 2,

    Android = 1 << 3,

    iOS = 1 << 4,

    macOS = 1 << 5,

    [Obsolete("use macOS", true)]
    MacOS = macOS,
}
