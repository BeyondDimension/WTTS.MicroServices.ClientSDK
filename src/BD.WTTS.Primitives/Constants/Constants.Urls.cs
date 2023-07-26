// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class Constants
{
    public static class Urls
    {
        #region OfficialWebsite

        public const string OfficialWebsite = "https://steampp.net";
        public const string OfficialWebsite_Logo = "https://steampp.net/logo.svg";
        public const string OfficialWebsite_Privacy = "https://steampp.net/privacy";
        public const string OfficialWebsite_Agreement = "https://steampp.net/agreement";
        public const string OfficialWebsite_Contact = "https://steampp.net/contact";
        public const string OfficialWebsite_Faq = "https://steampp.net/faq";
        public const string OfficialWebsite_Changelog = "https://steampp.net/changelog";
        public const string OfficialWebsite_Box_Changelog_ = "https://steampp.net/changelogbox?theme={0}&language={1}";
        public const string OfficialWebsite_Box_Faq_ = "https://steampp.net/faqbox?theme={0}&language={1}";
        public const string OfficialWebsite_Box_Privacy = "https://steampp.net/PrivacyBox";
        public const string OfficialWebsite_Box_Agreement = "https://steampp.net/AgreementBox";
        public const string OfficialWebsite_LiunxSetupCer = "https://steampp.net/liunxSetupCer";
        public const string OfficialWebsite_UnixHostAccess_ = "https://steampp.net/unixhostaccess?prot={0}";
        public const string OfficialWebsite_UnixHostAccess = "https://steampp.net/unixhostaccess";
        public const string OfficialWebsite_AppUpdateFailCode_ = "https://steampp.net?appUpdFailCode={0}";
        public const string OfficialWebsite_Notice = "https://steampp.net/notice?id={0}";
        public const string OfficialWebsite_UploadsPublishFiles = $"https://steampp.net/uploads/publish/files/{{0}}{FileEx.BIN}";
        public const string OfficialWebsite_UploadsPublish = "https://steampp.net/uploads/publish/{0}";

        #endregion

        #region API

        public const string BaseUrl_API_Production = "https://api.steampp.net";
        public const string BaseUrl_API_Development = "https://steampp.mossimo.net:8800";
        public const string BaseUrl_API_Debug = "https://localhost:5001";

        static string BaseUrl_API = BaseUrl_API_Development;

        public static string ApiBaseUrl
        {
            get => BaseUrl_API;
            set => BaseUrl_API = value;
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
    }
}