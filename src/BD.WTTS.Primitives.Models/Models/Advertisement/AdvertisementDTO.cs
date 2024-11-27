// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class AdvertisementDTO
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
    public long Order { get; set; }

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
    public string? Describe { get; set; }

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

    /// <summary>
    /// 名字
    /// </summary>
    [MPKey(5), MP2Key(5)]
#if __HAVE_N_JSON__
    [N_JsonProperty("5")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("5")]
#endif
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// IsAuth
    /// </summary>
    [MPKey(6), MP2Key(6)]
#if __HAVE_N_JSON__
    [N_JsonProperty("6")]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonProperty("6")]
#endif
    public bool IsAuth { get; set; }

#if MVVM_VM

    /// <summary>
    /// 广告图片
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public Task<ImageSource.ClipStream?> ImageSrc
        => ImageSource.GetAsync(Constants.Urls.GetAdvertisementImageUrl(Id), cache: true);

    /// <summary>
    /// 广告图片Url
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string ImageUrl => Constants.Urls.GetAdvertisementImageUrl(Id);

    /// <summary>
    /// 广告点击跳转地址
    /// </summary>
    [MPIgnore, MP2Ignore]
#if __HAVE_N_JSON__
    [N_JsonIgnore]
#endif
#if !__NOT_HAVE_S_JSON__
    [S_JsonIgnore]
#endif
    public string Url => Constants.Urls.GetAdvertisementJumpUrl(Id, IsAuth);
#endif
}