namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class UserWalletChangeRecordListItem
{
    /// <summary>
    /// 变更类型
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public UserWalletChangeType Type { get; set; }

    /// <summary>
    /// 变更原因
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? Reason { get; set; }

    /// <summary>
    /// 支付方向
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public UserWalletPaymentDirection PaymentDirection { get; set; }

    /// <summary>
    /// 变更值
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public decimal Value { get; set; }

    /// <summary>
    /// 账号余额
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public decimal AccountBalance { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? Remarks { get; set; }

    /// <summary>
    /// 变更时间
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public DateTimeOffset CreationTime { get; set; }
}
