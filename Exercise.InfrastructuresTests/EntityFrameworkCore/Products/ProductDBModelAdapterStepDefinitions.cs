using CommonsHelpers.Factories;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Reqnroll;

namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Products;
/// <summary>
/// 演習-05 シナリオとテストドライバを作成し、メソッド単位でテストする
/// ProductとProductDBModelの相互変換メソッドの単体テストクラス
/// </summary>
[Binding]
public class ProductDBModelAdapterStepDefinitions
{
    // IProductAdapterの実装
    private readonly IProductAdapter<ProductDBModel> _productAdapter;
    // JSONからProductに変換するファクトリ
    private readonly ProductJSONFactory _productJSONFactory;
    // JSONからProductDBModelに変換するファクトリ
    private readonly ProductDBModelJSONFactory _productDBModelJSONFactory;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">FeatureContext</param>
    /// <param name="productJSONFactory">SONからProductに変換するファクトリ</param>
    /// <param name="productDBModelJSONFactory">JSONからProductDBModelに変換するファクトリ</param>
    public ProductDBModelAdapterStepDefinitions(
        FeatureContext featureContext,
        ProductJSONFactory productJSONFactory,
        ProductDBModelJSONFactory productDBModelJSONFactory)
    {
        _productAdapter = featureContext.Get<IProductAdapter<ProductDBModel>>();
        _productJSONFactory = productJSONFactory;
        _productDBModelJSONFactory = productDBModelJSONFactory;
    }

    private Product? _product;
    private ProductDBModel? _productDBModel;

    /// <summary>
    /// ProductをProductDBModelに変換する
    /// </summary>
    [Given("Categoryを保持したProductを用意する")]
    public void GivenCategoryを保持したProductを用意する(string multilineText)
    {
        // JSON形式のテストデータからProductエンティティを復元する
        _product = _productJSONFactory.ConvertProduct(multilineText);
    }
    [When("ProductDBModelを生成する")]
    public void WhenProductDBModelを生成する()
    {
        // ProductエンティティからProductDBModelに変換する
        _productDBModel = _productAdapter.Convert(_product!);
    }
    [Then("ProductDBModelのプロパティを検証する")]
    public void ThenProductDBModelのプロパティを検証する(string multilineText)
    {
        // JSON形式の検証データをProductDBModelに変換する
        var expected = _productDBModelJSONFactory.ConvertProduct(multilineText);
        // 商品Idを等価検証する
        Assert.AreEqual(expected.ProductId,_productDBModel!.ProductId);
        // 商品名を等価検証する
        Assert.AreEqual(expected.Name,_productDBModel.Name);
        // 単価を等価検証する
        Assert.AreEqual(expected.Price,_productDBModel.Price);
        // 商品カテゴリIdを等価検証する
        Assert.AreEqual(expected.Category!.CategoryId,_productDBModel.Category!.CategoryId);
        // 商品カテゴリ名を等価検証する
        Assert.AreEqual(expected.Category.Name,_productDBModel.Category.Name);
    }
    /// <summary>
    /// Product（Categoryを持たない）をProductDBModelに変換する
    /// </summary>
    [Given("Categoryを保持しないProductを用意する")]
    public void GivenCategoryを保持しないProductを用意する(string multilineText)
    {
        // JSON形式のテストデータからProductエンティティを復元する
        _product = _productJSONFactory.ConvertProduct(multilineText);
    }
    [Then("CategoryDBModelを持たないProductDBModelのプロパティを検証する")]
    public void ThenCategoryDBModelを持たないProductDBModelのプロパティを検証する(string multilineText)
    {
        // JSON形式の検証データをProductDBModelに変換する
        var expected = _productDBModelJSONFactory.ConvertProduct(multilineText);
        // 商品Idを等価検証する
        Assert.AreEqual(expected.ProductId, _productDBModel!.ProductId);
        // 商品名を等価検証する
        Assert.AreEqual(expected.Name, _productDBModel.Name);
        // 単価を等価検証する
        Assert.AreEqual(expected.Price, _productDBModel.Price);
    }

