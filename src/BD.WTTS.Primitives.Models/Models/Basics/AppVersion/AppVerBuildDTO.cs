// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 客户端版本构建
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AppVerBuildDTO
{
    /// <summary>
    /// 分发渠道
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public ClientDistributionChannel ClientDistributionChannel { get; set; }

    /// <summary>
    /// 客户端设备
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public ClientPlatform ClientDeviceType { get; set; }

    /// <summary>
    /// (单选)应用程序部署模式
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public DeploymentMode DeploymentMode { get; set; }

    /// <summary>
    /// 可更新时间
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public DateTimeOffset? AvailableTime { get; set; }

    ///// <summary>
    ///// 客户端文件
    ///// </summary>
    //[MPKey(5), MP2Key(5)]
    //public List<AppVerFileDTO> Files { get; set; } = new();
}
