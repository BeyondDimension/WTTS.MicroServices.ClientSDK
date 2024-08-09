namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial struct WishListJobDistributedSalveModel()
{
    public BotConfigModel BotConfig { get; set; }

    public TimeSpan WaitSpan { get; set; }

    public ImmutableArray<WishListJobDistributedSalveTaskItem> Items { get; set; } = default;

}
