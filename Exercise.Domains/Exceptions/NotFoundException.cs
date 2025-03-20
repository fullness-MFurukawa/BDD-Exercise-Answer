using System.Runtime.Serialization;
namespace Exercise.Domains.Exceptions;
/// <summary>
/// データが見つからないことを表す例外クラス
/// 提供
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }
    public NotFoundException(string? message) : base(message)
    {
    }
    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
