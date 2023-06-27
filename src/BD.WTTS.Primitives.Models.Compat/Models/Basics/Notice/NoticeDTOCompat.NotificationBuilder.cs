// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

partial class NoticeDTOCompat : NotificationBuilderCompat.IInterface, NotificationBuilderClickActionCompat.IInterface
{
    string NotificationBuilderCompat.IInterface.Title => Title;

    string NotificationBuilderCompat.IInterface.Content => Introduction;

    NotificationType NotificationBuilderCompat.IInterface.Type => Type;

    bool NotificationBuilderCompat.IInterface.AutoCancel => NotificationBuilderCompat.DefaultAutoCancel;

    NotificationBuilderClickActionCompat.IInterface? NotificationBuilderCompat.IInterface.Click => this;

    IReadOnlyList<NotificationBuilderButtonActionCompat.IInterface>? NotificationBuilderCompat.IInterface.Buttons => null;

    string? NotificationBuilderCompat.IInterface.ImageUri => Picture;

    ImageDisplayType NotificationBuilderCompat.IInterface.ImageDisplayType => default;

    Entrance NotificationBuilderClickActionCompat.IInterface.Entrance => IsOpenBrowser ? Entrance.Browser : Entrance.Main;

    string? NotificationBuilderClickActionCompat.IInterface.RequestUri => Url;

    Action? NotificationBuilderClickActionCompat.IInterface.Action => null;
}