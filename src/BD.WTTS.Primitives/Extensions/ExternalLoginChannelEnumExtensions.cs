// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class ExternalLoginChannelEnumExtensions
{
    /// <summary>
    /// 当前快速登录渠道是否已支持
    /// </summary>
    /// <param name="externalLoginChannel"></param>
    /// <returns></returns>
    public static bool IsSupported(this ExternalLoginChannel externalLoginChannel)
#if DEBUG
        => true;
#else
        => externalLoginChannel switch
        {
            ExternalLoginChannel.Steam or
            ExternalLoginChannel.Microsoft or
            ExternalLoginChannel.QQ => true,
            _ => false,
        };
#endif
}
