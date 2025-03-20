using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
using System.Transactions;
namespace Exercise.Applications.Impls;
/// <summary>
/// 演習-13 IProductUpdateServiceインターフェイスとその実装を用意する
/// 商品変更サービスインターフェイスの実装
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public class ProductUpdateService : IProductUpdateService
{
    // IProductRepositoryの実装
    private readonly IProductRepository _productRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productRepository">IProductRepositoryの実装</param>
    public ProductUpdateService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    /// <summary>
    /// 指定された商品Idの商品を返す
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <exception cref="NotFoundException">該当する商品が存在しない</exception>
    /// <returns></returns>
    public Product GetProduct(ProductId id)
    {
        var result = _productRepository.FindById(id);
        if (result == null)
        {
            throw new NotFoundException($"商品Id:{id.Value}に一致する商品が見つかりませんでした。");
        }
        return result;
        //   throw new NotImplementedException();
    }
    /// <summary>
    /// 商品を変更する
    /// </summary>
    /// <exception cref="NotFoundException">該当する商品が存在しない</exception>
    /// <param name="product">変更商品</param>
    public void Execute(Product product)
    {
        // トランザクションスコープを生成する
        using (var scope = new TransactionScope())
        {
            var result = _productRepository.UpdateById(product);
            if (result == null)
            {
                scope.Dispose();
                throw new NotFoundException($"商品Id:{product.Id.Value}に一致する商品が見つからないため、変更は失敗しました。");
            }
            // トランザクションをコミットする
            scope.Complete();
        }
    }
}
