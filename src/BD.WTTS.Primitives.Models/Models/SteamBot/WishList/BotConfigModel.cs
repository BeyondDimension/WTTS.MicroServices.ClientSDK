namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial struct BotConfigModel
{
    public string? BotName { get; set; }

    public string? UserName { get; set; }

    public string? WebAPIKey { get; set; }

    public string? Password { get; set; }

    public string? SharedSecret { get; set; }

    public string? IdentitySecret { get; set; }
}
