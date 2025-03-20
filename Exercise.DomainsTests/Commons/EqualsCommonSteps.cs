using Reqnroll;
namespace Exercise.DomainsTests.Commons;
/// <summary>
/// Equals()メソッドの評価用共通ステップクラス
/// 提供
/// </summary>
[Binding]
public class EqualsCommonSteps
{
    // シナリオコンテキスト
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="scenarioContext">シナリオコンテキスト</param>
    #pragma warning disable IDE0290
    public EqualsCommonSteps(ScenarioContext scenarioContext)
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
        // シナリオコンテキストにテストターゲットを格納する
        _scenarioContext["ObjectA"] = objectA;
        _scenarioContext["ObjectB"] = objectB;
    }
    [When("Equalsメソッドを実行する")]
    public void WhenEqualsメソッドを実行する()
    {
        // シナリオコンテキストからテストターゲットを取り出す
        // 元の型で受け取る
        dynamic objectA = _scenarioContext["ObjectA"];
        dynamic objectB = _scenarioContext["ObjectB"];
        // Equals()メソッドを実行し、結果をシナリオコンテキストに格納する
        bool result = objectA.Equals(objectB);
        _scenarioContext["result"] = result;
    }
    [When("object型でEqualsメソッドを実行する")]
    public void WhenObject型でEqualsメソッドを実行する()
    {
        // シナリオコンテキストからテストターゲットを取り出す
        var objectA = _scenarioContext["ObjectA"];
        var objectB = _scenarioContext["ObjectB"];
        // object型でEquals()メソッドを実行し、結果をシナリオコンテキストに格納する
        var result = objectA.Equals(objectB);
        _scenarioContext["result"] = result;
    }
    [Then("Equalsメソッド実行結果を評価する")]
    public void ThenEqualsメソッド実行結果を評価する(DataTable dataTable)
    {
        // 実行結果をシナリオコンテキストから取得して評価する
        var result = (bool)_scenarioContext["result"];
        Assert.AreEqual(bool.Parse(dataTable.Rows[0]["result"]), result);
    }
}
