// C# 10 定义全局 using

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0005
#pragma warning disable SA1209 // Using alias directives should be placed after other using directives
#pragma warning disable SA1211 // Using alias directives should be ordered alphabetically by alias name

global using BD.Common.Enums;
global using BD.Common.Columns;
global using BD.Common.Models;
global using BD.Common.Models.Abstractions;

global using BD.WTTS.Enums;
global using BD.WTTS.Columns;
//global using BD.WTTS.Formatters;

#if !BACKMANAGE && !_RES_ && !_UNIT_TEST_ && !ENUM_LIB
// 兼容之前的数据，排序使用 Int32，且不生成序列，后台使用新版本(IOrderInt64)
#if DATA_MIGRATIONS
global using IOrder = BD.Common.Columns.IOrderInt32;
#else
global using IOrder = BD.Common.Columns.IOrder;
#endif
#endif
global using IOrderInt64 = BD.Common.Columns.IOrder;