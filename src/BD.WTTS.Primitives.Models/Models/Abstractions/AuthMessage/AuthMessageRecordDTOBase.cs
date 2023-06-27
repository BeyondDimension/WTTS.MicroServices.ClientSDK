// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

/// <inheritdoc cref="IAuthMessageRecord"/>
public abstract class AuthMessageRecordDTOBase : IKeyModel<Guid>, IAuthMessageRecord
{
    public Guid Id { get; set; }

    public DateTimeOffset CreationTime { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    [Required] // EF not null
    public string IPAddress { get; set; } = string.Empty;

    #region 提供商内容

    [Required] // EF not null
    public string Channel { get; set; } = string.Empty;

    public string? SendResultRecord { get; set; }

    public int HttpStatusCode { get; set; }

    public bool SendIsSuccess { get; set; }

    #endregion

    [Required] // EF not null
    public string Content { get; set; } = string.Empty;

    public bool EverCheck { get; set; }

    public bool CheckSuccess { get; set; }

    public bool Abandoned { get; set; }

    public int CheckFailuresCount { get; set; }

    public string? UserNickName { get; set; }
}

/// <inheritdoc cref="IAuthMessageRecord"/>
public abstract class AuthMessageRecordDTOBase<TSendSmsRequestType, TEAuthMessageType> : AuthMessageRecordDTOBase, IAuthMessageRecord<TSendSmsRequestType, TEAuthMessageType>
    where TSendSmsRequestType : struct, Enum
    where TEAuthMessageType : struct, Enum
{
    public TEAuthMessageType Type { get; set; }

    public TSendSmsRequestType RequestType { get; set; }
}