// C# 10 定义全局 using

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0005
#pragma warning disable SA1209 // Using alias directives should be placed after other using directives
#pragma warning disable SA1211 // Using alias directives should be ordered alphabetically by alias name

global using Avalonia.Metadata;

#if MVVM_VM
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Models")]
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Models.Abstractions")]
#elif LIB_WTTS_PRIMITIVES
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS")]
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Columns")]
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Enums")]
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Helpers")]
#elif LIB_WTTS_MS_PRIMITIVES
[assembly: XmlnsDefinition("https://steampp.net/ui", "BD.WTTS.Enums")]
#endif