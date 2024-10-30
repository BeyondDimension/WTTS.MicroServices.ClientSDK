using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.WTTS.Enums;

public enum PointRewardOrderType : byte
{
    /// <summary>
    /// 一般订单
    /// </summary>
    [Description("一般订单")]
    GeneralOrder = 0,

    /// <summary>
    /// 补发点数订单
    /// </summary>
    [Description("补发点数订单")]
    ReissuedPoint = 1,
}
