// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class ApiConstants
{
    public const string Basic = "Bearer";

    public const string DefaultUserAgent = "Mozilla/5.0 (Windows Phone 10.0; Android 4.2.1; Microsoft; Lumia 950) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Mobile Safari/537.36 Edge/14.14263";

    public static class MediaTypeNames
    {
        public const string MessagePackSecurity = "application/vnd.sapi+x-msgpack";

        public const string MemoryPackSecurity = "application/vnd.sapi+x-memorypack";
        public const string MemoryPack = "application/x-memorypack";

        public const string JSONSecurity = "application/vnd.sapi+x-json";
    }

    public const string CUSTOM_URL_SCHEME_NAME = "spp";

    public const string CUSTOM_URL_SCHEME = $"{CUSTOM_URL_SCHEME_NAME}://";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetReferrer(ClientOSPlatform clientOSPlatform, string appVersion)
        => $"{CUSTOM_URL_SCHEME}{clientOSPlatform}/{appVersion}";

    public static class Headers
    {
        public static class Request
        {
            public const string AppVersion = "App-Version";

            /// <summary>
            /// 安全密钥 ByteArray，Base64Url 编码
            /// </summary>
            public const string SecurityKey = "App-SKey";

            /// <summary>
            /// 安全密钥 ByteArray，Hex 编码
            /// </summary>
            public const string SecurityKeyHex = "App-SKey-Hex";

            /// <summary>
            /// 安全密钥填充
            /// </summary>
            public const string SecurityKeyPadding = "App-SKey-Padding";
        }

        public static class Response
        {
            public const string AppObsolete = "App-Obsolete";
        }
    }

    /// <summary>
    /// 短信间隔，60秒
    /// </summary>
    public const int SMSInterval = 60;

    /// <summary>
    /// 实际短信间隔
    /// </summary>
    public const double SMSIntervalActually = 79.5;

    /// <summary>
    /// 通用分隔符
    /// </summary>
    public const char GeneralSeparator = ';';

    public static string[] GetSplitValues(string values)
    {
        if (string.IsNullOrWhiteSpace(values)) return Array.Empty<string>();
        return values.Split(GeneralSeparator, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] GetSplitValues(object @lock, string values, ref string? cacheValues, ref string[]? cacheValuesArray)
    {
        lock (@lock)
        {
            if (cacheValuesArray == null || cacheValues == null || cacheValues != values)
            {
                cacheValues = values;
                cacheValuesArray = GetSplitValues(values);
            }
        }
        return cacheValuesArray;
    }

    public const float MaxProgress = 100f;
}