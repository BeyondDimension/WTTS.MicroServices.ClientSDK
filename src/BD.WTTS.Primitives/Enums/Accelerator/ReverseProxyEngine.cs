// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 反向代理引擎
/// </summary>
[Flags]
[Obsolete("之后仅支持 Yarp")]
public enum ReverseProxyEngine : byte
{
    [Obsolete("之后仅支持 Yarp")]
    Titanium = 2,

    Yarp = 4,
}

