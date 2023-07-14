// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 插件付费订单DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginPaymentOrderDTO { }

/// <summary>
/// 插件价格DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginPriceDTO { }

/// <summary>
/// 插件分类DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginCategoryDTO
{
    /// <summary>
    /// 主键
    /// </summary>
    [IgnoreDataMember]
    [MPIgnore, MP2Ignore]
    public Guid Id { get; set; }

    /// <summary>
    /// 分类编码
    /// </summary>
    public string CategoryCode { get; set; } = "";

    /// <summary>
    /// 分类名称
    /// </summary>
    public string CategoryName { get; set; } = "";
}

/// <summary>
/// 插件包DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginPackageDTO { }

/// <summary>
/// 插件图片DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginImageDTO { }

/// <summary>
/// 插件多语言支持DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginMultiLanguageSupportDTO { }

/// <summary>
/// 插件开发者认证DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginDeveloperCertificationDTO { }

/// <summary>
/// 插件模块DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginModuleDTO { }

/// <summary>
/// 插件用户已拥有DTO
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PluginUserOwnedDTO { }
