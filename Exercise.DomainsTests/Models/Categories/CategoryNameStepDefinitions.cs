using Exercise.Domains.Models.Categories;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Categories;
/// <summary>
/// CategoryNameクラスの単体テスト実装サンプル
/// 提供
/// </summary>
[Binding]
public class CategoryNameStepDefinitions
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
    public CategoryNameStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    /*
     *  インスタンス生成(コンストラクタ)のテストステップ
     */
    private string? _name;
    private CategoryName? _categoryName;
    [Given("商品カテゴリ名を用意する {string}")]
    public void Given商品カテゴリ名を用意する(string name)
    {
        if (name.Equals("null"))
        {
            _name = null;
        }
        else
        {
            _name = name;
        }
    }
    [When("CategoryNameを生成する")]
    public void WhenCategoryNameを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _categoryName = new CategoryName(_name);
        });
    }
    [Then("CategoryNameの値は {string} である")]
    public void ThenCategoryNameの値はである(string expectedName)
    {
        Assert.AreEqual(expectedName, _categoryName!.Value);
    }

    /*
     * Equals()メソッドのテストステップ
     */
    [Given("商品カテゴリ名を比較する値を用意する")]
    public void Given商品カテゴリ名を比較する値を用意する(DataTable dataTable)
    {
        var CategoryNameA = new CategoryName(dataTable.Rows[0]["value1"]);
        var CategoryNameB = new CategoryName(dataTable.Rows[0]["value2"]);
        _equalsCommonSteps.SetupObjects(CategoryNameA, CategoryNameB);
    }
    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("商品カテゴリ名のハッシュ値を生成する値を用意する")]
    public void Given商品カテゴリ名のハッシュ値を生成する値を用意する(DataTable dataTable)
    {
        var categoryNameA = new CategoryName(dataTable.Rows[0]["value1"]);
        var categoryNameB = new CategoryName(dataTable.Rows[0]["value2"]);
        _hashCodeCommonSteps.SetupObjects(categoryNameA, categoryNameB);
    }
}
