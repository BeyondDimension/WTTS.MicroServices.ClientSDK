using ApiResponseCode = BD.WTTS.Enums.ApiRspCode;

namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// 微服务接口响应模型类
/// </summary>
[GenerateTypeScript]
public abstract class ApiRspBase : IApiRsp
{
    ApiResponseCode mCode;
    bool mIsSuccess;

    [MPKey(0), MP2Key(0)]
#if __HAVE_N_JSON__
    [N_JsonProperty("🦄")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("🦄")]
#endif
    public ApiResponseCode Code
    {
        get => mCode;
        set
        {
            mCode = value;
            // https://github.com/dotnet/corefx/blob/v3.1.6/src/System.Net.Http/src/System/Net/Http/HttpResponseMessage.cs#L143
            var code = (int)mCode;
            mIsSuccess = code >= 200 && code <= 299;
        }
    }

    [MPKey(LastMKeyIndex), MP2Key(LastMKeyIndex)]
#if __HAVE_N_JSON__
    [N_JsonProperty("🐴")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("🐴")]
#endif
    public string? InternalMessage { get; set; }

    string? IApiRsp.InternalMessage
    {
        get => InternalMessage;
        set => InternalMessage = value;
    }

    /// <summary>
    /// 最后一个 MessagePack 序列化 下标，继承自此类，新增需要序列化的字段/属性，标记此值+1，+2
    /// </summary>
    protected const int LastMKeyIndex = 1;

    [IgnoreDataMember]
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public bool IsSuccess => mIsSuccess;

    /// <summary>
    /// 用于在客户端上纪录本次请求中出现的异常
    /// </summary>
    [IgnoreDataMember]
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public Exception? ClientException { get; set; }

    /// <summary>
    /// 用于在客户端上纪录本次请求的 Url
    /// </summary>
    [IgnoreDataMember]
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string? Url { get; set; }
}