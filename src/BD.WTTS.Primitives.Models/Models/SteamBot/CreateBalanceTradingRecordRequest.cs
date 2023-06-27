namespace BD.WTTS.Models;

//[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record CreateBalanceTradingRecordRequest
{
    public CreateBalanceTradingRecordRequest(decimal spentAmount, CurrencyCode currencyCode, string presentingArea, ulong receiverSteam64Id, string inviteUrl)
    {
        SpentAmount = spentAmount;
        CurrencyCode = currencyCode;
        PresentingArea = presentingArea;
        ReceiverSteam64Id = receiverSteam64Id;
        InviteUrl = inviteUrl;
    }

    /// <summary>
    /// 订单金额
    /// </summary>
    // [MPKey(0), MP2Key(0)]
    public decimal SpentAmount { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    // [MPKey(1), MP2Key(1)]
    public CurrencyCode CurrencyCode { get; set; }

    /// <summary>
    /// 发送礼品区域
    /// </summary>
    //  [MPKey(2), MP2Key(2)]
    public string PresentingArea { get; set; }

    /// <summary>
    /// 接收人Steam Id （非必填，可由邀请链接生成 但当无法聪邀请链接中获取时抛出异常）
    /// </summary>
    // [MPKey(3), MP2Key(3)]
    [Required]
    public ulong ReceiverSteam64Id { get; set; }

    /// <summary>
    /// 邀请链接
    /// </summary>
    // [MPKey(4), MP2Key(4)]
    [Required]
    [RegularExpression("^(((ht|f)tps?):\\/\\/)?([^!@#$%^&*?.\\s-]([^!@#$%^&*?.\\s]{0,63}[^!@#$%^&*?.\\s])?\\.)+[a-z]{2,6}\\/?", ErrorMessage = "邀请链接格式错误")]
    public string InviteUrl { get; set; }
}
