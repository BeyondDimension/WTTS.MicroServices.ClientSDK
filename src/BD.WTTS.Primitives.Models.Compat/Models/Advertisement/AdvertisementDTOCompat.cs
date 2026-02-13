// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AdvertisementDTOCompat
#if MVVM_VM
        : BaseNotifyPropertyChanged
#endif
{
    [MPKey(0), MP2Key(0)]
#if __HAVE_N_JSON__
    [N_JsonProperty("0")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("0")]
#endif
    public Guid Id { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [MPKey(1), MP2Key(1)]
#if __HAVE_N_JSON__
    [N_JsonProperty("1")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("1")]
#endif
    public int Order { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [MPKey(2), MP2Key(2)]
#if __HAVE_N_JSON__
    [N_JsonProperty("2")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("2")]
#endif
    public string? Remark { get; set; }

    /// <summary>
    /// 广告类型
    /// </summary>
    [MPKey(3), MP2Key(3)]
#if __HAVE_N_JSON__
    [N_JsonProperty("3")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("3")]
#endif
    public AdvertisementType Type { get; set; }

    /// <summary>
    /// 广告规格
    /// </summary>
    [MPKey(4), MP2Key(4)]
#if __HAVE_N_JSON__
    [N_JsonProperty("4")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("4")]
#endif
    public AdvertisementOrientation Standard { get; set; }

#if MVVM_VM

    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
        [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
    public Task<ImageSource.ClipStream?>? ImageUrl
        => ImageSource.GetAsync(Constants.Urls.GetAdvertisementImageUrl(Id), cache: true);

    //    [MPIgnore, MP2Ignore]
    //#if __HAVE_N_JSON__
    //        [N_JsonIgnore]
    //#endif
    //#if !__NOT_HAVE_S_JSON__
    //    [S_JsonIgnore]
    //#endif
    //    public string Url => Constants.Urls.GetAdvertisementJumpUrl(Id);
#endif

#endif
}