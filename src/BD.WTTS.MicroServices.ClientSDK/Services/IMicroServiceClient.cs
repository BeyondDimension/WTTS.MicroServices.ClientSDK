namespace BD.WTTS.Services;

/// <summary>
/// 瓦特工具箱 微服务 Web API 客户端侧调用 SDK Client
/// </summary>
public partial interface IMicroServiceClient
{
    /// <summary>
    /// 禁用客户端本地模型验证
    /// </summary>
    static bool DisableModelValidator { get; set; }

    string ApiBaseUrl { get; }

    /// <inheritdoc cref="IApiConnection.DownloadAsync(CancellationToken, string, string, IProgress{float}?, bool, bool, string?, bool)"/>
    Task<IApiRsp> Download(bool isAnonymous, string requestUri, string cacheFilePath, IProgress<float>? progress, CancellationToken cancellationToken = default);

    Task<string> Info();

    static IMicroServiceClient Instance => Ioc.Get<IMicroServiceClient>();

    interface ISettings
    {
        string? ApiBaseUrl { get; set; }

        RSA RSA { get; }
    }

    static Serializable.ImplType SerializableImplType { get; set; } = Serializable.ImplType.MemoryPack;

}
