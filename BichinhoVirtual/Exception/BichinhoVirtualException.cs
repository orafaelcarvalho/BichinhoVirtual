using System.Runtime.Serialization;

[Serializable]
internal class BichinhoVirtualException : Exception
{
    public BichinhoVirtualException()
    {
    }

    public BichinhoVirtualException(string? message) : base(message)
    {
    }

    public BichinhoVirtualException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BichinhoVirtualException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}