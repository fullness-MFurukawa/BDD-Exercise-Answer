using System.Runtime.Serialization;
namespace Exercise.Domains.Exceptions;
/// <summary>
/// データが既に存在することを表す例外クラス
/// 提供
/// </summary>
public class ExistsException : Exception
{
    public ExistsException()
    {
    }
    public ExistsException(string? message) : base(message)
    {
    }
    public ExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    protected ExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
