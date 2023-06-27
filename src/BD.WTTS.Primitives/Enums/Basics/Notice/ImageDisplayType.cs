// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 图片显示类型
/// <para>图像大小限制</para>
/// <para>Toast 通知中使用的图像可源自以下位置...</para>
/// <para>http://</para>
/// <para>(Impl中验证函数未支持未测试)ms-appx:///</para>
/// <para>(Impl中验证函数未支持未测试)ms-appdata:///</para>
/// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#image-size-restrictions</para>
/// </summary>
public enum ImageDisplayType : byte
{
    /// <summary>
    /// 主图
    /// <para>周年更新的新增功能：toast 可显示主图，这是在 toast 横幅中以及在操作中心时突出显示的特别 ToastGenericHeroImage。 图像尺寸在 100% 缩放时为 364x180 像素。</para>
    /// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#hero-image</para>
    /// </summary>
    HeroImage,

    /// <summary>
    /// 内联图像
    /// <para>可提供在展开 toast 时显示的全宽内联图像。</para>
    /// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#inline-image</para>
    /// </summary>
    InlineImage,
}
