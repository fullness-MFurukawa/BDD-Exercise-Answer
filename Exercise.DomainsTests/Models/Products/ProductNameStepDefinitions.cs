using Exercise.Domains.Models.Products;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Products;
/// <summary>
/// ProductNameクラスの単体テスト実装サンプル
/// 提供
/// </summary>
[Binding]
public class ProductNameStepDefinitions
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
    public ProductNameStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    private string? _name;
    private ProductName? _productName;
    /*
     *  インスタンス生成(コンストラクタ)のテストステップ
     */
    [Given("商品名を用意する {string}")]
    public void Given商品名を用意する(string name)
    {
        if (!name.Equals("null"))
        {
            _name = name;
        }
    }
    [When("ProductNameを生成する")]
    public void WhenProductNameを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _productName = new ProductName(_name);
        });
    }
    [Then("ProductNameの値は {string} である")]
    public void ThenProductNameの値はである(string expectedName)
    {
        Assert.AreEqual(expectedName, _productName!.Value);
    }
    /*
     * Equals()メソッドのテストステップ
     */
    [Given("商品名を比較する値を用意する")]
    public void Given商品名を比較する値を用意する(DataTable dataTable)
    {
        var productNameA = new ProductName(dataTable.Rows[0]["value1"]);
        var productNameB = new ProductName(dataTable.Rows[0]["value2"]);
        _equalsCommonSteps.SetupObjects(productNameA, productNameB);
    }
    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("商品名のハッシュ値を生成する値を用意する")]
    public void Given商品名のハッシュ値を生成する値を用意する(DataTable dataTable)
    {
        var productNameA = new ProductName(dataTable.Rows[0]["value1"]);
        var productNameB = new ProductName(dataTable.Rows[0]["value2"]);
        _hashCodeCommonSteps.SetupObjects(productNameA, productNameB);
    }
}
