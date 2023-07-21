// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 静态资源文件类型
/// </summary>
public enum CloudFileType
{
    // 不使用值为 0 的

    #region ImageFormat 1~255 值用于图片类型

    BMP = ImageFormat.BMP,
    GIF = ImageFormat.GIF,
    ICO = ImageFormat.ICO,
    JPEG = ImageFormat.JPEG,
    PNG = ImageFormat.PNG,
    WebP = ImageFormat.WebP,
    HEIF = ImageFormat.HEIF,
    HEIFSequence = ImageFormat.HEIFSequence,
    HEIC = ImageFormat.HEIC,
    HEICSequence = ImageFormat.HEICSequence,

    #endregion

    #region 256~xxx 待定

    WinExe = 256,
    TarGzip,
    SevenZip,
    TarBrotli,
    TarXz,
    TarZstd,
    DMG,
    DEB,
    RPM,
    APK,

    #endregion

    Json = 300,
    Dll,
    Xml,
    So,
    Dylib,
    None,
    Js,
    Xaml,
    AXaml,
    CSharp,

    Msix = 901,
    MsixUpload,
}

public static class CloudFileTypeEnumExtensions
{
    /// <summary>
    /// 将 <see cref="CloudFileType"/> 转换为 <see cref="ImageFormat"/>，值不为图片类型时将返回默认值
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ImageFormat GetImageFormat(this CloudFileType type)
    {
        int value = Enum2.ConvertToInt32(type);
        if (value > 0 && value < byte.MaxValue)
        {
            byte value2 = Convert.ToByte(value);
            return (ImageFormat)value2;
        }
        return default;
    }

    /// <summary>
    /// 扩展名或者图片类型识别是否是支持的文件类型
    /// </summary>
    /// <param name="extension"></param>
    /// <param name="imageFormat"></param>
    /// <returns></returns>
    public static CloudFileType? GetFileFormat(this string extension, ImageFormat? imageFormat)
    {
        if (imageFormat.HasValue)
        {
            int value = Enum2.ConvertToInt32(imageFormat.Value);
            if (value > 0 && value < byte.MaxValue)
            {
                byte value2 = Convert.ToByte(value);
                return (CloudFileType)value2;
            }
        }
        else
        {
            switch (extension.ToLower())
            {
                case FileEx.EXE:
                    return CloudFileType.WinExe;
                case ".tar.gz":
                case FileEx.TAR_GZ:
                    return CloudFileType.TarGzip;
                case FileEx.TAR_XZ:
                    return CloudFileType.TarXz;
                case FileEx.TAR_ZST:
                    return CloudFileType.TarZstd;
                case FileEx.DMG:
                    return CloudFileType.DMG;
                case FileEx.DEB:
                    return CloudFileType.DEB;
                case FileEx.RPM:
                    return CloudFileType.RPM;
                case FileEx.APK:
                    return CloudFileType.RPM;
                default:
                    return null;
            }
        }
        return null;
    }
}
