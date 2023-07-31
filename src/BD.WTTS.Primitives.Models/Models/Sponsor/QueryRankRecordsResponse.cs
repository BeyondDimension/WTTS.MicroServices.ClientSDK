// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 获取赞助用户排行分页列表响应数据
/// </summary>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class QueryRankRecordsResponse
{
    /// <summary>
    /// 用户昵称 
    /// </summary>
    [MPKey(0), MP2Key(0)]
    public string? NickName { get; set; }

    /// <summary>
    /// 用户头像
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// 赞助月份
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public int Month { get; set; }

    /// <summary>
    /// 捐助平台
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public SponsorPlatformType SponsorPlatform { get; set; }

    /// <summary>
    /// 赞助金额
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public decimal Amount { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public CurrencyCode CurrencyCode { get; set; }
}

#if MVVM_VM
partial class QueryRankRecordsResponse : BaseNotifyPropertyChanged
{

}
#endif