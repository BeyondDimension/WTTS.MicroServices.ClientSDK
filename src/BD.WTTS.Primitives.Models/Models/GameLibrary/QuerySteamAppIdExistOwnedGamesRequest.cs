namespace BD.WTTS.Models;

/// <summary>
/// 查询 Steam AppId 是否存在于用户已拥有游戏中请求
/// </summary>
/// <param name="SteamUserId64"> Steam 用户 Id</param>
/// <param name="AppId"> Steam AppId </param>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record QuerySteamAppIdExistOwnedGamesRequest(
    [property: MPKey(0), MP2Key(0)] long SteamUserId64,
    [property: MPKey(1), MP2Key(1)] int AppId);
