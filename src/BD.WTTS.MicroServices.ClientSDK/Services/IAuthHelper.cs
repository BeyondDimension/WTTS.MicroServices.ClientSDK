namespace BD.WTTS.Services;

public interface IAuthHelper
{
    ValueTask<JWTEntity?> GetAuthTokenAsync();

    /// <summary>
    /// 登出
    /// </summary>
    Task SignOutAsync();
}