    /// <summary>
    /// ProductDBModelからProductを復元する
    /// </summary>
    [Given("ProductDBModelを用意する")]
    public void GivenProductDBModelを用意する(string multilineText)
    {
        // JSON形式のテストデータをProductDBModelに変換する
        _productDBModel = _productDBModelJSONFactory.ConvertProduct(multilineText);
    }
    [When("Productを復元する")]
    public void WhenProductを復元する()
    {
        // ProductDBModelからProductエンティティを復元する
        _product = _productAdapter.Restore(_productDBModel!);
    }
    [Then("Productのプロパティを評価する")]
    public void ThenProductのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductを復元する
        var expected = _productJSONFactory.ConvertProduct(multilineText);
        // 商品Idを等価検証する
        Assert.AreEqual(expected.Id.Value, _product!.Id.Value);
        // 商品名を等価検証する
        Assert.AreEqual(expected.Name.Value, _product.Name.Value);
        // 単価を等価検証する
        Assert.AreEqual(expected.Price.Value, _product.Price.Value);
        // 商品カテゴリIdを等価検証する
        Assert.AreEqual(expected.Category!.Id.Value, _product.Category!.Id.Value);
        // 商品カテゴリ名を等価検証する
        Assert.AreEqual(expected.Category.Name.Value, _product.Category.Name.Value);
    }
    /// <summary>
    /// ProductDBModelからProduct（Categoryを持たない)を復元する
    /// </summary>
    [Given("CategoryDBModelを保持しないProductDBModelを用意する")]
    public void GivenCategoryDBModelを保持しないProductDBModelを用意する(string multilineText)
    {
        // JSON形式のテストデータをProductDBModelに変換する
        _productDBModel = _productDBModelJSONFactory.ConvertProduct(multilineText);
    }
    [Then("Categoryを持たないProductのプロパティを評価する")]
    public void ThenCategoryを持たないProductのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductを復元する
        var expected = _productJSONFactory.ConvertProduct(multilineText);
        // 商品Idを等価検証する
        Assert.AreEqual(expected.Id.Value, _product!.Id.Value);
        // 商品名を等価検証する
        Assert.AreEqual(expected.Name.Value, _product.Name.Value);
        // 単価を等価検証する
        Assert.AreEqual(expected.Price.Value, _product.Price.Value);
    }

    private List<Product>? _products;
    private List<ProductDBModel>? _productDBModels;
    /// <summary>
    /// ProductのリストをProductDBModelのリストへの変換を検証する
    /// </summary>
    [Given("Categoryを保持したProductのリストを用意する")]
    public void GivenCategoryを保持したProductのリストを用意する(string multilineText)
    {
        // JSON形式のテストデータのリストからProductエンティティのリストを復元する
        _products = _productJSONFactory.ConvertProducts(multilineText);
    }
    [When("ProductのリストをProductDBModelのリストに変換する")]
    public void WhenProductのリストをProductDBModelのリストに変換する()
    {
        // ProductエンティティのリストをProductDBModelのリストを生成する
        _productDBModels = _productAdapter.ConvertList(_products!);
    }
    [Then("リスト内のProductDBModelのプロパティを評価する")]
    public void Thenリスト内のProductDBModelのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductDBModelのリストを生成する
        var expectedList = _productDBModelJSONFactory.ConvertProducts(multilineText);
        // リストからProductDBModelを取り出す
        for (int i = 0; i < expectedList.Count; i++)
        {
            // 商品Idを等価検証する
            Assert.AreEqual(expectedList[i].ProductId, _productDBModels![i].ProductId);
            // 商品名を等価検証する
            Assert.AreEqual(expectedList[i].Name, _productDBModels![i].Name);
            // 単価を等価検証する
            Assert.AreEqual(expectedList[i].Price, _productDBModels![i].Price);
            // 商品カテゴリIdを等価検証する
            Assert.AreEqual(expectedList[i].Category!.CategoryId, 
                    _productDBModels![i].Category!.CategoryId);
            // 商品カテゴリ名を等価検証する
            Assert.AreEqual(expectedList[i].Category!.Name, 
                    _productDBModels![i].Category!.Name);
        }
    }
    [Given("Categoryを保持しないProductのリストを用意する")]
    public void GivenCategoryを保持しないProductのリストを用意する(string multilineText)
    {

        // JSON形式のテストデータのリストからProductエンティティのリストを復元する
        _products = _productJSONFactory.ConvertProducts(multilineText);
    }
    [Then("リスト内のCategoryDBModelを持たないProductDBModelのプロパティを評価する")]
    public void Thenリスト内のCategoryDBModelを持たないProductDBModelのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductDBModelのリストを生成する
        var expectedList = _productDBModelJSONFactory.ConvertProducts(multilineText);
        // リストからProductDBModelを取り出す
        for (int i = 0; i < expectedList.Count; i++)
        {
            // 商品Idを等価検証する
            Assert.AreEqual(expectedList[i].ProductId, _productDBModels![i].ProductId);
            // 商品名を等価検証する
            Assert.AreEqual(expectedList[i].Name, _productDBModels![i].Name);
            // 単価を等価検証する
            Assert.AreEqual(expectedList[i].Price, _productDBModels![i].Price);
        }
    }

    /// <summary>
    /// ProductDBModelのリストからProductのリストへの復元を検証する
    /// </summary>
    [Given("CategoryDBModelを保持したProductDBModelのリストを用意する")]
    public void GivenCategoryDBModelを保持したProductDBModelのリストを用意する(string multilineText)
    {
        // JSON形式のテストデータをProductDBModelのリストに変換する
        _productDBModels = _productDBModelJSONFactory.ConvertProducts(multilineText);
    }
    [When("ProductDBModelのリストからProductのリストを復元する")]
    public void WhenProductDBModelのリストからProductのリストを復元する()
    {
        // ProductDBModelのリストからProductエンティティのリストを復元する
        _products = _productAdapter.RestoreList(_productDBModels!);
    }
    [Then("リスト内のドメインモデルProductのプロパティを評価する")]
    public void Thenリスト内のドメインモデルProductのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductエンティティのリストを復元する
        var expectedList = _productJSONFactory.ConvertProducts(multilineText);
        // リストからProductエンティティを取り出す
        for (int i = 0; i < expectedList.Count; i++)
        {
            // 商品Idを等価検証する
            Assert.AreEqual(expectedList[i].Id.Value, _products![i].Id.Value);
            // 商品名を等価検証する
            Assert.AreEqual(expectedList[i].Name.Value, _products![i].Name.Value);
            // 単価を等価検証する
            Assert.AreEqual(expectedList[i].Price.Value, _products![i].Price.Value);
            // 商品カテゴリIdを等価検証する
            Assert.AreEqual(expectedList[i].Category!.Id.Value, 
                _products![i].Category!.Id.Value);
            // 商品カテゴリ名を等価検証する
            Assert.AreEqual(expectedList[i].Category!.Name.Value,
                _products![i].Category!.Name.Value);
        }
    }
    /// <summary>
    /// ProductDBModelのリスト（CategoryDBModelを持たない）からProductのリストへの復元を検証する
    /// </summary>
    [Given("CategoryDBModelを保持しないProductDBModelのリストを用意する")]
    public void GivenCategoryDBModelを保持しないProductDBModelのリストを用意する(string multilineText)
    {
        // JSON形式のテストデータをProductDBModelのリストに変換する
        _productDBModels = _productDBModelJSONFactory.ConvertProducts(multilineText);
    }
    [Then("リスト内のCategoryを持たないProductのプロパティを評価する")]
    public void Thenリスト内のCategoryを持たないProductのプロパティを評価する(string multilineText)
    {
        // JSON形式の検証データからProductエンティティのリストを復元する
        var expectedList = _productJSONFactory.ConvertProducts(multilineText);
        // リストからProductエンティティを取り出す
        for (int i = 0; i < expectedList.Count; i++)
        {
            // 商品Idを等価検証する
            Assert.AreEqual(expectedList[i].Id.Value, _products![i].Id.Value);
            // 商品名を等価検証する
            Assert.AreEqual(expectedList[i].Name.Value, _products![i].Name.Value);
            // 単価を等価検証する
            Assert.AreEqual(expectedList[i].Price.Value, _products![i].Price.Value);
        }
    }
}
