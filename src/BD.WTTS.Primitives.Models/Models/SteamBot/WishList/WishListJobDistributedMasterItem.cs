namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial struct WishListJobDistributedMasterItem
{
    public Guid CommonTaskId { get; set; }

    public Guid GameId { get; set; }

    public bool AddWishtListSuccess { get; set; }

    public bool AddFollowGameSuccess { get; set; }
}
