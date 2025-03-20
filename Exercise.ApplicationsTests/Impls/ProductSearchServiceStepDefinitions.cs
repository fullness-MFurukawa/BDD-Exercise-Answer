using CommonsHelpers.Factories;
using Exercise.Applications.Services;
using Exercise.ApplicationsTests.Commons;
using Exercise.Domains.Models.Products;
using Reqnroll;
namespace Exercise.ApplicationsTests.Impls;
/// <summary>
/// 演習-10 ProductSearchServiceのテストシナリオとドライバを作成してテストする
/// IProductSearchServiceインターフェイスの実装結合テストクラス
/// </summary>
[Binding]
public class ProductSearchServiceStepDefinitions
{
    // 商品DatatTablesをProductに変換するファクトリ
    private readonly ProductDataTablesFactory _productDataTablesFactory;
    // NotFoundException、ExistsException評価用共通ステップクラス
    private readonly ExceptionCommonSteps _exceptionCommonSteps;
    // IProductSearchServiceインターフェイスの実装
    private readonly IProductSearchService _productSearchService;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    /// <param name="productDataTablesFactory">商品DatatTablesをProductに変換するファクトリ</param>
    /// <param name="exceptionCommonSteps">NotFoundException、ExistsException評価用共通ステップクラス</param>
    public ProductSearchServiceStepDefinitions(
        FeatureContext featureContext,
        ProductDataTablesFactory productDataTablesFactory,
        ExceptionCommonSteps exceptionCommonSteps)
    {
        _productSearchService = featureContext.Get<IProductSearchService>();
        _productDataTablesFactory = productDataTablesFactory;
        _exceptionCommonSteps = exceptionCommonSteps;
    }

    private ProductName? _keyword;
    private List<Product>? _products;

    [Given("検索キーワードを用意する {string}")]
    public void Given検索キーワードを用意する(string keyword)
    {
        _keyword = new ProductName(keyword);
    }

    [When("キーワード検索する")]
    public void Whenキーワード検索する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _products = _productSearchService.Execute(_keyword!);
        });
    }

    [Then("検索結果を評価する")]
    public void Then検索結果を評価する(DataTable dataTable)
    {
        // Data Tableから検証値をProductのリストに変換する
        var expectedProducts = _productDataTablesFactory.ConvertProducts(dataTable);
        // データ件数を評価する
        Assert.AreEqual(expectedProducts.Count, _products!.Count);
        // 取得された商品と期待結果の商品を検証する
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.AreEqual(expectedProducts[i].Id.Value, _products[i].Id.Value);
            Assert.AreEqual(expectedProducts[i].Name.Value, _products[i].Name.Value);
            Assert.AreEqual(expectedProducts[i].Price.Value, _products[i].Price.Value);
            Assert.AreEqual(expectedProducts[i].Category!.Id.Value,
                _products[i].Category!.Id.Value);
            Assert.AreEqual(expectedProducts[i].Category!.Name.Value,
                _products[i].Category!.Name.Value);
        }
    }
}
