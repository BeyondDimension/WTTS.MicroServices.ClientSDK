// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

public class AppPackage
{
    [JsonPropertyName("data")]
    public AppPackageData? Data { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

public class AppPackageData
{
    [JsonPropertyName("apps")]
    public List<GameApp>? Apps { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("header_image")]
    public string? HeaderImage { get; set; }

    [JsonPropertyName("release_date")]
    public ReleaseDate? ReleaseDate { get; set; }

    [JsonPropertyName("price")]
    public Price? Price { get; set; }
}

public class GameApp
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class Price
{
    /// <summary>
    /// 货币 Code
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// 折扣百分比
    /// </summary>
    [JsonPropertyName("discount_percent")]
    public int DiscountPercent { get; set; }

    /// <summary>
    /// 折后价格
    /// </summary>（单位 分/ cent）
    [JsonPropertyName("final")]
    public decimal Final { get; set; }

    /// <summary>
    /// 该游戏里的单品最低原价（单位 分/ cent）
    /// </summary>
    [JsonPropertyName("individual")]
    public decimal Individual { get; set; }

    /// <summary>
    /// 原始价格（单位 分/ cent）
    /// </summary>
    [JsonPropertyName("initial")]
    public decimal Initial { get; set; }
}
