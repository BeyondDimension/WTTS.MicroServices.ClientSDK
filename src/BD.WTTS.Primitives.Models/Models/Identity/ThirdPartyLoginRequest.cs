// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class ThirdPartyLoginRequest : IExplicitHasValue
{
    [MPKey(0), MP2Key(0)]
    public ushort Port { get; set; }

    [MPKey(1), MP2Key(1)]
    public byte[]? SKey { get; set; }

    [MPKey(2), MP2Key(2)]
    public string? SKeyPadding { get; set; }

    [MPKey(3), MP2Key(3)]
    public string? Version { get; set; }

    [MPKey(4), MP2Key(4)]
    public bool IsBind { get; set; }

    [MPKey(5), MP2Key(5)]
    public DateTimeOffset AccessTokenExpires { get; set; }

    [MPKey(6), MP2Key(6)]
    public string? AccessToken { get; set; }

    public bool ExplicitHasValue()
    {
        if (!SKey.Any_Nullable() ||
            string.IsNullOrWhiteSpace(AccessToken) ||
            AccessTokenExpires == default ||
            string.IsNullOrWhiteSpace(SKeyPadding) ||
            string.IsNullOrWhiteSpace(Version))
            return false;
        return true;
    }
}