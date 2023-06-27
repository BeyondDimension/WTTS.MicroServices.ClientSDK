namespace BD.WTTS.Services.Implementation;

sealed class ApiRspCodeException : Exception
{
    public ApiRspCodeException(ApiRspCode code) : base(ApiRspExtensions.GetMessage(code))
        => Code = code;

    public ApiRspCodeException(ApiRspCode code, string message) : base(message)
        => Code = code;

    public ApiRspCode Code { get; }
}
