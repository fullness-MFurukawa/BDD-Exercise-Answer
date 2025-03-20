using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Categories;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Categories;
/// <summary>
/// CategoryIdクラスの単体テスト実装サンプル
/// 提供
/// </summary>
[Binding]
public class CategoryIdStepDefinitions
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
    /// <param name="validateExceptionCommonSteps">ValidateException評価共通ステップ </param>
    /// <param name="equalsCommonSteps">Equals()メソッド評価共通ステップ</param>
    /// <param name="hashCodeCommonSteps">GetHashCode()メソッド評価共通ステップ</param>
    public CategoryIdStepDefinitions(
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
    private string? _id;
    private CategoryId? _categoryId;
    private ValidateException? _exception;

    [Given("商品カテゴリId {string} を用意する")]
    public void Given商品カテゴリIdを用意する(string id)
    {
        if (id.Equals("null"))
        {
            _id = null;
        }
        else
        {
            _id = id;
        }
    }

    [When("CategoryIdを生成する")]
    public void WhenCategoryIdを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _categoryId = new CategoryId(_id);
        });
    }

    [Then("CategoryIdの値は {string} である")]
    public void ThenCategoryIdの値はである(string expectedId)
    {
        // カテゴリIdが等価であることを評価する
        Assert.AreEqual(expectedId, _categoryId!.Value);
    }


    /*
     * Equals()メソッドのテストステップ
     */
    [Given("カテゴリIdを比較する値を用意する")]
    public void GivenカテゴリIdを比較する値を用意する(DataTable dataTable)
    {
        var categoryIdA = new CategoryId(dataTable.Rows[0]["value1"]);
        var categoryIdB = new CategoryId(dataTable.Rows[0]["value2"]);
        _equalsCommonSteps.SetupObjects(categoryIdA, categoryIdB);
    }

    /*
     * GetHashCode()メソッドのテストステップ
     */
    [Given("商品カテゴリIdのハッシュ値を生成する値を用意する")]
    public void Given商品カテゴリIdのハッシュ値を生成する値を用意する(DataTable dataTable)
    {
        var categoryIdA = new CategoryId(dataTable.Rows[0]["value1"]);
        var categoryIdB = new CategoryId(dataTable.Rows[0]["value2"]);
        _hashCodeCommonSteps.SetupObjects(categoryIdA, categoryIdB);
    }
}
