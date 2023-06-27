using ApiResponse = BD.WTTS.ApiRspHelper;
using ApiResponseCode = BD.WTTS.Enums.ApiRspCode;
using ApiResponseImpl = BD.WTTS.Models.Abstractions.ApiRspBase;

namespace BD.WTTS.Models;

/// <inheritdoc cref="ApiResponseImpl"/>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ApiRsp : ApiResponseImpl, IApiRsp<object>
{
    [IgnoreDataMember]
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public object? Content => null;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp(ApiResponseCode code) => ApiResponse.Code(code);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp((ApiResponseCode code, string? message) args) => ApiResponse.Code(args.code, args.message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp(string? message) => ApiResponse.Fail(message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ApiRsp(Exception exception) => ApiResponse.Exception(exception);
}