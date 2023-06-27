using SmsCodeTypeEnum = BD.WTTS.Enums.SmsCodeType;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Columns;

/// <summary>
/// 列 - 短信验证码类型
/// </summary>
public interface ISmsCodeType
{
    /// <inheritdoc cref="SmsCodeTypeEnum"/>
    SmsCodeTypeEnum SmsCodeType { get; set; }
}