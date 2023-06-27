// ReSharper disable once CheckNamespace
namespace BD.WTTS.Columns;

/// <summary>
/// 验证码纪录（短信或邮箱）
/// </summary>
public interface IAuthMessageRecord : ICreationTime
{
    Guid Id { get; set; }

    /// <summary>
    /// 手机号(如果为短信验证码此字段必填)
    /// </summary>
    string? PhoneNumber { get; set; }

    /// <summary>
    /// 邮箱地址(如果为邮箱验证码此字段必填)
    /// </summary>
    string? Email { get; set; }

    /// <summary>
    /// 调用方 IP 地址
    /// </summary>
    string IPAddress { get; set; }

    #region 提供商内容

    /// <summary>
    /// 第三方下发渠道的显示名称
    /// 比如网易/阿里云
    /// </summary>
    string Channel { get; set; }

    /// <summary>
    /// 第三方提供商返回的内容
    /// </summary>
    string? SendResultRecord { get; set; }

    /// <summary>
    /// 第三方提供商返回的 HTTP 状态码
    /// </summary>
    int HttpStatusCode { get; set; }

    /// <summary>
    /// 第三方提供商发送是否成功
    /// 通常从调用第三方接口返回的 JSON 中获取状态码判定是否成功
    /// </summary>
    bool SendIsSuccess { get; set; }

    #endregion

    /// <summary>
    /// 内容（短信验证码或邮箱验证码的内容）
    /// 短信内容通常仅含有验证码数字，不包括其他的提示语文字
    /// </summary>
    string Content { get; set; }

    /// <summary>
    /// 是否校验过
    /// </summary>
    bool EverCheck { get; set; }

    /// <summary>
    /// 是否校验成功
    /// </summary>
    bool CheckSuccess { get; set; }

    /// <summary>
    /// 是否被废弃
    /// </summary>
    bool Abandoned { get; set; }

    /// <summary>
    /// 校验失败次数
    /// </summary>
    int CheckFailuresCount { get; set; }
}

/// <inheritdoc cref="IAuthMessageRecord"/>
public interface IAuthMessageRecord<TSendSmsRequestType, TEAuthMessageType> : IAuthMessageRecord
    where TSendSmsRequestType : struct, Enum
    where TEAuthMessageType : struct, Enum
{
    /// <summary>
    /// 类型 是属于邮箱验证还是短信验证
    /// </summary>
    TEAuthMessageType Type { get; set; }

    /// <summary>
    /// 发送验证码用途
    /// </summary>
    TSendSmsRequestType RequestType { get; set; }
}