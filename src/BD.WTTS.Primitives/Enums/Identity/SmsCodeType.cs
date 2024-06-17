// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// 短信验证码类型
/// </summary>
public enum SmsCodeType
{
    /// <summary>
    /// [通过手机号码注册账号]用于注册
    /// </summary>
    Register = 200,

    ///// <summary>
    ///// [通过手机号码重设密码]找回密码
    ///// </summary>
    //ForgotPassword = 201,

    /// <summary>
    /// [换新手机号要旧手机号短信验证]绑定新手机号
    /// </summary>
    ChangePhoneNumberNew = 202,

    /// <summary>
    /// [新手机号的短信验证]换绑手机（安全验证）
    /// </summary>
    ChangePhoneNumberValidation = 203,

    /// <summary>
    /// [通过手机号码]登录或注册
    /// </summary>
    LoginOrRegister = 204,

    /// <summary>
    /// [通过手机号码]登录
    /// </summary>
    Login = 205,

    /// <summary>
    /// 绑定手机号码
    /// </summary>
    BindPhoneNumber = 206,

    /// <summary>
    /// [绑定邮箱要手机号短信验证]绑定邮箱
    /// </summary>
    BindEmail = 207,

    /// <summary>
    /// [换绑邮箱要手机号短信验证]换绑邮箱
    /// </summary>
    ChangeEmail = 208,

    /// <summary>
    /// 设置密码
    /// </summary>
    SetPassword = 209,

    /// <summary>
    /// 重置密码
    /// </summary>
    ResetPassword = 210,
}