using Exercise.Domains.Exceptions;
using Reqnroll;
namespace Exercise.InfrastructuresTests.Commons;
/// <summary>
/// InternalException評価用共通ステップ
/// 提供
/// </summary>
[Binding]
public class InternalExceptionCommonSteps
{
    // シナリオコンテキスト
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="scenarioContext">シナリオコンテキスト</param>
    public InternalExceptionCommonSteps(ScenarioContext scenarioContext)
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

    [Then("InternalExceptionがスローされたことを評価する")]
    public void ThenInternalExceptionがスローされたことを評価する()
    {
        var exception = _scenarioContext["CapturedException"] as Exception;
        Console.WriteLine(exception!.Message);
        Assert.IsNotNull(exception, "例外がスローされません。");
        Assert.IsInstanceOfType(exception, typeof(InternalException),
            "スローされた例外はInternalExceptionではありません。");
    }
}
