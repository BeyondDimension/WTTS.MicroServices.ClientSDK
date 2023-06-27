// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

public class AppDetail
{
    [JsonPropertyName("data")]
    public AppDetailData? Data { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

public class AppDetailData
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("steam_appid")]
    public int SteamAppId { get; set; }

    [JsonPropertyName("developers")]
    public string[]? Developers { get; set; }

    [JsonPropertyName("publishers")]
    public string[]? Publishers { get; set; }

    [JsonPropertyName("required_age")]
    public JsonElement RequiredAge { get; set; }

    [JsonPropertyName("is_free")]
    public bool IsFree { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; } = string.Empty;

    [JsonPropertyName("detailed_description")]
    public string DetailedDescription { get; set; } = string.Empty;

    [JsonPropertyName("fullgame")]
    public FullGame? FullGame { get; set; }

    [JsonPropertyName("supported_languages")]
    public string? SupportedLanguages { get; set; }

    [JsonPropertyName("website")]
    public string WebSite { get; set; } = string.Empty;

    [JsonPropertyName("dlc")]
    public int[]? DLC { get; set; }

    [JsonPropertyName("platforms")]
    public Platforms? Platforms { get; set; }

    [JsonPropertyName("pc_requirements")]
    public JsonElement PcRequirements { get; set; }

    [JsonPropertyName("linux_requirements")]
    public JsonElement LinuxRequirements { get; set; }

    [JsonPropertyName("mac_requirements")]
    public JsonElement MacRequirements { get; set; }

    [JsonPropertyName("screenshots")]
    public List<Screenshot>? Screenshots { get; set; }

    [JsonPropertyName("movies")]
    public List<Movie>? Movies { get; set; }

    [JsonPropertyName("header_image")]
    public string HeaderImage { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public ReleaseDate? ReleaseDate { get; set; }

    [JsonPropertyName("package_groups")]
    public List<PackageGroup>? PackageGroups { get; set; }
}

public class FullGame
{
    [JsonPropertyName("appid")]
    public string AppId { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

public class Platforms
{
    [JsonPropertyName("linux")]
    public bool Linux { get; set; }

    [JsonPropertyName("mac")]
    public bool Mac { get; set; }

    [JsonPropertyName("windows")]
    public bool Windows { get; set; }
}

public class Requirements
{
    [JsonPropertyName("minimum")]
    public string Minimum { get; set; } = string.Empty;

    [JsonPropertyName("recommended")]
    public string Recommended { get; set; } = string.Empty;
}

public class Screenshot
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("path_full")]
    public string PathFull { get; set; } = string.Empty;

    [JsonPropertyName("path_thumbnail")]
    public string PathThumbnail { get; set; } = string.Empty;
}

public class Movie
{
    [JsonPropertyName("highlight")]
    public bool HighLight { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("mp4")]
    public MovieItem? Mp4 { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; } = string.Empty;

    [JsonPropertyName("webm")]
    public MovieItem? Webm { get; set; }
}

public class MovieItem
{
    [JsonPropertyName("480")]
    public string Pix480 { get; set; } = string.Empty;

    [JsonPropertyName("max")]
    public string Max { get; set; } = string.Empty;
}

public class ReleaseDate
{
    /// <summary>
    /// 是否即将上线
    /// </summary>
    [JsonPropertyName("coming_soon")]
    public bool ComingSoon { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;
}

public class PackageGroup
{
    [JsonPropertyName("display_type")]
    public JsonElement DisplayType { get; set; }

    [JsonPropertyName("subs")]
    public List<Sub>? Subs { get; set; }
}

public class Sub
{
    [JsonPropertyName("packageid")]
    public int PackageId { get; set; }

    [JsonPropertyName("option_text")]
    public string OptionText { get; set; } = string.Empty;
}