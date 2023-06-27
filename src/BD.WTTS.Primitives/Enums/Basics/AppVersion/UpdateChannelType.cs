// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 下载更新渠道类型
/// </summary>
public enum UpdateChannelType : byte
{
    /// <summary>
    /// 自动识别
    /// </summary>
    Auto,

    /// <summary>
    /// https://github.com/BeyondDimension/SteamTools/releases
    /// </summary>
    GitHub,

    /// <summary>
    /// https://gitee.com/rmbgame/SteamTools/releases
    /// </summary>
    Gitee,

    /// <summary>
    /// 腾讯云 CDN
    /// </summary>
    TencentCloudCDN,

    /// <summary>
    /// 阿里云 CDN
    /// </summary>
    AlibabaCloudCDN,

    /// <summary>
    /// 微软 Azure 世纪互联版 CDN
    /// </summary>
    AzureChinaCDN,

    /// <summary>
    /// 微软 Azure 全球版 CDN
    /// </summary>
    AzureGlobalCDN,

    /// <summary>
    /// 优刻得 CDN
    /// </summary>
    UCloudCDN,
}