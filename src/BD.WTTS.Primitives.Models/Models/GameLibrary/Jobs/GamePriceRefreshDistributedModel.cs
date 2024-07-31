using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Models;

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct GamePriceRefreshDistributedModel(bool IsFree, bool IsOnSale, Dictionary<string, ImmutableArray<GamePriceSubModel>> PackagesOfRegion);

[MemoryPackable(SerializeLayout.Sequential)]
public partial record struct GamePriceSubModel(string SubName, int SubId, decimal? Original, decimal? Final);