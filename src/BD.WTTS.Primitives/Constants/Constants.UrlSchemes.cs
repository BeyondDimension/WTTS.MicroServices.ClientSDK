// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class Constants
{
    public static class UrlSchemes
    {
        /// <summary>
        /// 用于网页登录 Token 传递 参数是 Base64 编码的 AES 加密后的 Byte[]
        /// 解密后是 LoginOrRegisterResponse
        /// </summary>
        public const string Login = "spp://login/";

        /// <summary>
        /// 快速切换 steam 账号  参数为 steam 用户名
        /// </summary>
        public const string SwitchAccount = "spp://steam/switchaccount/";

        /// <summary>
        /// 挂卡运行指定steam appid游戏 
        /// </summary>
        public const string FakeApp = "spp://steam/fakeapp/";

        /// <summary>
        /// 管理指定steam appid游戏成就
        /// </summary>
        public const string SteamAchievement = "spp://steam/achievement/";

        /// <summary>
        /// 管理指定steam appid游戏云存档
        /// </summary>
        public const string SteamCloudManager = "spp://steam/cloudmanager/";
    }
}
