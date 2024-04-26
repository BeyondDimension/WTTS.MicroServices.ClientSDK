namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial record class XunYouVipEndTimeResponseData
{
    [MPKey(0), MP2Key(0)]
    [JsonPropertyName("server_time")]
    public long ServerTime { get; set; }

    [MPKey(1), MP2Key(1)]
    [JsonPropertyName("svip")]
    public XunYouVipEndTimeResponseDataSVIP? SVIP { get; set; }

    /// <summary>
    /// 到期时间 UnixSeconds
    /// </summary>
    [MPKey(2), MP2Key(2)]
    [JsonPropertyName("etime")]
    public long ExpireTime { get; set; }
}