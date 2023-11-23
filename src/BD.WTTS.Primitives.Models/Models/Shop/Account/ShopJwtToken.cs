namespace BD.WTTS.Models;

/// <summary>
/// 商城登录 Token
/// </summary>
[MPObj]
public class ShopJwtToken
{
    [MPKey(0)]
    [MP2Key(0)]
    [N_JsonProperty("expires_in")]
    [S_JsonProperty("expires_in")]
    public double ExpiresIn { get; set; }

    [MPKey(1)]
    [MP2Key(1)]
    [N_JsonProperty("token")]
    [S_JsonProperty("token")]
    public string AccessToken { get; set; } = string.Empty;
}
