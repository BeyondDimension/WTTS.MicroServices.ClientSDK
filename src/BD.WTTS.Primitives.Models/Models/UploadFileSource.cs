namespace BD.WTTS.Models;

public sealed class UploadFileSource : IUploadFileSource
{
    bool disposedValue;

    public string FilePath { get; set; } = string.Empty;

    public string MIME { get; set; } = string.Empty;

    public bool IsCompressed { get; set; }

    public bool IsCache { get; set; }

    public UploadFileType UploadFileType { get; set; }

    bool IExplicitHasValue.ExplicitHasValue() => !string.IsNullOrWhiteSpace(FilePath);

    void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // 释放托管状态(托管对象)
                IUploadFileSource.DeleteByCache(this);
            }

            // 释放未托管的资源(未托管的对象)并重写终结器
            // 将大型字段设置为 null
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
