using SmsCodeTypeEnum = BD.WTTS.Enums.SmsCodeType;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Columns;

/// <summary>
/// 列(只读) - 短信验证码类型
/// </summary>
public interface IReadOnlySmsCodeType
{
    /// <inheritdoc cref="SmsCodeTypeEnum"/>
    SmsCodeTypeEnum SmsCodeType { get; }
}