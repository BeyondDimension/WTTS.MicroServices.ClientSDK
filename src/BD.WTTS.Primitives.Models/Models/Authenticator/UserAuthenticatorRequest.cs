//// ReSharper disable once CheckNamespace
//namespace BD.WTTS.Models;

//[MPObj, MP2Obj(SerializeLayout.Explicit)]
//public sealed partial class UserAuthenticatorRequest
//{
//    [MPKey(0), MP2Key(0)]
//    public Guid? Id { get; set; }

//    [MPKey(1), MP2Key(1)]
//    [StringLength(Constants.Lengths.Max_AuthenticatorToken)]
//    public byte[]? Token { get; set; }

//    [MPKey(2), MP2Key(2)]
//    [StringLength(Constants.Lengths.Max_AuthenticatorName)]
//    public string Name { get; set; } = string.Empty;

//    [MPKey(3), MP2Key(3)]
//    public UserAuthenticatorTokenType TokenType { get; set; }

//    [MPKey(4), MP2Key(4)]
//    public GamePlatform GamePlatform { get; set; }

//    [MPKey(5), MP2Key(5)]
//    public DateTimeOffset LastSyncTime { get; set; }

//    [MPKey(6), MP2Key(6)]
//    public string? Remark { get; set; }

//    [MPKey(7), MP2Key(7)]
//    public int Order { get; set; }
//}
