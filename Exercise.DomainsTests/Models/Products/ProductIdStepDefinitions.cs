using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Products;
/// <summary>
/// 演習-01 値オブジェクトProductIdの実装とテスト(インスタンス生成)
/// 演習-02 共通ステップを利用して、すべてのテストを実行する
/// </summary>
[Binding]
public class ProductIdStepDefinitions
{
    // ValidateException評価共通ステップ   
    private readonly ValidateExceptionCommonSteps _validateExceptionCommonSteps;
    // Equals()メソッド評価共通ステップ
    private readonly EqualsCommonSteps _equalsCommonSteps;
    // GetHashCode()メソッド評価共通ステップ
    private readonly GetHashCodeCommonSteps _hashCodeCommonSteps;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="validateExceptionCommonSteps">ValidateException評価共通ステップ</param>
    /// <param name="equalsCommonSteps">Equals()メソッド評価共通ステップ</param>
    /// <param name="hashCodeCommonSteps">GetHashCode()メソッド評価共通ステップ</param>
    public ProductIdStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    /*
     *  インスタンス生成(コンストラクタ)のテストステップ
     */
    private string? _id;
    private ProductId? _productId;
    private ValidateException? _exception;
    [Given("商品Idを用意する {string}")]
    public void Given商品Idを用意する(string id)
    {
        if (!id.Equals("null"))
        {
            _id = id;
        }
    }
    [When("ProductIdを生成する")]
    public void WhenProductIdを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _productId = new ProductId(_id);
        });
    }
    [Then("ProductIdの値は {string} である")]
    public void ThenProductIdの値はである(string expectedId)
    {
        Assert.IsNull(_exception);
        Assert.IsNotNull(_productId);
        Assert.AreEqual(expectedId, _productId.Value);
    }
    /*
    * Equals()メソッドのテストステップ
    */
    [Given("商品Idを比較する値を用意する")]
    public void Given商品Idを比較する値を用意する(DataTable dataTable)
    {
        var productIdA = new ProductId(dataTable.Rows[0]["value1"]);
        var productIdB = new ProductId(dataTable.Rows[0]["value2"]);
        _equalsCommonSteps.SetupObjects(productIdA, productIdB);
    }
    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("商品Idのハッシュ値を生成する値を用意する")]
    public void Given商品Idのハッシュ値を生成する値を用意する(DataTable dataTable)
    {
        var productIdA = new ProductId(dataTable.Rows[0]["value1"]);
        var productIdB = new ProductId(dataTable.Rows[0]["value2"]);
        _hashCodeCommonSteps.SetupObjects(productIdA, productIdB);
    }
}
