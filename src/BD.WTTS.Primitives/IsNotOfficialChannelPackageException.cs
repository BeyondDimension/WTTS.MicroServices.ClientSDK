namespace BD.WTTS;

public sealed class IsNotOfficialChannelPackageException : ApplicationException
{
    public IsNotOfficialChannelPackageException()
    {
    }

    public IsNotOfficialChannelPackageException(string message) : base(message)
    {
    }

    public IsNotOfficialChannelPackageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public IsNotOfficialChannelPackageException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
