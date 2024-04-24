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
}