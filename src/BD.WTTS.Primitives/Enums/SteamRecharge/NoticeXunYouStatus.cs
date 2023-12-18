// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

public enum NoticeXunYouStatus
{
    [Description("待通知")]
    WaitNotice = 0,

    [Description("通知失败")]
    NoticeFail = 1,

    [Description("通知完成")]
    NoticeFinish = 3
}