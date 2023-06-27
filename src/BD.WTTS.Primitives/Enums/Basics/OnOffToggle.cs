namespace BD.WTTS.Enums;

public enum OnOffToggle : byte
{
    Toggle,
    On,
    Off,
}

[Obsolete("use OnOffToggle", true)]
public enum EOnOff : byte
{
    Toggle,
    On,
    Off,
}