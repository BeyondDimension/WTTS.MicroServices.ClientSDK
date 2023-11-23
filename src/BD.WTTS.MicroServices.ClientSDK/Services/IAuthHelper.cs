namespace BD.WTTS.Services;

public interface IAuthHelper
{
    ValueTask<JWTEntity?> GetAuthTokenAsync();

    ValueTask<JWTEntity?> GetShopAuthTokenAsync();

    /// <summary>
    /// 登出
    /// </summary>
    Task SignOutAsync();
}