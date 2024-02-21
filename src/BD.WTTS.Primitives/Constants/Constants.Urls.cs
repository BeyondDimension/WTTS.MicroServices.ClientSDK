// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class Constants
{
    public static class Urls
    {
        #region 

        public const string OfficialApiHostName = "api.steampp.net";
        public const string OfficialShopApiHostName = "shop.api.steampp.net";

        /// <summary>
        /// 官网网址
        /// </summary>
        public const string OfficialWebsite =
#if DEBUG || USE_DEV_API
            //"https://steampp.mossimo.net:8500";
            "https://ms-test.steampp.net";

#else
        "https://steampp.net";

#endif

        public const string OfficialWebsite_Logo = $"{OfficialWebsite}/logo.svg";
        public const string OfficialWebsite_Privacy = $"{OfficialWebsite}/privacy";
        public const string OfficialWebsite_Agreement = $"{OfficialWebsite}/agreement";
        public const string OfficialWebsite_Contact = $"{OfficialWebsite}/contact";
        public const string OfficialWebsite_Faq = $"{OfficialWebsite}/faq";
        public const string OfficialWebsite_JoinUs = $"{OfficialWebsite}/joinus";
        public const string OfficialWebsite_Changelog = $"{OfficialWebsite}/changelog";
        public const string OfficialWebsite_Box_Changelog_ = $"{OfficialWebsite}/changelogbox?theme={{0}}&language={{1}}";
        public const string OfficialWebsite_Box_Faq_ = $"{OfficialWebsite}/faqbox?theme={{0}}&language={{1}}";
        public const string OfficialWebsite_Box_Privacy = $"{OfficialWebsite}/PrivacyBox";
        public const string OfficialWebsite_Box_Agreement = $"{OfficialWebsite}/AgreementBox";
        public const string OfficialWebsite_LiunxSetupCer = $"{OfficialWebsite}/liunxSetupCer";
        public const string OfficialWebsite_UnixHostAccess_ = $"{OfficialWebsite}/unixhostaccess?prot={{0}}";
        public const string OfficialWebsite_UnixHostAccess = $"{OfficialWebsite}/unixhostaccess";
        public const string OfficialWebsite_AppUpdateFailCode_ = $"{OfficialWebsite}?appUpdFailCode={{0}}";
        public const string OfficialWebsite_Notice = $"{OfficialWebsite}/notice?id={{0}}";
        public const string OfficialWebsite_UploadsPublishFiles = $"{OfficialWebsite}/uploads/publish/files/{{0}}{FileEx.BIN}";
        public const string OfficialWebsite_UploadsPublish = $"{OfficialWebsite}/uploads/publish/{{0}}";
        public const string OfficialWebsite_Account_Center = $"{OfficialWebsite}/account/center/info";
        public const string OfficialWebsite_Account_Bind = $"{OfficialWebsite}/account/center/bind";
        public const string OfficialWebsite_Account_Safe = $"{OfficialWebsite}/account/center/safe";
        public const string OfficialWebsite_Sponsor = $"{OfficialWebsite}/sponsor";
        public const string OfficialWebsite_Article = $"{OfficialWebsite}/article";
        public const string OfficialWebsite_Article_Detail_ = $"{OfficialWebsite}/article/detail?id={{0}}";
        public const string OfficialWebsite_Fast_Login_ = $"{OfficialWebsite}/account/login?tk={{0}}&t={{1}}&redirectUrl={{2}}";

        #endregion

        #region WattGame Shop

        /// <summary>
        /// 商城网址
        /// </summary>
        public const string WattGame =
#if DEBUG || USE_DEV_API
            "https://steampp.mossimo.net:7500";
        //"https://ms-test.steampp.net";

#else
        "https://shop.steampp.net";

#endif

        public const string WattGame_Goods_Detail_ = $"{WattGame}/goods/detail/{{0}}";
        public const string WattGame_Fast_Login_ = $"{WattGame}/oauth/verifier?tk={{0}}&t={{1}}&to={{2}}";

        #endregion

        #region API

        /// <summary>
        /// SppWebApi 正式环境基地址
        /// </summary>
        public const string BaseUrl_API_Production =
            $"{String2.Prefix_HTTPS}{OfficialApiHostName}";

        /// <summary>
        /// SppWebApi 测试环境基地址
        /// </summary>
        public const string BaseUrl_API_Development =
            //"https://steampp.mossimo.net:8800";
            "https://ms-test.steampp.net";

        /// <summary>
        /// SppWebApi 本地调试基地址
        /// </summary>
        public const string BaseUrl_API_Debug =
            "https://localhost:5001";

        static bool IsApiBaseUrl(string value) => value switch
        {
            BaseUrl_API_Production or
            BaseUrl_API_Development or
            BaseUrl_API_Debug => true,
            _ => false,
        };

        static string BaseUrl_API = BaseUrl_API_Development;

        public static string ApiBaseUrl
        {
            get => BaseUrl_API;
            set
            {
                if (IsApiBaseUrl(value))
                    BaseUrl_API = value;
            }
        }

        public static string GetAdvertisementJumpUrl(Guid id)
            => $"{BaseUrl_API}/komaasharu/{id}";

        public static string GetAdvertisementImageUrl(Guid id)
            => $"{BaseUrl_API}/komaasharu/images/{id}";

        #endregion

        #region Custom Url Scheme

        public const string Segment_LoginOrRegister = "auth";
        public const string Segment_LoginOrRegister_Fast = "fast";
        public const string Segment_LoginOrRegister_PhoneNum = "phonenum";

        public const string ThirdPartyLoginCallback_ = $"{CUSTOM_URL_SCHEME}{Segment_LoginOrRegister}/{Segment_LoginOrRegister_Fast}/{{0}}";

        #endregion

        #region GitHub

        public const string GitHub_User_Rmbadmin = "https://github.com/rmbadmin";
        public const string GitHub_User_AigioL = "https://github.com/AigioL";
        public const string GitHub_User_Mossimos = "https://github.com/Mossimos";

        #endregion

        #region Email

        public const string Rmbadmin_Email = "mailto:rmb@rmbgame.net";

        #endregion

        #region Git Repository

        public const string GitHub_Repository = "https://github.com/BeyondDimension/SteamTools";
        public const string Gitee_Repository = "https://gitee.com/rmbgame/SteamTools";

        #endregion

        #region Issues

        public const string GitHub_Issues = "https://github.com/BeyondDimension/SteamTools/issues";
        public const string Gitee_Issues = "https://gitee.com/rmbgame/SteamTools/issues";

        #endregion

        public const string License_GPLv3 = "https://www.gnu.org/licenses/gpl-3.0.html";

        public const string MicrosoftStoreAppWebsite = "https://www.microsoft.com/store/apps/" + MicrosoftStoreId;
        public const string MicrosoftStoreProtocolLink = "ms-windows-store://pdp/?productid=" + MicrosoftStoreId;
        public const string MicrosoftStoreReviewLink = "ms-windows-store://review/?ProductId=" + MicrosoftStoreId;

        public const string SponsorUrl_afdian = "https://afdian.net/@rmbgame";
        public const string SponsorUrl_ko_fi = "https://ko-fi.com/rmbgame";
        public const string SponsorUrl_patreon = "https://www.patreon.com/rmbgame";

        public const string CrowdinUrl = "https://crowdin.com/project/steampp";
    }
}