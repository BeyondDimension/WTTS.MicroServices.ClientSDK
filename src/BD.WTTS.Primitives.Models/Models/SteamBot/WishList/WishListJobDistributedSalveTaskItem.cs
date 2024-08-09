namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial struct WishListJobDistributedSalveTaskItem
{
    public Guid CommonTaskId { get; set; }

    public Guid GameId { get; set; }

    public bool UseUnLimitedUser { get; set; }

    public bool AddWishtList { get; set; }

    public bool AddFollowGame { get; set; }
}
