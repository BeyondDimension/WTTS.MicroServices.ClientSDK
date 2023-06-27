namespace BD.WTTS.Services.Implementation;

sealed class UploadFileContent : StreamContent
{
    readonly IUploadFileSource? uploadFile;

    UploadFileContent(Stream stream) : base(stream)
    {
        Headers.ContentLength = stream.Length;
    }

    public UploadFileContent(IUploadFileSource uploadFile, Stream stream) : this(stream)
    {
        this.uploadFile = uploadFile;
        if (string.IsNullOrEmpty(uploadFile.MIME))
            throw new NullReferenceException(nameof(uploadFile.MIME));
        Headers.ContentType = new MediaTypeHeaderValue(uploadFile.MIME);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            uploadFile?.Dispose();
        }
        base.Dispose(disposing);
    }
}
