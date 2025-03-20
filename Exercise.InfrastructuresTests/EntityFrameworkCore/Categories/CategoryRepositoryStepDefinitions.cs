using CommonsHelpers.Factories;
using Exercise.Domains.Models.Categories;
using Reqnroll;
namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Categories;
/// <summary>
/// 商品カテゴリをCRUD操作するRepositoryインターフェイスの実装の単体テストクラス
/// テスト対象:
/// - FindById: 指定されたIdのレコードを取得する
/// - FindAll: すべてのカテゴリレコードを取得する
/// 提供
/// </summary>
[Binding]
public class CategoryRepositoryStepDefinitions
{
    // 商品カテゴリリポジトリ
    private readonly ICategoryRepository _categoryRepository;
    // YAMLデータをCategoryに変換するファクトリ
    private readonly CategoryYAMLFactory _categoryYAMLFactory;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="featureContext">FeatureContext</param>
    /// <param name="categoryYAMLFactory">YAMLデータをCategoryに変換するファクトリ</param>
    public CategoryRepositoryStepDefinitions(
        FeatureContext featureContext,
        CategoryYAMLFactory categoryYAMLFactory)
    {
        _categoryRepository = featureContext.Get<ICategoryRepository>();
        _categoryYAMLFactory = categoryYAMLFactory;
    }

    private CategoryId? _categoryId;
    private Category? _category;
    private List<Category>? _categories, _expectedCategories;

    /// <summary>
    /// 存在する商品カテゴリIdで商品カテゴリが取得できることを検証する
    /// </summary>
    [Given("商品カテゴリIdを⽤意する {string}")]
    public void Given商品カテゴリIdを意する(string id)
    {
        _categoryId = new CategoryId(id);
    }
    [When("⽤意した商品カテゴリIdで商品カテゴリを取得する")]
    public void When意した商品カテゴリIdで商品カテゴリを取得する()
    {
        _category = _categoryRepository.FindById(_categoryId!);
    }
    [Then("取得した商品カテゴリを評価する")]
    public void Then取得した商品カテゴリを評価する(string multilineText)
    {
        var expected = _categoryYAMLFactory.ConvertCategory(multilineText);
        // 取得した商品カテゴリのプロパティを期待値と比較して評価する
        Assert.AreEqual(expected.Id.Value, _category!.Id.Value);
        Assert.AreEqual(expected.Name.Value, _category!.Name.Value);
    }
    [Then("取得した商品カテゴリがnullであることを評価する")]
    public void Then取得した商品カテゴリがNullであることを評価する()
    {
        Assert.IsNull(_category);
    }

    /// <summary>
    /// すべての商品カテゴリが取得できることを検証する
    /// </summary>
    [Given("取得する商品カテゴリを⽤意する")]
    public void Given取得する商品カテゴリを意する(string multilineText)
    {
        _expectedCategories =
        _categoryYAMLFactory.ConvertCategories(multilineText);
    }
    [When("すべての商品カテゴリを取得する")]
    public void Whenすべての商品カテゴリを取得する()
    {
        _categories = _categoryRepository.FindAll();
    }
    [Then("すべての商品カテゴリが取得されたことを評価する")]
    public void Thenすべての商品カテゴリが取得されたことを評価する()
    {
        for (int i = 0; i < _expectedCategories!.Count; i++)
        {
            Assert.AreEqual(_expectedCategories[i].Id.Value,
            _categories![i].Id.Value);
            Assert.AreEqual(_expectedCategories[i].Name.Value,
            _categories[i].Name.Value);
        }
    }
}
