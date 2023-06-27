// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 根据 Steam 64 位用户 Id 查询 Steam 用户的愿望单 - 请求模型
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class QuerySteamWishListRequest(
    [property: MPKey(0), MP2Key(0)] long SteamUserId64);