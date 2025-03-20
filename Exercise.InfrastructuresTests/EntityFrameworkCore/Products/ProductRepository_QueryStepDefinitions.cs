using CommonsHelpers.Factories;
using Exercise.Domains.Models.Products;
using Exercise.InfrastructuresTests.Commons;
using Reqnroll;

namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Products;
/// <summary>
/// 演習-07 参照系メソッドのシナリオとテストドライバを作成し、メソッド単位でテストする
/// </summary>
[Binding]
public class ProductRepository_QueryStepDefinitions
{
    // YAMLからProductを生成するファクトリクラス
    private readonly ProductYAMLFactory _productYAMLFactory;
    // テストターゲット
    private IProductRepository _productRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    /// <param name="productYAMLFactory">YAMLからProductを生成するファクトリクラス</param>
    public ProductRepository_QueryStepDefinitions(
        FeatureContext featureContext,
        ProductYAMLFactory productYAMLFactory)
    {
        _productRepository = featureContext.Get<IProductRepository>();
        _productYAMLFactory = productYAMLFactory;
    }
  
    private ProductId? _productId;
    private Product? _product;

    /// 
    /// FindById(): 指定されたIdの商品を取得する
    /// 
    [Given("商品Idを用意する {string}")]
    public void Given商品Idを用意する(string id)
    {
        // 指定された商品Idを_productIdに格納する
        _productId = new ProductId(id);
    }

    [When("商品Idで商品を取得する")]
    public void When商品Idで商品を取得する()
    {
        // FindById()メソッドを実行して結果を取得する
        _product = _productRepository.FindById(_productId!);
    }

    [Then("商品Idで取得した結果を評価する")]
    public void Then商品Idで取得した結果を評価する(string multilineText)
    {
        // シナリオを指定されたYAML形式の期待結果をProductに変換する
        var expected = _productYAMLFactory.ConvertProduct(multilineText);
        // 商品Idの等価検証をする
        Assert.AreEqual(expected.Id.Value, _product!.Id.Value);
        // 商品名の等価検証をする
        Assert.AreEqual(expected.Name.Value, _product!.Name.Value);
        // 商品単価の等価検証をする
        Assert.AreEqual(expected.Price.Value, _product!.Price.Value);
    }
    [Then("商品Idで取得した結果がnullであることを評価する")]
    public void Then商品Idで取得した結果がNullであることを評価する()
    {
        // 結果がnullであることを検証する
        Assert.IsNull(_product);
    }


    private ProductName? _keyword;
    private List<Product>? _products;
    /// 
    /// FindByNameContains(): 指定された商品キーワードに該当する商品を取得する
    /// 
    [Given("キーワードを用意する {string}")]
    public void Givenキーワードを用意する(string keyword)
    {
        // シナリオに指定されたキーワードを_keywordに格納する
        _keyword = new ProductName(keyword);
    }
    [When("キーワードで商品を取得する")]
    public void Whenキーワードで商品を取得する()
    {
        // 商品キーワード検索を実行して結果を_productに格納する
        _products = _productRepository.FindByNameContains(_keyword!);
    }
    [Then("キーワードで取得した結果を評価する")]
    public void Thenキーワードで取得した結果を評価する(string multilineText)
    {
        // YAML形式の評価データからProductエンティティのリストを生成する
        var expectedList = _productYAMLFactory.ConvertProducts(multilineText);
        // ProductリストからProductを取り出す
        for (int i = 0; i < expectedList.Count; i++)
        {
            // 商品Idの等価検証をする
            Assert.AreEqual(expectedList[i].Id.Value, _products![i].Id.Value);
            // 商品名の等価検証をする
            Assert.AreEqual(expectedList[i].Name.Value, _products[i].Name.Value);
            // 商品単価の等価検証をする
            Assert.AreEqual(expectedList[i].Price.Value, _products[i].Price.Value);
        }
    }
    [Then("キーワードで取得した結果がnullであることを評価する")]
    public void Thenキーワードで取得した結果がNullであることを評価する()
    {
        // 結果がnullであることを検証する
        Assert.IsNull(_products);
    }


    private ProductName? _productName;
    private bool _result;
    /// 
    /// Exists():指定された商品名の存在有無を取得する
    /// 
    [Given("商品名を用意する {string}")]
    public void Given商品名を用意する(string name)
    {
        // シナリオに指定された商品名を_productNameに格納する
        _productName = new ProductName(name);
    }
    [When("存在を調べる")]
    public void When存在を調べる()
    {
        // 商品名の有無を調べた結果を_resultに格納する
        _result = _productRepository.Exists(_productName!);
    }
    [Then("結果が返されることを評価する {string}")]
    public void Then結果が返されることを評価する(string expected)
    {
        // シナリオに指定された予測結果と等価検証する
        Assert.AreEqual(bool.Parse(expected), _result);
    }
}
