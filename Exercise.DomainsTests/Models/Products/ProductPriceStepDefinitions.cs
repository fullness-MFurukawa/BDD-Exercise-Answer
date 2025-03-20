using Exercise.Domains.Models.Products;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Products;
/// <summary>
/// ProductPriceクラスの単体テスト実装サンプル
/// 提供
/// </summary>
[Binding]
public class ProductPriceStepDefinitions
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
    public ProductPriceStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    private int _price;
    private ProductPrice? _productPrice;
    /*
     *  インスタンス生成(コンストラクタ)のテストステップ
     */
    [Given("商品単価を用意する {int}")]
    public void Given商品単価を用意する(int price)
    {
        _price = price;
    }
    [When("ProductPriceを生成する")]
    public void WhenProductPriceを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _productPrice = new ProductPrice(_price);
        });
    }
    [Then("ProductPriceの値は {int} である")]
    public void ThenProductPriceの値はである(int expectedPrice)
    {
        Assert.AreEqual(expectedPrice, _productPrice!.Value);
    }
    /*
     * Equals()メソッドのテストステップ
     */
    [Given("商品単価を比較する値を用意する")]
    public void Given商品単価を比較する値を用意する(DataTable dataTable)
    {
        var productPriceA = new ProductPrice(int.Parse(dataTable.Rows[0]["value1"]));
        var productPriceB = new ProductPrice(int.Parse(dataTable.Rows[0]["value2"]));
        _equalsCommonSteps.SetupObjects(productPriceA, productPriceB);
    }
    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("商品単価のハッシュ値を生成する値を用意する")]
    public void Given商品単価のハッシュ値を生成する値を用意する(DataTable dataTable)
    {
        var productPriceA = new ProductPrice(int.Parse(dataTable.Rows[0]["value1"]));
        var productPriceB = new ProductPrice(int.Parse(dataTable.Rows[0]["value2"]));
        _hashCodeCommonSteps.SetupObjects(productPriceA, productPriceB);
    }
}
