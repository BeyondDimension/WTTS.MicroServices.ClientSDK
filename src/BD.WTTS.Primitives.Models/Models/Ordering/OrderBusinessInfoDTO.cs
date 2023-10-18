// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

public abstract class BizOrderInfoDTO : IKeyModel<Guid>, ICreationTime, IUpdateTime
{
    /// <summary>
    /// 主键
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 用户 Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 通用订单 Id
    /// </summary>
    public Guid? GenericOrderId { get; set; }

    /// <summary>
    /// 支付状态
    /// </summary>
    public OrderStatus PaymentStatus { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTimeOffset UpdateTime { get; set; }
}

/// <summary>
/// GiftsCardRechargeBusinessOrder - 后台管理表格查询模型
/// </summary>
public sealed partial class GiftsCardRechargeBizOrderInfoDTO : BizOrderInfoDTO
{
    /// <summary>
    /// 商品类型 Id
    /// </summary>
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 商品类型名
    /// </summary>
    public string? GoodsRechargeCategoryName { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    public decimal AmountReceived { get; set; }

    /// <summary>
    /// 充值状态
    /// </summary>
    public GoodsRechargeStatus GoodsRechargeStatus { get; set; }

    /// <summary>
    /// 用户 Steam Id
    /// </summary>
    public long UserSteamId { get; set; }

    /// <summary>
    /// SteamBotId
    /// </summary>
    public Guid? SteamBotId { get; set; }

    /// <summary>
    /// 用户添加 Steam Bot 好友时间
    /// </summary>
    public DateTimeOffset? UsersAddSteamBotFriendTime { get; set; }

    /// <summary>
    /// 成交时汇率
    /// </summary>
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    /// <summary>
    /// 充值金额
    /// </summary>
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 充值地区
    /// </summary>
    public string RechargeArea { get; set; } = "";

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTimeOffset? PaymentTime { get; set; }

    /// <summary>
    /// 充值完成时间
    /// </summary>
    public DateTimeOffset? RechargeCompletionTime { get; set; }

    /// <summary>
    /// 交易记录 Id
    /// </summary>
    public Guid? TransactionId { get; set; }

    /// <summary>
    /// 好友邀请链接
    /// </summary>
    public string FriendInvitationLink { get; set; } = "";

    /// <summary>
    /// 手续费
    /// </summary>
    public decimal Premium { get; set; }
}

/// <summary>
/// BalanceTradeRechargeBusinessOrder - 后台管理表格查询模型
/// </summary>
public sealed partial class BalanceTradeRechargeBizOrderInfoDTO : BizOrderInfoDTO
{
    /// <summary>
    /// 商品类型 Id
    /// </summary>
    public Guid GoodsRechargeCategoryId { get; set; }

    /// <summary>
    /// 商品类型名
    /// </summary>
    public string? GoodsRechargeCategoryName { get; set; }

    /// <summary>
    /// 应收金额
    /// </summary>
    public decimal AmountReceivable { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    public decimal AmountReceived { get; set; }

    /// <summary>
    /// 充值状态
    /// </summary>
    public GoodsRechargeStatus GoodsRechargeStatus { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTimeOffset? PaymentTime { get; set; }

    /// <summary>
    /// 充值完成时间
    /// </summary>
    public DateTimeOffset? RechargeCompletionTime { get; set; }

    /// <summary>
    /// 用户 Steam Id
    /// </summary>
    public long UserSteamId { get; set; }

    /// <summary>
    /// SteamBotId
    /// </summary>
    public Guid? SteamBotId { get; set; }

    /// <summary>
    /// 用户 Steam 交易链接
    /// </summary>
    public string UserSteamTransactionLink { get; set; } = "";

    /// <summary>
    /// 成交时汇率
    /// </summary>
    public decimal TheExchangeRateAtTheTimeOfTransaction { get; set; }

    /// <summary>
    /// 充值金额
    /// </summary>
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 充值地区
    /// </summary>
    public string RechargeArea { get; set; } = "";

    /// <summary>
    /// 市场交易 Id
    /// </summary>
    public Guid? MarketTransactionId { get; set; }

    /// <summary>
    /// 手续费
    /// </summary>
    public decimal Premium { get; set; }
}