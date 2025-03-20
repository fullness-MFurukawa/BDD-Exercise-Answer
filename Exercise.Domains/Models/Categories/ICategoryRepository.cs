namespace Exercise.Domains.Models.Categories;
/// <summary>
/// 永続化層から商品カテゴリをCRUD操作するリポジトリ
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public interface ICategoryRepository
{
    /// <summary>
    /// すべての商品カテゴリを取得する
    /// </summary>
    /// <returns>取得結果</returns>
    List<Category> FindAll();
    /// <summary>
    /// カテゴリIdで取得する
    /// </summary>
    /// <param name="id">商品カテゴリId</param>
    /// <returns>取得結果</returns>
    Category FindById(CategoryId id);
}
