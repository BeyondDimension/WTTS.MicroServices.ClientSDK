using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Models;

public partial class ClashProxies
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("udp")]
    public bool IsUdp { get; set; }

    [JsonPropertyName("history")]
    public List<ClashHistory>? History { get; set; }
}
