// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static partial class Constants
{
    /// <summary>
    /// 长度/固定长度/最小长度/最大长度
    /// </summary>
    public static class Lengths
    {
        /* 字段命名规范
         * 固定长度直接使用相关名
         * 最小长度使用 Min_相关名字
         * 最大长度使用 Max_相关名字
         */

        /// <summary>
        /// 设备 Id，版本代号为 R
        /// </summary>
        public const int DeviceIdR = 7;

        /// <summary>
        /// 设备 Id 最大长度
        /// </summary>
        public const int Max_DeviceId = ShortGuid.StringLength + DeviceIdR + Hashs.String.Lengths.SHA256;

        /// <summary>
        /// 身份验证器令牌名称最大长度
        /// </summary>
        public const int Max_AuthenticatorName = 32;

        /// <summary>
        /// 身份验证令牌数据最大长度
        /// </summary>
        public const int Max_AuthenticatorToken = 1073741824; // 1MB

        /// <summary>
        /// 哈希密码最大长度
        /// </summary>
        public const int Max_PasswordHash = 256;

        /// <summary>
        /// 密码问题最大长度
        /// </summary>
        public const int Max_PwdQuestion = 1000;

        /// <summary>
        /// 密码问题答案最大长度
        /// </summary>
        public const int Max_PwdQuestionAnswer = 1000;

        /// <summary>
        /// IP 地址最大长度，通常 IPv6 的最大长度为 45，但可能有多个 IP 地址使用分号分割，例如 HTTP_X_FORWARDED_FOR
        /// </summary>
        public const int Max_IPAddress = 512;

        /// <summary>
        /// 文章分类名称最大长度
        /// </summary>
        public const int Max_ArticleCategoryName = 300;

        /// <summary>
        /// 标签名称最大长度
        /// </summary>
        public const int Max_TagName = 30;

        /// <summary>
        /// 文章标题最大长度
        /// </summary>
        public const int Max_ArticleTitle = 200;

        /// <summary>
        /// 优惠劵名称最大长度
        /// </summary>
        public const int Max_CouponName = 120;

        /// <summary>
        /// 客户端用户昵称最大长度
        /// </summary>
        public const int Max_CUserNickName = 36;

        /// <summary>
        /// 客户端用户个性签名最大长度
        /// </summary>
        public const int Max_CUserPersonalizedSignature = 100;

        /// <summary>
        /// 客户端用户真实姓名最大长度
        /// </summary>
        public const int Max_CUserActualName = 300;

        /// <summary>
        /// 客户端用户设备名称最大长度
        /// </summary>
        public const int Max_CUserDeviceName = 100;

        /// <summary>
        /// 版本号最大长度
        /// </summary>
        public const int Max_Version = 23;

        /// <summary>
        /// 版本信息最大长度
        /// </summary>
        public const int Max_InformationalVersion = 32;

        /// <summary>
        /// 加速名最大长度
        /// </summary>
        public const int Max_AccelerateName = 200;

        /// <summary>
        /// 脚本评价内容最大长度
        /// </summary>
        public const int Max_ScriptEvaluationContent = 8000;

        /// <summary>
        /// 游戏名称最大长度
        /// </summary>
        public const int Max_GameName = 300;

        /// <summary>
        /// 游戏开发者最大长度
        /// </summary>
        public const int Max_GameDeveloper = 300;

        /// <summary>
        /// 游戏发布者最大长度
        /// </summary>
        public const int Max_GamePublisher = 300;

        /// <summary>
        /// 游戏成就名最大长度
        /// </summary>
        public const int Max_GameAchievementName = 1000;

        /// <summary>
        /// 游戏成就名最大长度
        /// </summary>
        public const int Max_GameSystemInfo = 2000;

        /// <summary>
        /// 游戏平台名称最大长度
        /// </summary>
        public const int Max_GameDealerPlatformName = 300;

        /// <summary>
        /// 游戏在对应零售商平台的 Id 最大长度，例如 Steam 的 AppId
        /// </summary>
        public const int Max_DealerGameId = 256;

        /// <summary>
        /// 游戏Sub在对应零售商平台的 SubId 最大长度，例如 Steam 的 SubId
        /// </summary>
        public const int Max_DealerSubId = 256;

        /// <summary>
        /// 游戏在对应零售商平台用户 Id 最大长度，例如 Steam 64 位 UserId
        /// </summary>
        public const int Max_DealerUserId = 256;

        /// <summary>
        /// 游戏评价标题最大长度
        /// </summary>
        public const int Max_GameEvaluationTitle = 100;

        /// <summary>
        /// 游戏语言名称最大长度
        /// </summary>
        public const int Max_GameLanguageName = 300;

        /// <summary>
        /// 游戏评分机构名称最大长度
        /// </summary>
        public const int Max_GameRateMediaAgencyName = 300;

        /// <summary>
        /// 业务功能模块名称最大长度
        /// </summary>
        public const int Max_BusinessModuleName = 100;

        /// <summary>
        /// 价格区域名称最大长度
        /// </summary>
        public const int Max_GamePriceRegionName = 100;

        /// <summary>
        /// 第三方账号 Id 最大长度
        /// </summary>
        public const int Max_ExternalAccountId = 256;

        /// <summary>
        /// 变更原因最大长度
        /// </summary>
        public const int Max_ChangeReason = 600;

        /// <summary>
        /// 文件名称最大长度
        /// </summary>
        public const int Max_FileName = 255;

        /// <summary>
        /// 系统信息最大长度
        /// </summary>
        public const int Max_SystemInfo = 1000;

        /// <summary>
        /// 作者名最大长度，允许多个作者，使用某个分隔符分开
        /// </summary>
        public const int Max_AuthorName = 1000;

        /// <summary>
        /// 脚本信息名最大长度
        /// </summary>
        public const int Max_ScriptName = 200;

        /// <summary>
        /// 脚本评价屏蔽原因最大长度
        /// </summary>
        public const int Max_ScriptEvaluationShieldReason = 600;

        /// <summary>
        /// SteamBot账号用户名最大长度
        /// </summary>
        public const int Max_SteamBotUserName = 64;

        /// <summary>
        /// SteamBot账号密码最大长度
        /// </summary>
        public const int Max_SteamBotPassword = 64;

        /// <summary>
        /// 更新日志最大长度
        /// </summary>
        public const int Max_UpdateLogs = 8000;

        /// <summary>
        /// 插件包哈希最大长度
        /// </summary>
        public const int Max_PluginHash = 256;

        /// <summary>
        /// 插件名称最大长度
        /// </summary>
        public const int Max_PluginName = 100;

        /// <summary>
        /// 插件简介最大长度
        /// </summary>
        public const int Max_PluginBriefIntroduction = 200;

        /// <summary>
        /// 插件简介最大长度
        /// </summary>
        public const int Max_PluginDetailedIntroduction = 8000;

        /// <summary>
        /// 插件分类编码最大长度
        /// </summary>
        public const int Max_PluginCategoryCode = 100;

        /// <summary>
        /// 插件分类名称最大长度
        /// </summary>
        public const int Max_PluginCategoryName = 100;

        /// <summary>
        /// 用户友好订单号
        /// </summary>
        public const int Max_UserFriendlyOrderNumber = 100;

        /// <summary>
        /// 发布者名称
        /// </summary>
        public const int Max_PluginPublisherName = 100;

        /// <summary>
        /// 开发者ApiKey
        /// </summary>
        public const int Max_PluginDeveloperApiKey = 500;

        /// <summary>
        /// 插件唯一名称
        /// </summary>
        public const int Max_PluginIdentityName = 100;

        /// <summary>
        /// 发布者显示名称
        /// </summary>
        public const int Max_PluginPublisherShowName = 100;

        /// <summary>
        /// 插件评价留言
        /// </summary>
        public const int Max_PluginEvaluationComment = 500;

        /// <summary>
        /// 语言编码
        /// </summary>
        public const int Max_LanguageCode = 100;

        /// <summary>
        /// 商业模块_商品名称
        /// </summary>
        public const int Max_GoodsName = 200;

        /// <summary>
        /// 商业模块_商品描述
        /// </summary>
        public const int Max_GoodsDescription = 8000;

        /// <summary>
        /// 商业模块_好友邀请链接
        /// </summary>
        public const int Max_FriendInviteUrl = 3000;

        /// <summary>
        /// 商业模块_交易链接
        /// </summary>
        public const int Max_BalanceTradeUrl = 3000;

        /// <summary>
        /// 抽奖活动名称最大长度名称
        /// </summary>
        public const int Max_RaffleActivityName = 200;

        /// <summary>
        /// 抽奖活动奖品名称最大长度名称
        /// </summary>
        public const int Max_RaffleActivityPrizeName = 200;

        /// <summary>
        /// 抽奖活动条件名称最大长度名称
        /// </summary>
        public const int Max_RaffleActivityConditionName = 200;

        /// <summary>
        /// 退款原因
        /// </summary>
        public const int Max_RefundReason = 500;

        /// <summary>
        /// 卖家备注
        /// </summary>
        public const int Max_SellerRemark = 2000;
    }
}