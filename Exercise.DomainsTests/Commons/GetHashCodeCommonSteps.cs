using Reqnroll;
namespace Exercise.DomainsTests.Commons;
/// <summary>
/// GetHashCode()メソッドの評価用共通ステップクラス
/// </summary>
[Binding]
public class GetHashCodeCommonSteps
{
    // シナリオコンテキスト
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="scenarioContext">シナリオコンテキスト</param>
    public GetHashCodeCommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    /// <summary>
    /// 評価するインスタンスの設定
    /// </summary>
    /// <param name="objectA"></param>
    /// <param name="objectB"></param>
    public void SetupObjects(object objectA, object objectB)
    {
        // テストターゲットをシナリオコンテキストに格納する
        _scenarioContext["ObjectA"] = objectA;
        _scenarioContext["ObjectB"] = objectB;
    }

    [When("GetHashCodeメソッドを実行する")]
    public void WhenGetHashCodeメソッドを実行する()
    {
        // シナリオコンテキストからターゲットを取り出す
        var objA = _scenarioContext["ObjectA"];
        var objB = _scenarioContext["ObjectB"];
        // GetHashCode()メソッドを実行する
        var hashCodeResultA = objA.GetHashCode();
        var hashCodeResultB = objB.GetHashCode();
        // 結果の等価比較結果を取得してシナリオコンテキストに格納する
        var hashCodeResult = hashCodeResultA == hashCodeResultB;
        _scenarioContext["result"] = hashCodeResult;
    }

    [Then("GetHashCodeメソッド実行結果の比較結果を評価する")]
    public void ThenGetHashCodeメソッド実行結果の比較結果を評価する(DataTable dataTable)
    {
        // 実行結果を評価する
        var result = (bool)_scenarioContext["result"];
        Assert.AreEqual(bool.Parse(dataTable.Rows[0]["result"]), result);
    }
}
