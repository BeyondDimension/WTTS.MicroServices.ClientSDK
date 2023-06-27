using ApiResponseCode = BD.WTTS.Enums.ApiRspCode;

// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class ApiRspHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static IApiRsp<T?> ClientDeserializeFail<T>() => Code<T>(ApiResponseCode.ClientDeserializeFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Type GetDeserializeType<T>()
    {
        if (typeof(T) == typeof(object)) return typeof(ApiRsp);
        return typeof(ApiRsp<T>);
    }

    //public static IApiRsp<T> Deserialize<T>(
    //    Newtonsoft.Json.JsonSerializer jsonSerializer,
    //    Newtonsoft.Json.JsonReader jsonReader)
    //{
    //    var type = GetDeserializeType<T>();
    //    var obj = (IApiRsp<T>?)jsonSerializer.Deserialize(jsonReader, type);
    //    return obj ?? ClientDeserializeFail<T>();
    //}

    public static async ValueTask<IApiRsp<T?>> DeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var type = GetDeserializeType<T>();
        var obj = await MessagePackSerializer.DeserializeAsync(
            type, stream, options: Serializable.lz4Options, cancellationToken: cancellationToken);
        if (obj is IApiRsp<T?> rsp) return rsp;
        return ClientDeserializeFail<T>();
    }

    public static async ValueTask<IApiRsp<T?>> MemoryPackDeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var type = GetDeserializeType<T>();
            var obj = await MemoryPackSerializer.DeserializeAsync(
                type, stream, cancellationToken: cancellationToken);
            if (obj is IApiRsp<T?> rsp) return rsp;
            return ClientDeserializeFail<T>();
        }
        catch
        {
            var type = typeof(ApiRsp);
            var obj = await MemoryPackSerializer.DeserializeAsync(
                type, stream, cancellationToken: cancellationToken);
            if (obj is IApiRsp rsp) return Create<T>(rsp);
            return ClientDeserializeFail<T>();

        }
    }

    public static async ValueTask<IApiRsp<T?>> JsonPackDeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var type = GetDeserializeType<T>();
        var obj = await JsonSerializer.DeserializeAsync(
            stream, type, cancellationToken: cancellationToken);
        if (obj is IApiRsp<T?> rsp) return rsp;
        return ClientDeserializeFail<T>();
    }

    public static IApiRsp<T?> Deserialize<T>(byte[] buffer)
    {
        var type = GetDeserializeType<T>();
        var obj = MessagePackSerializer.Deserialize(type, buffer, options: Serializable.lz4Options);
        if (obj is IApiRsp<T?> rsp) return rsp;
        return ClientDeserializeFail<T>();
    }

    public static bool TryGetContent<T>(
         this IApiRsp<T> response,
         [NotNullWhen(true)] out T? content)
    {
        content = response.Content;
        return response.IsSuccess && content != null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp Code(ApiResponseCode code, string? message = null, Exception? exception = null) => new()
    {
        Code = code,
        InternalMessage = message,
        ClientException = exception,
    };

    static readonly Lazy<ApiRsp> okRsp = new(() => Code(ApiResponseCode.OK));

    public static ApiRsp Ok() => okRsp.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Code<T>(
        ApiResponseCode code,
        string? message,
        T? content,
        Exception? exception = null) => new()
        {
            Code = code,
            InternalMessage = message,
            Content = content,
            ClientException = exception,
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Code<T>(
        ApiResponseCode code,
        string? message = null) => Code<T>(code, message, default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Ok<T>(T? content = default)
        => Code(ApiResponseCode.OK, null, content);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Fail<T>(string? message = null)
        => Code<T>(ApiResponseCode.Fail, message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp Fail(string? message = null)
        => Code(ApiResponseCode.Fail, message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp Exception(Exception exception)
        => Code(ApiResponseCode.ClientException, null, exception);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Exception<T>(Exception exception)
        => Code<T>(ApiResponseCode.ClientException, null, default, exception);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? GetInternalMessage(IApiRsp response) => response.InternalMessage;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ApiRsp<T?> Create<T>(IApiRsp rsp) => rsp is ApiRsp<T?> rspT2 ? rspT2 : Code(rsp.Code, rsp.InternalMessage, rsp is IApiRsp<T?> rspT ? rspT.Content : default, rsp is ApiRspBase b ? b.ClientException : default);
}
