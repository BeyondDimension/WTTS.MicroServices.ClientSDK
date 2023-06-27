// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <inheritdoc cref="IInterface"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class NotificationBuilderClickActionCompat : NotificationBuilderClickActionCompat.IInterface
{
    [MPConstructor, MP2Constructor]
    public NotificationBuilderClickActionCompat()
    {

    }

    public NotificationBuilderClickActionCompat(string requestUri)
    {
        RequestUri = requestUri;
        Entrance = Entrance.Browser;
    }

    [Obsolete("delegate implementation difficulties")]
    public NotificationBuilderClickActionCompat(Action action)
    {
        Action = action;
        Entrance = Entrance.Delegate;
    }

    [MPKey(0), MP2Key(0)]
    public Entrance Entrance { get; set; } = NotificationBuilderCompat.DefaultEntrance;

    [MPKey(1), MP2Key(1)]
    public string? RequestUri { get; set; }

    [MPIgnore, MP2Ignore]
    public Action? Action { get; set; }

    [MPKey(LAST_MP_INDEX), MP2Key(LAST_MP_INDEX)]
    public string? TabItemId { get; set; }

    protected const int LAST_MP_INDEX = 2;

    /// <summary>
    /// 点击该通知的事件或跳转页面或打开浏览器等
    /// </summary>
    public interface IInterface
    {
        /// <summary>
        /// 点击通知的入口点
        /// </summary>
        Entrance Entrance { get; }

        /// <summary>
        /// 入口点为 <see cref="Entrance.Browser"/> 时的 HttpUrl
        /// </summary>
        string? RequestUri { get; }

        /// <summary>
        /// 入口点为 <see cref="Entrance.Delegate"/> 时的 Delegate
        /// </summary>
        Action? Action { get; }

        /// <summary>
        /// 用于当使用 <see cref="Entrance.Main"/> 时，进入的 Tab 子页面，值为 System.Application.UI.ViewModels.TabItemViewModel.TabItemId
        /// </summary>
        string? TabItemId => null;
    }
}