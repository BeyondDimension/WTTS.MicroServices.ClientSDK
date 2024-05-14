using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Enums;

/// <summary>
/// 通用任务类型
/// </summary>
public enum SteamBotCommonTaskType : byte
{
    None = 0,

    [Description("添加愿望单")]
    AddWishList = 1,
}
