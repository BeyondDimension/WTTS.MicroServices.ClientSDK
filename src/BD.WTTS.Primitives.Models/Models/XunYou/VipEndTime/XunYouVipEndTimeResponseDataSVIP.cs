namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class XunYouVipEndTimeResponseDataSVIP
{
    /// <summary>
    /// SVIP 到期时间
    /// </summary>
    [JsonPropertyName("etime")]
    [MPKey(0), MP2Key(0)]
    public long ETime { get; set; }

    [JsonPropertyName("expire_time")]
    [MPKey(1), MP2Key(1)]
    public long ExpireTime { get; set; }

    [JsonPropertyName("gift_begin_time")]
    [MPKey(2), MP2Key(2)]
    public long GiftBeginTime { get; set; }

    [JsonPropertyName("rtime")]
    [MPKey(3), MP2Key(3)]
    public long RTime { get; set; }

    [JsonPropertyName("service_type")]
    [MPKey(4), MP2Key(4)]
    public string? ServiceType { get; set; }
}
