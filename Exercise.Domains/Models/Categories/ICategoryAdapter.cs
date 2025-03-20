namespace Exercise.Domains.Models.Categories;
/// <summary>
/// Categoryエンティティから他のモデルへの変換する
/// 他のモデルからCategoryエンティティを復元する
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public interface ICategoryAdapter<T>
{
    /// <summary>
    /// Categoryエンティティを他のモデルに変換する
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    T Convert(Category category);

    /// <summary>
    /// 他のモデルからCategoryエンティティを復元する
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Category Restore(T model);

    /// <summary>
    /// Categoryエンティティリストを他のモデルのリストに変換する
    /// </summary>
    /// <param name="categories"></param>
    /// <returns></returns>
    List<T> ConvertList(List<Category> categories);

    /// <summary>
    /// 他のモデルのリストからCategoryエンティティのリストに復元する
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    List<Category> RestoreList(List<T> models);
}
