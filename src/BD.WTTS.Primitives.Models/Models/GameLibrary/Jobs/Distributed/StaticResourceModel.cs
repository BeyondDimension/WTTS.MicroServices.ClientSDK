namespace BD.WTTS.Models;

[MPObj(true), MP2Obj(GenerateType.VersionTolerant, SerializeLayout.Sequential)]
public partial record struct StaticResourceModel(
    GameResourceType Type,
    string Url
    );
