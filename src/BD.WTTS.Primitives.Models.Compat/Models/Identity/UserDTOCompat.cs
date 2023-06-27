// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed partial class UserDTOCompat : IUserDTO
{
    string DebuggerDisplay => IUserDTO.GetDebuggerDisplay(this);

    [MPKey(0), MP2Key(0)]
    [N_JsonProperty("0")]
    [S_JsonProperty("0")]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    [N_JsonProperty("1")]
    [S_JsonProperty("1")]
    public string NickName { get; set; } = string.Empty;

    [MPKey(2), MP2Key(2)]
    [N_JsonProperty("2")]
    [S_JsonProperty("2")]
    public Guid? Avatar { get; set; }

    Guid IUserDTO.Avatar { get => Avatar ?? default; set => Avatar = value; }
}