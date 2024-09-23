using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Models;

[JsonSerializable(typeof(ClashConfig))]
[JsonSerializable(typeof(ClashProxies))]
[JsonSerializable(typeof(ClashHistory))]
public partial class ClashProxyJsonSerializerContext : JsonSerializerContext
{
}
