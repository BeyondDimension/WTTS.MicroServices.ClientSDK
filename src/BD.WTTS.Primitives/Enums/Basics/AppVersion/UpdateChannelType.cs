// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 下载更新渠道类型
/// </summary>
public enum UpdateChannelType : byte
{
    /// <summary>
    /// 自动选择渠道
    /// </summary>
    Auto,

    /// <summary>
    /// https://github.com/BeyondDimension/SteamTools/releases
    /// </summary>
    GitHub,

    /// <summary>
    /// https://gitee.com/rmbgame/SteamTools/releases
    /// </summary>
    [Obsolete("use GitHub, Because the Gitee speed limit is too low to be used normally.")]
    Gitee,

    /// <summary>
    /// 腾讯云 CDN
    /// </summary>
    [Obsolete("use Official")]
    TencentCloudCDN,

    /// <summary>
    /// 阿里云 CDN
    /// </summary>
    [Obsolete("use Official")]
    AlibabaCloudCDN,

    /// <summary>
    /// 微软 Azure 世纪互联版 CDN
    /// </summary>
    [Obsolete("use Official")]
    AzureChinaCDN,

    /// <summary>
    /// 微软 Azure 全球版 CDN
    /// </summary>
    [Obsolete("use Official")]
    AzureGlobalCDN,

    /// <summary>
    /// 优刻得 CDN
    /// </summary>
    [Obsolete("use Official")]
    UCloudCDN,

    /// <summary>
    /// 从官方服务器上下载更新
    /// </summary>
    Official = byte.MaxValue,
}