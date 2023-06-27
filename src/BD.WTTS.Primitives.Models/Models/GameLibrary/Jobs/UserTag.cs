// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

public class UserTag
{
    [JsonPropertyName("tagid")]
    public int TagId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
