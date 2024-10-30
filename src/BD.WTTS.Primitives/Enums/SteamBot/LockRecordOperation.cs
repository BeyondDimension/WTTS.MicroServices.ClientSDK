using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Enums;

/// <summary>
/// SteamBot 红锁记录操作
/// </summary>
public enum LockRecordOperation : byte
{
    /// <summary>
    /// 未处理
    /// </summary>
    Unhandled = 0,

    /// <summary>
    /// 废弃的
    /// </summary>
    Abandoned = 1,

    /// <summary>
    /// 补充点数
    /// </summary>
    ReissuedPoint = 2,

    /// <summary>
    /// 退款
    /// </summary>
    Refund = 3,
}
