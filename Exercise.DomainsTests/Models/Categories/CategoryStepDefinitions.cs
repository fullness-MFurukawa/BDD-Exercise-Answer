using Exercise.Domains.Models.Categories;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Categories;
/// <summary>
/// Categoryクラスの単体テスト実装サンプル
/// 提供
/// </summary>
[Binding]
public class CategoryStepDefinitions
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
    public CategoryStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    private CategoryId? _categoryId;
    private CategoryName? _categoryName;
    private Category? _category;
    /*
     *  インスタンス生成(コンストラクタ)のテストステップ
     */
    [Given("新しい商品カテゴリを用意する {string}")]
    public void Given新しい商品カテゴリを用意する(string name)
    {
        if (!name.Equals("null"))
        {
            _categoryName = new CategoryName(name);
        }
    }
    [When("新しいCategoryを生成する")]
    public void When新しいCategoryを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _category = new Category(_categoryName!);
        });
    }
    [Then("新しい商品カテゴリIdを持ったカテゴリが生成されていることを評価する {string}")]
    public void Then新しい商品カテゴリIdを持ったカテゴリが生成されていることを評価する(string expectedName)
    {
        Assert.IsNotNull(_category);
        Assert.IsNotNull(_category.Id);
        Assert.AreEqual(expectedName, _category.Name.Value);
    }
    [Given("既存商品カテゴリを用意する")]
    public void Given既存商品カテゴリを用意する(DataTable dataTable)
    {
        if (!dataTable.Rows[0]["id"].Equals("null"))
        {
            _categoryId = new CategoryId(dataTable.Rows[0]["id"]);
        }
        if (!dataTable.Rows[0]["name"].Equals("null"))
        {
            _categoryName = new CategoryName(dataTable.Rows[0]["name"]);
        }
    }
    [When("既存のCategoryを生成する")]
    public void When既存のCategoryを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _category = new Category(_categoryId!, _categoryName!);
        });
    }
    [Then("商品カテゴリIdと商品カテゴリ名は以下と等価であることを評価する")]
    public void Then商品カテゴリIdと商品カテゴリ名は以下と等価であることを評価する(DataTable dataTable)
    {
        Assert.IsNotNull(_category);
        Assert.AreEqual((string)dataTable.Rows[0]["id"], _category.Id.Value);
        Assert.AreEqual((string)dataTable.Rows[0]["name"], _category.Name.Value);
    }

    /*
     * ChangeName()メソッドのテストステップ
     */
    [When("商品カテゴリ名を変更する {string}")]
    public void When商品カテゴリ名を変更する(string name)
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _category = new Category(_categoryName!);
            if (!name.Equals("null"))
            {
                _category!.ChangeName(new CategoryName(name));
            }
            else
            {
                _category!.ChangeName(null!);
            }
        });
    }
    [Then("商品カテゴリ名が変更されていることを検証する {string}")]
    public void Then商品カテゴリ名が変更されていることを検証する(string expectedName)
    {
        Assert.AreNotEqual(expectedName, _categoryName!.Value);
        Assert.AreEqual(expectedName, _category!.Name.Value);
    }
    /*
     * Equals()メソッドのテストステップ
     */
    [Given("比較対象の商品カテゴリを用意する")]
    public void Given比較対象の商品カテゴリを用意する(DataTable dataTable)
    {
        var idA = new CategoryId(dataTable.Rows[0]["id1"]);
        var nameA = new CategoryName(dataTable.Rows[0]["name1"]);
        var categoryA = new Category(idA, nameA);
        var idB = new CategoryId(dataTable.Rows[0]["id2"]);
        var nameB = new CategoryName(dataTable.Rows[0]["name2"]);
        var categoryB = new Category(idB, nameB);
        _equalsCommonSteps.SetupObjects(categoryA, categoryB);
    }
    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("ハッシュ値を生成する商品カテゴリを用意する")]
    public void Givenハッシュ値を生成する商品カテゴリを用意する(DataTable dataTable)
    {
        var idA = new CategoryId(dataTable.Rows[0]["id1"]);
        var nameA = new CategoryName(dataTable.Rows[0]["name1"]);
        var categoryA = new Category(idA, nameA);
        var idB = new CategoryId(dataTable.Rows[0]["id2"]);
        var nameB = new CategoryName(dataTable.Rows[0]["name2"]);
        var categoryB = new Category(idB, nameB);
        _hashCodeCommonSteps.SetupObjects(categoryA, categoryB);
    }
}
