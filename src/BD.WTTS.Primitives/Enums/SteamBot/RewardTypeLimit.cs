using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Enums;

[Flags]
public enum RewardTypeLimit
{
    /// <summary>
    /// 评测
    /// </summary>
    RecommendID = 1 << 1,

    /// <summary>
    /// 截图/艺术作品/视频
    /// </summary>
    FileDetailsID = 1 << 2,

    /// <summary>
    /// SteamID
    /// </summary>
    SteamID = 1 << 3,

    /// <summary>
    /// 主题ID
    /// </summary>
    ForumTopicID = 1 << 4,

    All = RecommendID | FileDetailsID | SteamID | ForumTopicID
}
