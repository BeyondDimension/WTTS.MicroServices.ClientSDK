namespace BD.WTTS.Models;

public class UploadFileResponseItem
{
    /// <summary>
    /// 文件名 前端匹配上传对应的 Item
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// 上传成功后 Url 地址
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// 文件状态码
    /// </summary>
    public UploadFileItemCodes Code { get; set; }
}
