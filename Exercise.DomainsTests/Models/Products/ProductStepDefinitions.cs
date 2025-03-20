using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.DomainsTests.Commons;
using Reqnroll;
namespace Exercise.DomainsTests.Models.Products;
/// <summary>
/// 演習-03 エンティティProductの実装とテスト
/// </summary>
[Binding]
public class ProductStepDefinitions
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
    public ProductStepDefinitions(
        ValidateExceptionCommonSteps validateExceptionCommonSteps,
        EqualsCommonSteps equalsCommonSteps,
        GetHashCodeCommonSteps hashCodeCommonSteps)
    {
        _validateExceptionCommonSteps = validateExceptionCommonSteps;
        _equalsCommonSteps = equalsCommonSteps;
        _hashCodeCommonSteps = hashCodeCommonSteps;
    }

    private ProductId? _id;
    private ProductName? _name;
    private ProductPrice? _price;
    private Category? _category;
    private Product? _product;

    /*
     * インスタンス生成(コンストラクタ)のテストシナリオ
     */
    [Given("新しい商品名、単価、カテゴリを用意する")]
    public void Given新しい商品名単価カテゴリを用意する(DataTable dataTable)
    {
        if (!dataTable.Rows[0]["name"].Equals("null"))
        {
            _name = new ProductName(dataTable.Rows[0]["name"]);
        }
        if (!dataTable.Rows[0]["price"].Equals("null"))
        {
            _price = new ProductPrice(int.Parse(dataTable.Rows[0]["price"]));
        }
        var categoryId = new CategoryId(dataTable.Rows[0]["category_id"]);
        var categoryName = new CategoryName(dataTable.Rows[0]["category_name"]);
        _category = new Category(categoryId, categoryName);
    }

    [When("新しいProductを生成する")]
    public void When新しいProductを生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _product = new Product(_name!, _price!, _category);
        });
    }

    [Then("新しい商品Idを持った商品が生成されていることを評価する")]
    public void Then新しい商品Idを持った商品が生成されていることを評価する(DataTable dataTable)
    {
        Assert.IsNotNull(_product);
        Assert.IsNotNull(_product.Id);
        Assert.AreEqual(dataTable.Rows[0]["name"], _product.Name.Value);
        Assert.AreEqual(int.Parse(dataTable.Rows[0]["price"]), _product.Price.Value);
        Assert.AreEqual(dataTable.Rows[0]["category_id"], _product.Category!.Id.Value);
        Assert.AreEqual(dataTable.Rows[0]["category_name"], _product.Category.Name.Value);
    }

    [Given("既存商品のId、商品名、単価、カテゴリを用意する")]
    public void Given既存商品のId商品名単価カテゴリを用意する(DataTable dataTable)
    {
        if (!dataTable.Rows[0]["id"].Equals("null"))
        {
            _id = new ProductId(dataTable.Rows[0]["id"]);
        }
        _name = new ProductName(dataTable.Rows[0]["name"]);
        _price = new ProductPrice(int.Parse(dataTable.Rows[0]["price"]));
        var categoryId = new CategoryId(dataTable.Rows[0]["category_id"]);
        var categoryName = new CategoryName(dataTable.Rows[0]["category_name"]);
        _category = new Category(categoryId, categoryName);
    }

    [When("既存の商品を生成する")]
    public void When既存の商品を生成する()
    {
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            _product = new Product(_id!, _name!, _price!, _category);
        });
    }

    [Then("商品ID、商品名、単価、カテゴリは以下と等価であることを評価する")]
    public void Then商品ID商品名単価カテゴリは以下と等価であることを評価する(DataTable dataTable)
    {
        Assert.IsNotNull(_product);
        Assert.AreEqual(dataTable.Rows[0]["id"], _product.Id.Value);
        Assert.AreEqual(dataTable.Rows[0]["name"], _product.Name.Value);
        Assert.AreEqual(int.Parse(dataTable.Rows[0]["price"]), _product.Price.Value);
        Assert.AreEqual(dataTable.Rows[0]["category_id"], _product.Category!.Id.Value);
        Assert.AreEqual(dataTable.Rows[0]["category_name"], _product.Category!.Name.Value);
    }

    /*
    * ChangeName()メソッドのテストステップ
    */
    [When("商品名を変更する {string}")]
    public void When商品名を変更する(string name)
    {
        _product = new Product(_name!, _price!, _category);
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            if (!name.Equals("null"))
            {
                _product!.ChangeName(new ProductName(name));
            }
            else
            {
                _product!.ChangeName(null!);
            }
        });
    }

    [Then("商品名が変更されていることを検証する {string}")]
    public void Then商品名が変更されていることを検証する(string expectedName)
    {
        Assert.AreEqual(expectedName, _product!.Name.Value);
    }

    /*
    * ChangePrice()メソッドのテストステップ
    */
    [When("商品単価を変更する {string}")]
    public void When商品単価を変更する(string price)
    {
        _product = new Product(_name!, _price!, _category);
        _validateExceptionCommonSteps.CaptureException(() =>
        {
            if (!price.Equals("null"))
            {
                _product!.ChangePrice(new ProductPrice(int.Parse(price)));
            }
            else
            {
                _product!.ChangePrice(null!);
            }
        });
    }

    [Then("商品単価が変更されていることを検証する {string}")]
    public void Then商品単価が変更されていることを検証する(string expectedPrice)
    {
        Assert.AreEqual(int.Parse(expectedPrice), _product!.Price.Value);
    }

    /*
     * Equals()メソッド共通ステップのシナリオ
     */
    private Product? _productA, _productB;
    [Given("比較対象の商品を用意する")]
    public void Given比較対象の商品を用意する(DataTable dataTable)
    {
        var id = new ProductId(dataTable.Rows[0]["id1"]);
        var name = new ProductName(dataTable.Rows[0]["name1"]);
        var price = new ProductPrice(int.Parse(dataTable.Rows[0]["price1"]));
        _productA = new Product(id, name, price, null);
        id = new ProductId(dataTable.Rows[0]["id2"]);
        name = new ProductName(dataTable.Rows[0]["name2"]);
        price = new ProductPrice(int.Parse(dataTable.Rows[0]["price2"]));
        _productB = new Product(id, name, price, null);
        _equalsCommonSteps.SetupObjects(_productA, _productB);
    }
    /*
     * GetHashCode()メソッド共通ステップのシナリオ
     */
    [Given("ハッシュ値を生成する商品を用意する")]
    public void Givenハッシュ値を生成する商品を用意する(DataTable dataTable)
    {
        var id = new ProductId(dataTable.Rows[0]["id1"]);
        var name = new ProductName(dataTable.Rows[0]["name1"]);
        var price = new ProductPrice(int.Parse(dataTable.Rows[0]["price1"]));
        _productA = new Product(id, name, price, null);
        id = new ProductId(dataTable.Rows[0]["id2"]);
        name = new ProductName(dataTable.Rows[0]["name2"]);
        price = new ProductPrice(int.Parse(dataTable.Rows[0]["price2"]));
        _productB = new Product(id, name, price, null);
        _hashCodeCommonSteps.SetupObjects(_productA, _productB);
    }
}
