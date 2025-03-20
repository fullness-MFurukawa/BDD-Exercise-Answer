using CommonsHelpers.Factories;
using Exercise.Applications.Services;
using Exercise.ApplicationsTests.Commons;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Reqnroll;
namespace Exercise.ApplicationsTests.Impls;
/// <summary>
/// 演習-12 ProductRegisterServiceのテストシナリオとドライバを作成してテストする
/// IProductRegisterServiceインターフェイスの実装結合テストドライバ
/// </summary>
[Binding]
public class ProductRegisterServiceStepDefinitions
{
    // 商品登録サービスインターフェイスの実装
    private readonly IProductRegisterService _productRegisterService;
    // 商品カテゴリのYAMLをCategoryに変換するファクトリ
    private readonly CategoryYAMLFactory _categoryYAMLFactory;
    // 商品のYAMLをProductに変換するファクトリ
    private readonly ProductYAMLFactory _productYAMLFactory;
    // NotFoundException、ExistsException評価用共通ステップクラス
    private readonly ExceptionCommonSteps _exceptionCommonSteps;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    /// <param name="categoryYAMLFactory">商品カテゴリのYAMLをCategoryに変換するファクトリ</param>
    /// <param name="productYAMLFactory">商品のYAMLをProductに変換するファクトリ</param>
    /// <param name="exceptionCommonSteps">NotFoundException、ExistsException評価用共通ステップクラス</param>
    public ProductRegisterServiceStepDefinitions(
        FeatureContext featureContext,
        CategoryYAMLFactory categoryYAMLFactory,
        ProductYAMLFactory productYAMLFactory,
        ExceptionCommonSteps exceptionCommonSteps)
    {
        _productRegisterService = featureContext.Get<IProductRegisterService>();
        _categoryYAMLFactory = categoryYAMLFactory;
        _productYAMLFactory = productYAMLFactory;
        _exceptionCommonSteps = exceptionCommonSteps;
    }

    private List<Category>? _categories, _expectedCategories;
    private CategoryId? _categoryId;
    private Category? _category;
    /// <summary>
    /// GetCategories: すべてのカテゴリを返す
    /// </summary>
    [Given("取得する商品カテゴリを準備する")]
    public void Given取得する商品カテゴリを準備する(string multilineText)
    {
        _expectedCategories = _categoryYAMLFactory.ConvertCategories(multilineText);
    }
    [When("すべての商品カテゴリを取得する")]
    public void Whenすべての商品カテゴリを取得する()
    {
        _categories = _productRegisterService.GetCategories();
    }
    [Then("すべての商品カテゴリが取得できたことを評価する")]
    public void Thenすべての商品カテゴリが取得できたことを評価する()
    {
        for (int i = 0; i < _expectedCategories!.Count; i++)
        {
            Assert.AreEqual(_expectedCategories[i].Id.Value, _categories![i].Id.Value);
            Assert.AreEqual(_expectedCategories[i].Name.Value, _categories![i].Name.Value);
        }
    }

    /// <summary>
    /// GetCategory: 指定された商品カテゴリIdの商品カテゴリを返す
    /// </summary>
    [Given("商品カテゴリIdを用意する {string}")]
    public void Given商品カテゴリIdを用意する(string id)
    {
        _categoryId = new CategoryId(id);
    }

    [When("用意した商品カテゴリIdでカテゴリを取得する")]
    public void When用意した商品カテゴリIdでカテゴリを取得する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _category = _productRegisterService.GetCategory(_categoryId!);
        });
    }

    [Then("取得した商品カテゴリを評価する")]
    public void Then取得した商品カテゴリを評価する(string multilineText)
    {
        var expectedCategory = _categoryYAMLFactory.ConvertCategory(multilineText);
        Assert.AreEqual(expectedCategory.Id.Value, _category!.Id.Value);
        Assert.AreEqual(expectedCategory.Name.Value, _category.Name.Value);
    }

    /// <summary>
    /// Exists: 商品の有無を調べる
    /// </summary>
    private ProductName? _productName;
    [Given("商品名を用意する {string}")]
    public void Given商品名を用意する(string name)
    {
        _productName = new ProductName(name);
    }
    [When("商品名の有無を調べる")]
    public void When商品名の有無を調べる()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _productRegisterService.Exists(_productName!);
        });
    }

    /// <summary>
    /// Register: 新商品を登録する
    /// </summary>
    private Product? _product;
    [Given("新商品を用意する")]
    public void Given新商品を用意する(string multilineText)
    {
        _product = _productYAMLFactory.ConvertProduct(multilineText);
    }
    [When("新商品を登録する")]
    public void When新商品を登録する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _productRegisterService.Register(_product!);
        });
    }
    [Then("商品が登録されていることを商品名の有無で評価する")]
    public void Then商品が登録されていることを商品名の有無で評価する()
    {
        _exceptionCommonSteps.CaptureException(() =>
        {
            _productRegisterService.Exists(_product!.Name);
        });
    }
}
