// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 获取赞助用户排行分页列表响应数据
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class RankingResponseCompat
{
    /// <summary>
    /// 用户昵称 
    /// </summary>
    [MPKey(0), MP2Key(0)]
#if __HAVE_N_JSON__
    [N_JsonProperty("0")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("0")]
#endif
    public string? Name { get; set; }

    /// <summary>
    /// 用户头像
    /// </summary>
    [MPKey(1), MP2Key(1)]
#if __HAVE_N_JSON__
    [N_JsonProperty("1")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("1")]
#endif
    public string? Avatar { get; set; }

    /// <summary>
    /// 赞助月份
    /// </summary>
    [MPKey(2), MP2Key(2)]
#if __HAVE_N_JSON__
    [N_JsonProperty("2")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("2")]
#endif
    public int Month { get; set; }

    /// <summary>
    /// 捐助平台
    /// </summary>
    [MPKey(3), MP2Key(3)]
#if __HAVE_N_JSON__
    [N_JsonProperty("3")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("3")]
#endif
    public SponsorPlatformType Type { get; set; }

    /// <summary>
    /// 赞助金额
    /// </summary>
    [MPKey(4), MP2Key(4)]
#if __HAVE_N_JSON__
    [N_JsonProperty("4")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("4")]
#endif
    public decimal Amount { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [MPKey(5), MP2Key(5)]
#if __HAVE_N_JSON__
    [N_JsonProperty("5")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("5")]
#endif
    public CurrencyCode CurrencyCode { get; set; }
}

#if MVVM_VM
partial class RankingResponseCompat : BaseNotifyPropertyChanged
{

}
#endif