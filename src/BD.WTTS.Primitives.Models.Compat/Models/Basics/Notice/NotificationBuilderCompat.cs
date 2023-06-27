// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <inheritdoc cref="IInterface"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class NotificationBuilderCompat : NotificationBuilderCompat.IInterface
{
    /// <summary>
    /// 默认通知标题
    /// </summary>
    public const string DefaultTitle = "Watt Toolkit";
    public const bool DefaultAutoCancel = true;
    public const Entrance DefaultEntrance = Entrance.Main;

    [Obsolete("Only compatible data result retention")]
    [MPKey(0), MP2Key(0)]
#pragma warning disable IDE1006 // 命名样式
    public bool? _Undetermined { get; set; }
#pragma warning restore IDE1006 // 命名样式

    [MPKey(1), MP2Key(1)]
    public string Title { get; set; } = DefaultTitle;

    [MPKey(2), MP2Key(2)]
    public string Content { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public NotificationType Type { get; set; }

    [MPKey(4), MP2Key(4)]
    public bool AutoCancel { get; set; } = DefaultAutoCancel;

    /// <inheritdoc cref="IInterface.Click"/>
    [MPKey(5), MP2Key(5)]
    public NotificationBuilderClickActionCompat? Click { get; set; }

    NotificationBuilderClickActionCompat.IInterface? IInterface.Click => Click;

    /// <inheritdoc cref="IInterface.Buttons"/>
    [MPKey(6), MP2Key(6)]
    public List<NotificationBuilderButtonActionCompat>? Buttons { get; set; }

    IReadOnlyList<NotificationBuilderButtonActionCompat.IInterface>? IInterface.Buttons => Buttons;

    [MPKey(7), MP2Key(7)]
    public string? ImageUri { get; set; }

    /// <inheritdoc cref="ImageDisplayType"/>
    [MPKey(8), MP2Key(8)]
    public ImageDisplayType ImageDisplayType { get; set; }

    [MPKey(9), MP2Key(9)]
    public string? AttributionText { get; set; }

    [MPKey(10), MP2Key(10)]
    public DateTimeOffset CustomTimeStamp { get; set; }

    /// <summary>
    /// 本地通知 Builder
    /// </summary>
    public interface IInterface
    {
        /// <summary>
        /// 通知标题
        /// <para>https://developer.android.google.cn/reference/androidx/core/app/NotificationCompat.Builder?hl=zh-cn#setContentTitle(java.lang.CharSequence)</para>
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 通知正文
        /// <para>https://developer.android.google.cn/reference/androidx/core/app/NotificationCompat.Builder?hl=zh-cn#setContentText(java.lang.CharSequence)</para>
        /// </summary>
        string Content { get; }

        /// <inheritdoc cref="NotificationType"/>
        NotificationType Type { get; }

        /// <summary>
        /// 点击通知时自动取消通知
        /// <para>https://developer.android.google.cn/reference/androidx/core/app/NotificationCompat.Builder?hl=zh-cn#setAutoCancel(boolean)</para>
        /// </summary>
        bool AutoCancel { get; }

        /// <inheritdoc cref="NotificationBuilderClickActionCompat.IInterface"/>
        NotificationBuilderClickActionCompat.IInterface? Click { get; }

        /// <summary>
        /// 通知的按钮组
        /// </summary>
        IReadOnlyList<NotificationBuilderButtonActionCompat.IInterface>? Buttons { get; }

        /// <summary>
        /// 通知的主要图片
        /// </summary>
        string? ImageUri { get; }

        /// <inheritdoc cref="ImageDisplayType"/>
        ImageDisplayType ImageDisplayType { get; }

        /// <summary>
        /// 署名文本
        /// <para>周年更新中的新增功能：如果你需要引用你的内容源，可以使用署名文本。 此文本始终显示在通知底部，与应用标识或通知时间戳一起显示。</para>
        /// <para>在不支持署名文本的旧 Windows 版本中，该文本仅显示为另一文本元素（假设你还没有达到最多的三个文本元素）。</para>
        /// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#attribution-text</para>
        /// </summary>
        string? AttributionText => null;

        /// <summary>
        /// 自定义时间戳
        /// <para>创建者更新中的新增功能：现在，你可以用自己的准确表示消息/信息/内容生成时间的时间戳替代系统提供的时间戳。 可在操作中心查看此时间戳。</para>
        /// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#custom-timestamp</para>
        /// </summary>
        DateTimeOffset CustomTimeStamp => default;
    }
}