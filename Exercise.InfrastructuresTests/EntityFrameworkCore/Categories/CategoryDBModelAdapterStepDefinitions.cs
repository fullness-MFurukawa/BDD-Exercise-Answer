
using CommonsHelpers.Factories;
using Exercise.Domains.Models.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Reqnroll;

namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Categories;
/// <summary>
/// CategoryとCategoryDBModelの相互変換メソッドの単体テストドライバ
/// 提供
/// </summary>
[Binding]
public class CategoryDBModelAdapterStepDefinitions
{
    // CategoryとCategoryDBModelの相互変換
    private readonly ICategoryAdapter<CategoryDBModel> _categoryAdapter;
    // JSONからCategoryを生成する
    private readonly CategoryJSONFactory _categoryJSONFactory;
    // JSONからCategoryDBModelを生成する
    private readonly CategoryDBModelJSONFactory _categoryDBModelJSONFactory;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="categoryJSONFactory">SONからCategoryを生成する</param>
    /// <param name="categoryDBModelJSONFactory">JSONからCategoryDBModelを生成する</param>
    public CategoryDBModelAdapterStepDefinitions(
        FeatureContext featureContext,
        CategoryJSONFactory categoryJSONFactory,
        CategoryDBModelJSONFactory categoryDBModelJSONFactory)
    {
        _categoryAdapter = featureContext.Get<ICategoryAdapter<CategoryDBModel>>();
        _categoryJSONFactory = categoryJSONFactory;
        _categoryDBModelJSONFactory = categoryDBModelJSONFactory;
    }

    private Category? _category;
    private CategoryDBModel? _categoryDBModel;
    private List<Category>? _categories;
    private List<CategoryDBModel>? _categoriesDBModel;

    /// <summary>
    /// CategoryをCategoryDBModelへ変換する
    /// </summary>
    [Given("Categoryを⽤意する")]
    public void GivenCategoryを意する(string multilineText)
    {
        _category = _categoryJSONFactory.ConvertCategory(multilineText);
        Console.WriteLine($"_category = {_category}");
    }
    [When("CategoryをCategoryModelに変換する")]
    public void WhenCategoryをCategoryModelに変換する()
    {
        _categoryDBModel = _categoryAdapter.Convert(_category!);
        Console.WriteLine($"_categoryDBModel = {_categoryDBModel}");
    }
    [Then("CategoryDBModelのプロパティを検証する")]
    public void ThenCategoryDBModelのプロパティを検証する(string multilineText)
    {
        var expectedModel =
            _categoryDBModelJSONFactory.ConvertCategory(multilineText);
        Console.WriteLine($"expectedModel = {expectedModel}");
        Assert.AreEqual(expectedModel.CategoryId, _categoryDBModel!.CategoryId);
        Assert.AreEqual(expectedModel.Name, _categoryDBModel!.Name);
    }

    /// <summary>
    /// CategoryのリストをCategoryDBModelのリストへ変換する
    /// </summary>
    [Given("Categoryのリストを⽤意する")]
    public void GivenCategoryのリストを意する(string multilineText)
    {
        _categories = _categoryJSONFactory.ConvertCategories(multilineText);
    }
    [When("CategoryのリストをCategoryModelのリストに変換する")]
    public void WhenCategoryのリストをCategoryModelのリストに変換する()
    {
        _categoriesDBModel = _categoryAdapter.ConvertList(_categories!);
    }
    [Then("リスト内のCategoryDBModelのプロパティを検証する")]
    public void Thenリスト内のCategoryDBModelのプロパティを検証する(string multilineText)
    {
        var expectedList =
            _categoryDBModelJSONFactory.ConvertCategories(multilineText);
        // 検証する
        for (int i = 0; i < expectedList!.Count; i++)
        {
            Assert.AreEqual(expectedList[i].CategoryId,
            _categoriesDBModel![i].CategoryId);
            Assert.AreEqual(expectedList[i].Name, _categoriesDBModel![i].Name);
        }
    }

    /// <summary>
    /// CategoryDBModelからCategoryを復元する
    /// </summary>
    [Given("CategoryDBModelを⽤意する")]
    public void GivenCategoryDBModelを意する(string multilineText)
    {
        _categoryDBModel =
            _categoryDBModelJSONFactory.ConvertCategory(multilineText);
    }
    [When("CategoryModelからCategoryを復元する")]
    public void WhenCategoryModelからCategoryを復元する()
    {
        _category = _categoryAdapter.Restore(_categoryDBModel!);
    }
    [Then("Categoryのプロパティを検証する")]
    public void ThenCategoryのプロパティを検証する(string multilineText)
    {
        var expectedCategory =
            _categoryJSONFactory.ConvertCategory(multilineText);
        Assert.AreEqual(expectedCategory.Id.Value, _category!.Id.Value);
        Assert.AreEqual(expectedCategory.Name.Value, _category!.Name.Value);
    }

    /// <summary>
    /// CategoryDBModelのリストからCategoryのリストを復元する
    /// </summary>
    [Given("CategoryDBModelのリストを⽤意する")]
    public void GivenCategoryDBModelのリストを意する(string multilineText)
    {
        _categoriesDBModel =
            _categoryDBModelJSONFactory.ConvertCategories(multilineText);
    }
    [When("CategoryDBModelのリストからCategoryのリストを復元する")]
    public void WhenCategoryDBModelのリストからCategoryのリストを復元する()
    {
        _categories = _categoryAdapter.RestoreList(_categoriesDBModel!);
    }
    [Then("リスト内のCategoryのプロパティを検証する")]
    public void Thenリスト内のCategoryのプロパティを検証する(string multilineText)
    {
        // JSONデータをDictionaryのリストに変換
        var categoryList = _categoryJSONFactory.ConvertCategories(multilineText);
        // 復元結果の件数を検証する
        Assert.AreEqual(categoryList!.Count, _categoriesDBModel!.Count);
        // 復元したリストの値を検証する
        for (int i = 0; i < categoryList!.Count; i++)
        {
            Assert.AreEqual(categoryList[i].Id.Value, _categories![i].Id.Value);
            Assert.AreEqual(categoryList[i].Name.Value,
            _categories![i].Name.Value);
        }
    }
}
