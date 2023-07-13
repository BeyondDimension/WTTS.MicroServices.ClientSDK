namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GameConfigurationRequireResponse
{
    [MPKey(0), MP2Key(0)]
    public GameConfigurationLevel GameConfigurationLevel { get; set; }

    [MPKey(1), MP2Key(1)]
    public GameOSPlatform GameOSPlatform { get; set; }

    [MPKey(2), MP2Key(2)]
    public string OS { get; set; } = string.Empty;

    [MPKey(3), MP2Key(3)]
    public string? CPU { get; set; }

    [MPKey(4), MP2Key(4)]
    public long Memory { get; set; }

    [MPKey(5), MP2Key(5)]
    public string? GraphicsCard { get; set; }

    [MPKey(6), MP2Key(6)]
    public string? DirectXVersion { get; set; }

    [MPKey(7), MP2Key(7)]
    public long DiskSpace { get; set; }

    [MPKey(8), MP2Key(8)]
    public string? SoundCard { get; set; }

    [MPKey(9), MP2Key(9)]
    public string? Notes { get; set; }

    [MPKey(10), MP2Key(10)]
    public string? Network { get; set; }
}
