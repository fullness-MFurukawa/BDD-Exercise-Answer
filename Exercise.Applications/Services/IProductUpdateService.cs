using Exercise.Domains.Models.Products;
namespace Exercise.Applications.Services;
/// <summary>
/// 演習-13 IProductUpdateServiceインターフェイスとその実装を用意する
/// 商品変更サービスインターフェイス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public interface IProductUpdateService
{
    /// <summary>
    /// 指定された商品Idの商品を返す
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <exception cref="NotFoundException">該当する商品が存在しない</exception>
    /// <returns></returns>
    Product GetProduct(ProductId id);
    /// <summary>
    /// 商品を変更する
    /// </summary>
    /// <exception cref="NotFoundException">該当する商品が存在しない</exception>
    /// <param name="product">変更商品</param>
    void Execute(Product product);
}
