using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using System.Transactions;
namespace Exercise.Applications.Impls;
/// <summary>
/// 演習-11 IProductRegisterServiceインターフェイスとその実装を用意する
/// 新商品登録サービスインターフェイス実装クラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public class ProductRegisterService : IProductRegisterService
{
    // ICategoryRepositoryの実装
    private readonly ICategoryRepository _categoryRepository;
    // IProductRepositoryの実装
    private readonly IProductRepository _productRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="categoryRepository">ICategoryRepositoryの実装</param>
    /// <param name="productRepository">IProductRepositoryの実装</param>
    public ProductRegisterService(
        ICategoryRepository categoryRepository,
        IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    /// <summary>
    /// すべての商品カテゴリを返す
    /// </summary>
    /// <returns>商品カテゴリリスト</returns>
    public List<Category> GetCategories()
    {
        return _categoryRepository.FindAll();
    }
    /// <summary>
    /// 指定された商品カテゴリIdの商品カテゴリを返す
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotFoundException">該当する仕様品カテゴリが存在しない</exception>
    /// <returns></returns>
    public Category GetCategory(CategoryId id)
    {
        var result = _categoryRepository.FindById(id);
        if (result == null)
        {
            throw new NotFoundException($"商品カテゴリId:{id.Value}の商品カテゴリは見つかりませんでした。");
        }
        return result;
    }

    /// <summary>
    /// 商品の有無を調べる
    /// </summary>
    /// <param name="productName"></param>
    /// <exception cref="NotImplementedException">既に商品が存在する</exception>
    public void Exists(ProductName productName)
    {
        var result = _productRepository.Exists(productName);
        if (result)
        {
            throw new ExistsException($"商品名:{productName.Value}は、既に登録済みです。");
        }
    }

    /// <summary>
    /// 新商品を登録する
    /// </summary>
    /// <param name="product">登録商品</param>
    public void Register(Product product)
    {
        // トランザクションスコープを生成する
        using (var scope = new TransactionScope())
        {
            _productRepository.Create(product);
            // トランザクションをコミットする
            scope.Complete();
        }
    }
}
