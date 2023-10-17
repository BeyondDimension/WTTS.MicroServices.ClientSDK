namespace BD.WTTS.Models.SteamRecharge;

/// <summary>
/// 批量创建 产品密钥 请求
/// </summary>
public sealed partial class BatchCreateProductKeyRecordRequest
{
    /// <summary>
    /// 充值物品id
    /// </summary>
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 批量创建数量
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 充值物品面额
    /// </summary>
    public decimal Amount { get; set; }

    public Guid? CreateUserId { get; set; }
}
