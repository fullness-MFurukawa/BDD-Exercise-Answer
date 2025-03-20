using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
namespace Exercise.Applications.Impls;
/// <summary>
/// 商品キーワード検索サービスインターフェイスの実装
/// 演習-09 IProductSearchServiceインターフェイスとその実装を準備する
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public class ProductSearchService : IProductSearchService
{
    /// <summary>
    /// /// 永続化層から商品をCRUD操作するRepository
    /// </summary>
    private readonly IProductRepository _repository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository"></param>
    public ProductSearchService(IProductRepository repository)
    {
        _repository = repository;
    }
    /// <summary>
    /// キーワードで取得した商品を提供する
    /// </summary>
    /// <param name="keyword">検索キーワード</param>
    /// <exception cref="NotFoundException">該当商品が存在しない</exception>
    /// <returns>検索結果</returns>
    public List<Product> Execute(ProductName keyword)
    {
        var results = _repository.FindByNameContains(keyword);
        if (results == null)
        {
            var msg = $"キーワード:{keyword.Value}を含む商品は見つかりませんでした。";
            throw new NotFoundException(msg);
        }
        return results;
    }
}
