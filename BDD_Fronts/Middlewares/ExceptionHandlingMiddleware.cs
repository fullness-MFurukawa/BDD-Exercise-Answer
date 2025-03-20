using Exercise.Domains.Exceptions;

namespace BDD_Fronts.Middlewares;
/// <summary>
/// 共通例外ハンドリングミドルウェア
/// 提供
/// </summary>
public class ExceptionHandlingMiddleware
{
    // 次のミドルウェアへの参照を保持するフィールド
    private readonly RequestDelegate _next;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="next"></param>
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// ミドルウェアのメイン処理
    /// HTTPリクエストを処理し、例外をキャッチする
    /// </summary>
    /// <param name="context">現在のHTTPコンテキスト</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // 次のミドルウェアにリクエストを渡し、その実行を待機する
            await _next(context);
        }
        catch (InternalException ex)
        {
            // 内部例外がInternalExceptionの場合にキャッチする
            await HandleException(context, ex);
        }
    }
    /// <summary>
    /// 例外を処理するためのメソッド
    /// InternalExceptionが発生した場合に、エラーページにリダイレクトする
    /// </summary>
    /// <param name="context">現在のHTTPコンテキスト</param>
    /// <param name="exception">発生した例外</param>
    private Task HandleException(HttpContext context, InternalException exception)
    {
        // リダイレクトのステータスコード
        context.Response.StatusCode = StatusCodes.Status302Found;
        context.Response.Redirect("/exercise/error");
        return Task.CompletedTask;
    }
}
