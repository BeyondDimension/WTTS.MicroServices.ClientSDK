// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <inheritdoc cref="IInterface"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class NotificationBuilderButtonActionCompat : NotificationBuilderClickActionCompat, NotificationBuilderButtonActionCompat.IInterface
{
    [MPConstructor, MP2Constructor]
    public NotificationBuilderButtonActionCompat()
    {

    }

    public NotificationBuilderButtonActionCompat(string text, string requestUri) : base(requestUri)
    {
        Text = text;
    }

    [Obsolete("delegate implementation difficulties")]
    public NotificationBuilderButtonActionCompat(string text, Action action) : base(action)
    {
        Text = text;
    }

    /// <summary>
    /// 按钮文本
    /// </summary>
    [MPKey(LAST_MP_INDEX + 1), MP2Key(LAST_MP_INDEX + 1)]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 点击按钮的事件或跳转页面或打开浏览器等
    /// <para>https://docs.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax#buttons</para>
    /// </summary>
    public new interface IInterface : NotificationBuilderClickActionCompat.IInterface
    {
        /// <summary>
        /// 按钮文本
        /// </summary>
        string Text { get; }
    }
}