namespace BD.WTTS.Enums;

public enum UploadFileItemCodes : byte
{
    /// <summary>
    /// 上传完成
    /// </summary>
    Ok = 1,

    /// <summary>
    /// 文件保存失败
    /// </summary>
    SaveFileFailure = 2,

    /// <summary>
    /// 不支持的文件类型
    /// </summary>
    FilesUnsupportedType = 3,

    /// <summary>
    /// 插入数据库失败
    /// </summary>
    InsertDataBaseFailure = 4,

    /// <summary>
    /// 文件头错误
    /// </summary>
    ImageFileHeaderError = 5,

    /// <summary>
    /// 文件扩展名错误
    /// </summary>
    ImageExtensionError = 6,

    /// <summary>
    /// 文件超出大小限制
    /// </summary>
    FileSizeError = 7,
}
