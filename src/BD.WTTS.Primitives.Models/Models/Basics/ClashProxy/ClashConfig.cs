using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Models;

public partial class ClashConfig
{
    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("socks-port")]
    public int SocksPort { get; set; }

    [JsonPropertyName("mixed-port")]
    public int MixedPort { get; set; }

    //direct  rule  global  script
    [JsonPropertyName("mode")]
    public string Mode { get; set; } = "global";

    [JsonPropertyName("ipv6")]
    public bool Ipv6 { get; set; }

    [JsonPropertyName("allow-lan")]
    public bool AllowLan { get; set; }
}
