// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 计算机规格
/// </summary>
public enum ComputerSpecification : byte
{
    // https://learn.microsoft.com/en-us/previous-versions/system-center/configuration-manager-2003/cc180825(v=technet.10)?redirectedfrom=MSDN

    /// <summary>
    /// 台式机
    /// </summary>
    Desktop = 1,

    /// <summary>
    /// 笔记本
    /// </summary>
    Laptop,
}
