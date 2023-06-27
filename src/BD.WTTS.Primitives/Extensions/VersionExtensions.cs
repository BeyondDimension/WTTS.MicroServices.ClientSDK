// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class VersionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseVersion(this string? value, [NotNullWhen(true)] out Version? version)
    {
        version = default;
        if (value != null)
        {
            if (Version.TryParse(value, out version))
            {
                return true;
            }
            if (int.TryParse(value, out var major))
            {
                version = new Version(major, 0);
                return true;
            }
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ExToString(this Version? version)
    {
        if (version == null)
            return null;
        if (version.Revision >= 0)
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        if (version.Build >= 0)
            return $"{version.Major}.{version.Minor}.{version.Build}.0";
        if (version.Minor >= 0)
            return $"{version.Major}.{version.Minor}.0.0";
        if (version.Major >= 0)
            return $"{version.Major}.0.0.0";
        return "0.0.0.0";
    }
}
