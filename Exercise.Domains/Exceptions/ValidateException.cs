using System.Runtime.Serialization;

namespace Exercise.Domains.Exceptions;
/// <summary>
/// 業務ルール違反を表す例外クラス
/// 提供
/// </summary>
public class ValidateException : Exception
{
    public ValidateException()
    {
    }
    public ValidateException(string? message) : base(message)
    {
    }
    public ValidateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
