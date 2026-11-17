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

    public static async ValueTask<IApiRsp<T?>> DeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        if (typeof(T) == typeof(object))
        {
            var response = await MessagePackSerializer.DeserializeAsync<ApiRsp>(stream,
                options: Serializable.lz4Options, cancellationToken: cancellationToken);
            return response == null ? ClientDeserializeFail<T>() : (IApiRsp<T?>)(object)response;
        }
        return await MessagePackSerializer.DeserializeAsync<ApiRsp<T?>>(stream,
            options: Serializable.lz4Options, cancellationToken: cancellationToken) ?? ClientDeserializeFail<T>();
    }

    public static async ValueTask<IApiRsp<T?>> MemoryPackDeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        if (typeof(T) == typeof(object))
        {
            var response = await MemoryPackSerializer.DeserializeAsync<ApiRsp>(stream,
                cancellationToken: cancellationToken);
            return response == null ? ClientDeserializeFail<T>() : (IApiRsp<T?>)(object)response;
        }
        // Generated readers accept the shorter, content-free error envelope too.
        // Do not retry an already-consumed HTTP/CryptoStream after a format error.
        return await MemoryPackSerializer.DeserializeAsync<ApiRsp<T?>>(stream,
            cancellationToken: cancellationToken) ?? ClientDeserializeFail<T>();
    }

    public static async ValueTask<IApiRsp<T?>> JsonPackDeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var type = GetDeserializeType<T>();
        var obj = await JsonSerializer.DeserializeAsync(
            stream, ApiJsonSerializerContext.GetMetadata(type), cancellationToken: cancellationToken);
        if (obj is IApiRsp<T?> rsp) return rsp;
        return ClientDeserializeFail<T>();
    }

    public static IApiRsp<T?> Deserialize<T>(byte[] buffer)
    {
        if (typeof(T) == typeof(object))
        {
            var response = MessagePackSerializer.Deserialize<ApiRsp>(buffer, options: Serializable.lz4Options);
            return response == null ? ClientDeserializeFail<T>() : (IApiRsp<T?>)(object)response;
        }
        return MessagePackSerializer.Deserialize<ApiRsp<T?>>(buffer, options: Serializable.lz4Options) ?? ClientDeserializeFail<T>();
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
