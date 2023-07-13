namespace BD.WTTS.Models;

public class PubPayState
{
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 支付 Url
    /// </summary>
    public string? Url { get; set; }
}
