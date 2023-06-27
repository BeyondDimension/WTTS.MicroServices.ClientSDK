// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

[GenerateTypeScript]
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class SendSmsRequest : IReadOnlyPhoneNumber
{
    [MPKey(0), MP2Key(0)]
    public string? PhoneNumber { get; set; }

    [MPKey(1), MP2Key(1)]
    public SmsCodeType Type { get; set; }
}