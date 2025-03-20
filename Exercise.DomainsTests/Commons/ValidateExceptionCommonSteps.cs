using Exercise.Domains.Exceptions;
using Reqnroll;
namespace Exercise.DomainsTests.Commons;
/// <summary>
/// ValidateException例外評価用共通ステップクラス
/// 提供
/// </summary>
[Binding]
public class ValidateExceptionCommonSteps
{
    // シナリオコンテキスト
    private readonly ScenarioContext _scenarioContext;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="scenarioContext">シナリオコンテキスト</param>
    public ValidateExceptionCommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    /// <summary>
    /// 例外をキャッチする共通アクション
    /// </summary>
    /// <param name="action">System.Actionデリゲート</param>
    public void CaptureException(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            // シナリオコンテキストに例外を格納する
            _scenarioContext["CapturedException"] = e;
        }
    }

    [Then("ValidateExceptionがスローされる {string}")]
    public void ThenValidateExceptionがスローされる(string expectedMessage)
    {
        // シナリオコンテキストから例外を取り出す
        var exception = _scenarioContext["CapturedException"] as Exception;
        // 例外がスローされていることを評価する
        Assert.IsNotNull(exception);
        // 例外がValidateExceptionであることを評価する
        Assert.IsInstanceOfType(exception, typeof(ValidateException));
        // エラーメッセージが予測するメッセージと等価であることを評価する
        Assert.AreEqual(expectedMessage, exception.Message);
    }
}
