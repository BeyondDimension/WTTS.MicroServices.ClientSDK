namespace BD.WTTS.Models;

/// <summary>
/// 批量创建 产品密钥 请求
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record BatchCreateProductKeyRecordRequest
{
    /// <summary>
    /// 充值物品id
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 批量创建数量
    /// </summary>
    [MPKey(1), MP2Key(1)]
    [Required(ErrorMessageResourceType = typeof(BD.WTTS.R.Strings), ErrorMessageResourceName = nameof(BD.WTTS.R.Strings.L10nSdk_RechargeCountInvalid))]
    public int Count { get; set; }

    /// <summary>
    /// 充值物品面额
    /// </summary>
    [MPKey(2), MP2Key(2)]
    [Required(ErrorMessageResourceType = typeof(BD.WTTS.R.Strings), ErrorMessageResourceName = nameof(BD.WTTS.R.Strings.L10nSdk_RechargeAmountInvalid))]
    public decimal Amount { get; set; }

    [MPKey(3), MP2Key(3)]
    public Guid? CreateUserId { get; set; }
}