using Exercise.Domains.Models.Products;
namespace Exercise.Applications.Services;
/// <summary>
/// 商品キーワード検索サービスインターフェイス
/// 演習-09 IProductSearchServiceインターフェイスとその実装を準備する
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public interface IProductSearchService
{
    /// <summary>
    /// キーワードで取得した商品を提供する
    /// </summary>
    /// <param name="keyword">検索キーワード</param>
    /// <exception cref="NotFoundException">該当商品が存在しない</exception>
    /// <returns>検索結果</returns>
    List<Product> Execute(ProductName keyword);
}
