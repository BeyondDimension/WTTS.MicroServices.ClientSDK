// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 查询 Steam AppId 是否存在于用户愿望单中请求
/// </summary>
/// <param name="SteamUserId64"> Steam 用户 Id</param>
/// <param name="AppId"> Steam AppId </param>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
#if !MVVM_VM
[GenerateTypeScript]
#endif
public sealed partial record class QuerySteamAppIdExistsWishListRequest(
    [property: MPKey(0), MP2Key(0)] long SteamUserId64,
    [property: MPKey(1), MP2Key(1)] int AppId);