using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
namespace Exercise.Applications.Services;
/// <summary>
/// 演習-11 IProductRegisterServiceインターフェイスとその実装を用意する
/// 新商品登録サービスインターフェイス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/15</date>
/// <author>Fullness,Inc</author>
public interface IProductRegisterService
{
    /// <summary>
    /// すべての商品カテゴリを返す
    /// </summary>
    /// <returns>商品カテゴリリスト</returns>
    List<Category> GetCategories();
    /// <summary>
    /// 指定された商品カテゴリIdの商品カテゴリを返す
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotFoundException">該当する商品カテゴリが存在しない</exception>
    /// <returns></returns>
    Category GetCategory(CategoryId id);
    /// <summary>
    /// 商品の有無を調べる
    /// </summary>
    /// <param name="productName"></param>
    /// <exception cref="ExistsException">商品が既に存在する</exception>
    void Exists(ProductName productName);
    /// <summary>
    /// 新商品を登録する
    /// </summary>
    /// <param name="product">登録商品</param>
    void Register(Product product);
}
