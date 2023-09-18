// ReSharper disable once CheckNamespace

namespace BD.WTTS.Models;

public record class SteamBotTaskStatusChangedMsg
{
    public string? Id => TaskId;

    public string? TaskId { get; set; }

    public int Type { get; set; }

    public int OriginStatus { get; set; }

    public int CurrenStatus { get; set; }

    public string? Desc { get; set; }
}
