using CommonsHelpers.Factories;
using Exercise.Domains.Models.Products;
using Reqnroll;

namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Products;
/// <summary>
/// 演習-08 更新系メソッドのシナリオとテストドライバを作成し、メソッド単位でテストする
/// </summary>
[Binding]
public class ProductRepository_UpdateStepDefinitions
{
    // YAMLからProductを生成するファクトリクラス
    private readonly ProductYAMLFactory _productYAMLFactory;
    // テストターゲット
    private readonly IProductRepository _productRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキスト</param>
    /// <param name="productYAMLFactory">YAMLデータをProductエンティティに変換</param>
    public ProductRepository_UpdateStepDefinitions(
        FeatureContext featureContext,
        ProductYAMLFactory productYAMLFactory)
    {
        _productRepository = featureContext.Get<IProductRepository>();
        _productYAMLFactory = productYAMLFactory;
    }
   
    private Product? _product, _expectedProduct;
    private ProductId? _productId;
    /// 
    /// Create():商品を永続化する
    /// 
    [Given("新しい商品を用意する")]
    public void Given新しい商品を用意する(string multilineText)
    {
        // YAML形式のテストデータをProductエンティティに変換する
        _product = _productYAMLFactory.ConvertProduct(multilineText);
    }

    [When("新しい商品を永続化する")]
    public void When新しい商品を永続化する()
    {
        // テストデータを登録する
        _expectedProduct = _productRepository.Create(_product!);
    }

    [Then("商品が永続化されたことを評価する")]
    public void Then商品が永続化されたことを評価する()
    {
        // 商品Idを等価検証する
        Assert.AreEqual(_product!.Id.Value, _expectedProduct!.Id.Value);
        // 商品名を等価検証する
        Assert.AreEqual(_product.Name.Value, _expectedProduct!.Name.Value);
        // 商品単価を等価検証する
        Assert.AreEqual(_product.Price.Value, _expectedProduct!.Price.Value);
        // 商品カテゴリIdを等価検証する
        Assert.AreEqual(_product.Category!.Id.Value,
            _expectedProduct!.Category!.Id.Value);
        // 商品カテゴリ名を等価検証する
        Assert.AreEqual(_product.Category.Name.Value,
            _expectedProduct.Category.Name.Value);
    }

    /// 
    /// UpdateById():指定された商品Idの商品を変更する
    /// 
    [Given("変更商品を用意する")]
    public void Given変更商品を用意する(string multilineText)
    {
        // YAML形式のテーストデータをProductエンティティに変換する
        _product = _productYAMLFactory.ConvertProduct(multilineText);
    }

    [When("商品を変更する")]
    public void When商品を変更する()
    {
        // 商品を変更し、結果を_expectedProductに格納する
        _expectedProduct = _productRepository.UpdateById(_product!);
    }

    [Then("商品名と単価が変更されたことを評価する {string} {string}")]
    public void Then商品名と単価が変更されたことを評価する(string name, string price)
    {
        // 評価データの商品名と評価結果を等価検証する
        Assert.AreEqual(name, _expectedProduct!.Name.Value);
        // 評価データの商品単価と評価結果を等価検証する
        Assert.AreEqual(int.Parse(price), _expectedProduct!.Price.Value);
    }

    [Then("変更されずnullが返されることを評価する")]
    public void Then変更されずNullが返されることを評価する()
    {
        // 変更結果がnullであることを検証する
        Assert.IsNull(_expectedProduct);
    }

    /// 
    /// DeleteById():指定された商品Idの商品を削除する
    /// 
    [Given("削除対象の商品Idを用意する {string}")]
    public void Given削除対象の商品Idを用意する(string id)
    {
        // 商品Idを生成して_productIdに格納する
        _productId = new ProductId(id);
    }

    [When("商品を削除する")]
    public void When商品を削除する()
    {
        // 商品を削除し、結果を_productに格納する
        _product = _productRepository.DeleteById(_productId!);
    }

    [Then("削除された商品が返されることを評価する")]
    public void Then削除された商品が返されることを評価する(string multilineText)
    {
        // YAML形式の評価データをProductエンティティに変換する
        _expectedProduct = _productYAMLFactory.ConvertProduct(multilineText);
        // 商品Idを等価検証する
        Assert.AreEqual(_product!.Id.Value, _expectedProduct!.Id.Value);
        // 商品名を等価検証する
        Assert.AreEqual(_product.Name.Value, _expectedProduct!.Name.Value);
        // 商品単価を等価検証する
        Assert.AreEqual(_product.Price.Value, _expectedProduct!.Price.Value);
    }

    [Then("削除されずnullが返されることを評価する")]
    public void Then削除されずNullが返されることを評価する()
    {
        // 削除結果がnullであることを検証する
        Assert.IsNull(_product);
    }

}
