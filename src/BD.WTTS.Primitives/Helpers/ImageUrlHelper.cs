namespace BD.WTTS.Helpers;

public static class ImageUrlHelper
{
    /// <summary>
    /// 与之前的版本兼容的函数，通过图片 Url 获取之前版本中使用的图片表主键
    /// </summary>
    /// <param name="imageUrl"></param>
    /// <returns></returns>
    public static Guid GetImageGuid(string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            return default;
        if (ShortGuid.TryParse(imageUrl.Split('/',
            StringSplitOptions.RemoveEmptyEntries).LastOrDefault(), out Guid guid))
            return guid;
        return default;
    }
}
