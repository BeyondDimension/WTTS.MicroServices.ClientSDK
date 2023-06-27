using ApiResponse = BD.WTTS.ApiRspHelper;
using ApiResponseCode = BD.WTTS.Enums.ApiRspCode;
using ApiResponseImpl = BD.WTTS.Models.Abstractions.ApiRspBase;

namespace BD.WTTS.Models;

/// <inheritdoc cref="ApiResponseImpl"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ApiRsp<T> : ApiResponseImpl, IApiRsp<T>
{
    [MPKey(LastMKeyIndex + 1), MP2Key(LastMKeyIndex + 1)]
#if __HAVE_N_JSON__
    [N_JsonProperty("🦓")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("🦓")]
#endif
    public T? Content { get; set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp<T?>(T content) => ApiResponse.Ok(content);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp<T?>(ApiResponseCode code) => ApiResponse.Code<T>(code);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp<T?>((ApiResponseCode code, string? message) args) => ApiResponse.Code<T>(args.code, args.message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp<T?>(string? message) => ApiResponse.Fail<T>(message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp<T?>(Exception exception) => ApiResponse.Exception<T>(exception);
}