using System.Runtime.Serialization;
namespace Exercise.Domains.Exceptions;
/// <summary>
/// 内部エラーを表す例外クラス
/// 提供
/// </summary>
public class InternalException : Exception
{
    public InternalException()
    {
    }
    public InternalException(string? message) : base(message)
    {
    }
    public InternalException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    protected InternalException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
