using BDD_Fronts.Middlewares;
using Exercise.Domains.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Reqnroll;
namespace BDD_FrontsTests.Mocks;
/// <summary>
/// 演習-19 例外ハンドリングミドルウェアのシナリオとテストドライバを実装してテストする
/// </summary>
[Binding]
public class ExceptionHandlingMiddlewareStepDefinitions
{
    // HttpContextのインスタンス(HTTPリクエストに関連するすべての情報を格納する)
    private HttpContext? _context;
    // テスト対象のExceptionHandlingMiddlewareのインスタンス
    private ExceptionHandlingMiddleware? _middleware;
    // RequestDelegateのモック(HTTPリクエストを処理するミドルウェアをカプセル化するデリゲート)
    private Mock<RequestDelegate>? _mockRequestDelegate;
    // ILoggerのモック
    private Mock<ILogger<ExceptionHandlingMiddleware>>? _mockLogger;


    [Given("ミドルウェアのセットアップ")]
    public void Givenミドルウェアのセットアップ()
    {
        // RequestDelegateのモックを初期化する
        _mockRequestDelegate = new Mock<RequestDelegate>();
        // ILoggerのモックを初期化する
        _mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();

        // ミドルウェアのインスタンスを初期化する
        _middleware = new ExceptionHandlingMiddleware(_mockRequestDelegate.Object);
        // HttpContextのインスタンスを初期化する
        _context = new DefaultHttpContext();
        // レスポンスのBodyをMemoryStreamに設定する
        _context.Response.Body = new MemoryStream();
    }

    [When("ミドルウェアがInternalExceptionをスローする")]
    public void WhenミドルウェアがInternalExceptionをスローする()
    {
        // モックのRequestDelegateが呼ばれたときにInternalExceptionをスローするように設定する
        _mockRequestDelegate!.Setup(rd => rd(
            It.IsAny<HttpContext>()))
            .ThrowsAsync(new InternalException("Internal Error"));
    }

    [When("ミドルウェアを呼び出す")]
    public async Task Whenミドルウェアを呼び出す()
    {
        // ミドルウェアのInvokeAsyncメソッドを呼び出し、HttpContextを渡す
        await _middleware!.InvokeAsync(_context!);
    }

    [Then("レスポンスはエラーページにリダイレクトされる")]
    public void Thenレスポンスはエラーページにリダイレクトされる()
    {
        // レスポンスのステータスコードが302 Foundであることを検証する
        Assert.AreEqual(StatusCodes.Status302Found, _context!.Response.StatusCode);
        // レスポンスのLocationヘッダーがエラーページにリダイレクトされていることを検証する
        Assert.AreEqual("/exercise/error", _context.Response.Headers["Location"]);
    }

    [When("ミドルウェアが例外をスローしない")]
    public void Whenミドルウェアが例外をスローしない()
    {
        // モックのRequestDelegateが正常に完了するように設定する
        _mockRequestDelegate!.Setup(rd => rd(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);
    }

    [Then("次のデリゲートが呼び出される")]
    public void Then次のデリゲートが呼び出される()
    {
        // モックのRequestDelegateが一度だけ呼び出されることを検証する
        _mockRequestDelegate!.Verify(rd => rd(_context!), Times.Once);
    }
}
