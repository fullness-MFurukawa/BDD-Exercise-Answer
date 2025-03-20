using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.InfrastructuresTests.Commons;
using Reqnroll;
namespace Exercise.InfrastructuresTests.EntityFrameworkCore;
/// <summary>
/// InternalExceptionがスローされることを検証するテストクラス
/// </summary>
[Binding]
public class InternalExceptionStepDefinitions
{
    // フィーチャーコンテキスト
    private readonly FeatureContext _featureContext;
    // InternalException評価共通ステップ
    private readonly InternalExceptionCommonSteps _internalExceptionCommonSteps;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキスト</param>
    /// <param name="internalExceptionCommonSteps">InternalException評価共通ステップ</param>
    public InternalExceptionStepDefinitions(
        FeatureContext featureContext,
        InternalExceptionCommonSteps internalExceptionCommonSteps)
    {
        _featureContext = featureContext;
        _internalExceptionCommonSteps = internalExceptionCommonSteps;
    }

    private ICategoryRepository? _categoryRepository;
    // 演習-07で追加
    private IProductRepository? _productRepository;

    [Given("ダミーのDbContextを利用するリポジトリを取得する")]
    public void GivenダミーのDbContextを利用するリポジトリを取得する()
    {
        _categoryRepository =
           _featureContext.Get<ICategoryRepository>("InternalExceptionCategoryRepository");
        // 演習-07で追加
        _productRepository =
            _featureContext.Get<IProductRepository>("InternalExceptionProductRepository");
    }
    /// <summary>
    /// ICategoryRepositoryインターフェイスのメソッドに対するInternalExceptionテスト
    /// </summary>
    [When("CategoryRepositoryのFindByIdメソッドを実行する")]
    public void WhenCategoryRepositoryのFindByIdメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            _categoryRepository!.FindById(
                new CategoryId("40cffd3bf63645c69a875c87ecb6f200"));
        });
    }
    [When("CategoryRepositoryのFindAllメソッドを実行する")]
    public void WhenCategoryRepositoryのFindAllメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            _categoryRepository!.FindAll();
        });
    }

    /// <summary>
    /// IProductRepositoryインターフェイスの参照系メソッドに対するInternalExceptionテスト 
    /// </summary>
    [When("ProductRepositoryのFindByIdメソッドを実行する")]
    public void WhenProductRepositoryのFindByIdメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            _productRepository!.FindById(new ProductId("f073f7c3f35744ffbbdb3815e1d4b6c2"));
        });
    }
    [When("ProductRepositoryのFindByNameContainsメソッドを実行する")]
    public void WhenProductRepositoryのFindByNameContainsメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            _productRepository!.FindByNameContains(new ProductName("ペン"));
        });
    }
    [When("ProductRepositoryのExistsメソッドを実行する")]
    public void WhenProductRepositoryのExistsメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            _productRepository!.Exists(new ProductName("消しゴム"));
        });
    }

    /// <summary>
    /// IProductRepositoryインターフェイスの更新系メソッドに対するInternalExceptionテスト 
    /// </summary>
    [When("ProductRepositoryのCreateメソッドを実行する")]
    public void WhenProductRepositoryのCreateメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            var product = new Product(
                new ProductId("d4c3b32d292b40b1bc2533fc5f1ec335"),
                new ProductName("消しゴム"),
                new ProductPrice(120),
                new Category(
                    new CategoryId("40cffd3bf63645c69a875c87ecb6f200"),
                    new CategoryName("文房具")));
            _productRepository!.Create(product);
        });
    }
    [When("ProductRepositoryのUpdateByIdメソッドを実行する")]
    public void WhenProductRepositoryのUpdateByIdメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            var product = new Product(
                new ProductId("d4c3b32d292b40b1bc2533fc5f1ec335"),
                new ProductName("消しゴム"),
                new ProductPrice(120),
                new Category(
                    new CategoryId("40cffd3bf63645c69a875c87ecb6f200"),
                    new CategoryName("文房具")));
            _productRepository!.UpdateById(product);
        });
    }

    [When("ProductRepositoryのDeleteByIdメソッドを実行する")]
    public void WhenProductRepositoryのDeleteByIdメソッドを実行する()
    {
        _internalExceptionCommonSteps.CaptureException(() =>
        {
            var productId = new ProductId("d4c3b32d292b40b1bc2533fc5f1ec335");
            _productRepository!.DeleteById(productId);
        });
    }
}
