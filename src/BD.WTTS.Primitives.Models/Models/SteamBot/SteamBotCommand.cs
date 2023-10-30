namespace BD.WTTS.Models.SteamBot;

public record SteamBotCommand
{
    public SteamBotCommand(Guid botId, SteamBotCommandType type, string? dataId)
    {
        Id = Guid.NewGuid();
        Created = DateTimeOffset.Now;
        BotId = botId;
        Type = type;
        DataId = dataId;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid BotId { get; set; }

    public SteamBotCommandType Type { get; }

    public string? DataId { get; set; }

    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public sealed record RemoveFriendCommand : SteamBotCommand
    {
        public RemoveFriendCommand(Guid botId, ulong? dataId) : base(botId, SteamBotCommandType.RemoveFriend, dataId.ToString())
        {
        }

        public RemoveFriendCommand(SteamBotCommand original) : base(original)
        {
        }

        public static RemoveFriendCommand From(SteamBotCommand cmd)
        {
            return new(cmd);
        }

        public ulong FriendSteamId => ulong.TryParse(DataId, out ulong parsedSteamId) ? parsedSteamId : 0;
    }

    public sealed record GenerateGiftCardPaymentQrCodeCommand : SteamBotCommand
    {
        public GenerateGiftCardPaymentQrCodeCommand(Guid botId, Guid dataId) : base(botId, SteamBotCommandType.GenerateGiftCardPaymentQrCode, dataId.ToString())
        {
        }

        public GenerateGiftCardPaymentQrCodeCommand(SteamBotCommand original) : base(original)
        {
        }

        public static GenerateGiftCardPaymentQrCodeCommand From(SteamBotCommand cmd)
        {
            return new(cmd);
        }

        public Guid RecordId => Guid.TryParse(DataId, out Guid parsedRecordId) ? parsedRecordId : Guid.Empty;
    }
}

public enum SteamBotCommandType : short
{
    // Steam 操作 0 位移
    AddFriend = 1_00,
    RemoveFriend = 1_01,

    // 余额交易相关命令 1 位移
    GenerateGiftCardPaymentQrCode = 2_00,
}