using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Models;

public partial class ClashHistory
{
    [JsonPropertyName("delay")]
    public int Delay { get; set; }

    [JsonPropertyName("time")]
    public DateTimeOffset Time { get; set; }

    [JsonIgnore]
    public bool IsAvailable => Delay > 0;
}
