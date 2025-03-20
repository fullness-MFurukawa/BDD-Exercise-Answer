using CommonsHelpers.Factories;
using Exercise.Applications.Services;
using Exercise.ApplicationsTests.Commons;
using Exercise.Domains.Models.Products;
using Reqnroll;
namespace Exercise.ApplicationsTests.Impls;
/// <summary>
/// 演習-14 ProductUpdateServiceのテストシナリオとドライバを作成してテストする
/// IProductUpdateServiceインターフェイスの実装結合テストドライバ
/// </summary>
[Binding]
public class ProductUpdateServiceStepDefinitions
{
    // 商品変更サービスインターフェイスの実装
    private readonly IProductUpdateService _productUpdateService;
    // 商品のYAMLをProductに変換するファクトリ
    private readonly ProductYAMLFactory _productYAMLFactory;
    // NotFoundException、ExistsException評価用共通ステップクラス
    private readonly ExceptionCommonSteps _exceptionCommonSteps;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    /// <param name="productYAMLFactory">商品のYAMLをProductに変換するファクトリ</param>
    /// <param name="exceptionCommonSteps">NotFoundException、ExistsException評価用共通ステップクラス</param>
    public ProductUpdateServiceStepDefinitions(
        FeatureContext featureContext,
        ProductYAMLFactory productYAMLFactory,
        ExceptionCommonSteps exceptionCommonSteps)
    {
        _productUpdateService = featureContext.Get<IProductUpdateService>();
        _productYAMLFactory = productYAMLFactory;
        _exceptionCommonSteps = exceptionCommonSteps;
    }

    /// <summary>
    /// GetProduct: 指定されたキーワードで商品検索した結果を返す
    /// </summary>
    private ProductId? _productId;
    private Product? _product;
    [Given("商品Idを用意する {string}")]
    public void Given商品Idを用意する(string id)
    {
        _productId = new ProductId(id);
    }
    [When("用意した商品Idで対象商品を取得する")]
    public void When用意した商品Idで対象商品を取得する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _product = _productUpdateService.GetProduct(_productId!);
        });
    }
    [Then("用意した商品Idで取得した商品を評価する")]
    public void Then用意した商品Idで取得した商品を評価する(string multilineText)
    {
        var expectedProduct = _productYAMLFactory.ConvertProduct(multilineText);
        Assert.AreEqual(expectedProduct.Id.Value, _product!.Id.Value);
        Assert.AreEqual(expectedProduct.Name.Value, _product!.Name.Value);
        Assert.AreEqual(expectedProduct.Price.Value, _product!.Price.Value);
    }

    /// <summary>
    /// Execute: 商品を変更する
    /// </summary>
    [Given("変更商品を用意する")]
    public void Given変更商品を用意する(string multilineText)
    {
        _product = _productYAMLFactory.ConvertProduct(multilineText);
    }
    [When("商品名と単価を変更する")]
    public void When商品名と単価を変更する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _productUpdateService.Execute(_product!);
        });
    }
    [Then("変更した商品を取得して変更結果を評価する")]
    public void Then変更した商品を取得して変更結果を評価する()
    {
        var expectedProduct = _productUpdateService.GetProduct(_product!.Id);
        Assert.AreEqual(expectedProduct.Name.Value, _product?.Name.Value);
        Assert.AreEqual(expectedProduct.Price.Value, _product!.Price.Value);
    }
}
