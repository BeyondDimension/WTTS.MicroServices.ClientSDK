namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// 上传文件模型
/// </summary>
public interface IUploadFileSource : IExplicitHasValue, IDisposable
{
    /// <summary>
    /// 开启读取流
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Stream OpenRead() => File.OpenRead(FilePath);

    /// <summary>
    /// 所在本地文件路径
    /// </summary>
    string FilePath { get; }

    /// <summary>
    /// 媒体类型
    /// </summary>
    string MIME { get; set; }

    /// <summary>
    /// 是否为上传优化过的文件
    /// </summary>
    bool IsCompressed { get; }

    /// <summary>
    /// 是否为缓存文件
    /// </summary>
    bool IsCache { get; }

    UploadFileType UploadFileType { get; }

    /// <summary>
    /// 如果为缓存文件则删除文件
    /// </summary>
    /// <param name="uploadFile"></param>
    protected static void DeleteByCache(IUploadFileSource uploadFile)
    {
        if (uploadFile.IsCache &&
            !string.IsNullOrWhiteSpace(uploadFile.FilePath) &&
            File.Exists(uploadFile.FilePath))
        {
            File.Delete(uploadFile.FilePath);
        }
    }

    /// <summary>
    /// 当前模型是否可上传
    /// </summary>
    bool Available => true;
}