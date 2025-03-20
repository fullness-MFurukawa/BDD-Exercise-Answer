using Exercise.Domains.Exceptions;
using Reqnroll;
namespace Exercise.ApplicationsTests.Commons;
/// <summary>
/// NotFoundException、ExistsException評価用共通ステップクラス
/// 提供
/// </summary
[Binding]
public class ExceptionCommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="scenarioContext">シナリオコンテキスト</param>
    public ExceptionCommonSteps(ScenarioContext scenarioContext)
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
            _scenarioContext["CapturedException"] = e;
        }
    }

    [Then("NotFoundExceptionがスローされたことを評価する {string}")]
    public void ThenNotFoundExceptionがスローされたことを評価する(string expectedMessage)
    {
        var exception = _scenarioContext["CapturedException"] as Exception;
        Assert.IsNotNull(exception, "例外がキャプチャされていません。");
        Assert.IsInstanceOfType(exception, typeof(NotFoundException), "スローされた例外はNotFoundExceptionではありません。");
        Assert.AreEqual(expectedMessage, exception.Message, "例外メッセージが期待値と一致しません。");
    }

    [Then("ExistsExceptionがスローされたことを評価する {string}")]
    public void ThenExistsExceptionがスローされたことを評価する(string expectedMessage)
    {
        var exception = _scenarioContext["CapturedException"] as Exception;
        Assert.IsNotNull(exception, "例外がキャプチャされていません。");
        Assert.IsInstanceOfType(exception, typeof(ExistsException), "スローされた例外はExistsExceptionではありません。");
        Assert.AreEqual(expectedMessage, exception.Message, "例外メッセージが期待値と一致しません。");
    }

    [Then("ExistsExceptionがスローされないことを評価する")]
    public void ThenExistsExceptionがスローされないことを評価する()
    {
        Assert.IsFalse(_scenarioContext.ContainsKey("CapturedException"));
    }
}
