using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reqnroll;
namespace Exercise.InfrastructuresTests.EntityFrameworkCore;
/// <summary>
/// AppDbContextの単体テストドライバ
/// EntityFramework Core InMemoryを利用
/// 提供
/// </summary>
[Binding]
public class AppDbContextStepDefinitions
{
    private AppDbContext? _dbContext;
    private CategoryDBModel? _testCategory;
    private ProductDBModel? _testProduct;

    [Given("テスト⽤のデータベースコンテキストを初期化する")]
    public void Givenテストのデータベースコンテキストを初期化する()
    {
        // インメモリデータベースを使⽤
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())  // 一意のデータベース名を使用
            .Options;
        // AppDbContextのインスタンスを作成
        _dbContext = new AppDbContext(options);
    }

    [When("新しいカテゴリと商品を保存する")]
    public void When新しいカテゴリと商品を保存する()
    {
        _testCategory = new CategoryDBModel
        {
            CategoryId = "cat001",
            Name = "⽂房具",
            Products = new List<ProductDBModel>()
        };
        _testProduct = new ProductDBModel
        {
            ProductId = "prod001",
            Name = "消しゴム",
            Price = 100,
            Category = _testCategory
        };
        _testCategory.Products.Add(_testProduct);
        _dbContext!.Categories!.Add(_testCategory);
        _dbContext!.Products!.Add(_testProduct);
        _dbContext.SaveChanges();
    }

    [Then("カテゴリと商品がデータベースに正しく保存されることを評価する")]
    public void Thenカテゴリと商品がデータベースに正しく保存されることを評価する()
    {
        var savedCategory = _dbContext!.Categories!
        .Include(c => c.Products).FirstOrDefault(c => c.CategoryId == "cat001");
        var savedProduct = _dbContext!.Products!
        .Include(p => p.Category).FirstOrDefault(p => p.ProductId == "prod001");
        Assert.IsNotNull(savedCategory);
        Assert.IsNotNull(savedProduct);
        Assert.AreEqual("⽂房具", savedCategory.Name);
        Assert.AreEqual("消しゴム", savedProduct.Name);
        Assert.AreEqual(100, savedProduct.Price);
        Assert.AreEqual("cat001", savedProduct.Category!.CategoryId);
    }

    [Given("既存のカテゴリと商品がデータベースに存在する")]
    public void Given既存のカテゴリと商品がデータベースに存在する()
    {
        _testCategory = new CategoryDBModel
        {
            CategoryId = "cat002",
            Name = "電⼦機器",
            Products = new List<ProductDBModel>()
        };
        _testProduct = new ProductDBModel
        {
            ProductId = "prod002",
            Name = "USBマウス",
            Price = 1200,
            Category = _testCategory
        };
        _testCategory.Products.Add(_testProduct);
        _dbContext!.Categories!.Add(_testCategory);
        _dbContext!.Products!.Add(_testProduct);
        _dbContext.SaveChanges();
    }

    [When("カテゴリと商品を取得する")]
    public void Whenカテゴリと商品を取得する()
    {
        _testCategory = _dbContext!.Categories!
        .Include(c => c.Products).FirstOrDefault(c => c.CategoryId == "cat002");
        _testProduct = _dbContext!.Products!
        .Include(p => p.Category).FirstOrDefault(p => p.ProductId == "prod002");
    }

    [Then("カテゴリと商品が正しく取得されることを評価する")]
    public void Thenカテゴリと商品が正しく取得されることを評価する()
    {
        Assert.IsNotNull(_testCategory);
        Assert.IsNotNull(_testProduct);
        Assert.AreEqual("電⼦機器", _testCategory.Name);
        Assert.AreEqual("USBマウス", _testProduct.Name);
        Assert.AreEqual(1200, _testProduct.Price);
        Assert.AreEqual("cat002", _testProduct.Category!.CategoryId);

        // InMemory データベースの削除
        _dbContext!.Database.EnsureDeleted();
        _dbContext!.Dispose();
    }
}
