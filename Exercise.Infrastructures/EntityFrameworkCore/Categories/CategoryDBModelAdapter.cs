using Exercise.Domains.Models.Categories;
namespace Exercise.Infrastructures.EntityFrameworkCore.Categories;
/// <summary>
/// Categoryから他のモデルへの相互変換インターフェイスの実装
/// CategoryからCategoryDBModelに相互変換する
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/11</date>
/// <author>Fullness,Inc</author>
public class CategoryDBModelAdapter : ICategoryAdapter<CategoryDBModel>
{
    /// <summary>
    /// CategoryをCategoryDBModelに変換する
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    public CategoryDBModel Convert(Category category)
    {
        var model = new CategoryDBModel();
        model.CategoryId = category.Id.Value!;
        model.Name = category.Name.Value!;
        return model;
    }
    /// <summary>
    /// CategoryのリストをCategoryDBModelのリストに変換する
    /// </summary>
    /// <param name="categories"></param>
    /// <returns></returns>
    public List<CategoryDBModel> ConvertList(List<Category> categories)
    {
        var models = new List<CategoryDBModel>();
        foreach (var category in categories)
        {
            models.Add(Convert(category));
        }
        return models;
    }
    /// <summary>
    /// CategoryDBModelからCategoryを復元する
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Category Restore(CategoryDBModel model)
    {
        var category = new Category(
            new CategoryId(model.CategoryId),
            new CategoryName(model.Name));
        return category;
    }
    /// <summary>
    /// CategoryDBModelのリストからCategoryのリストに復元する
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    public List<Category> RestoreList(List<CategoryDBModel> models)
    {
        var categories = new List<Category>();
        foreach (var category in models)
        {
            categories.Add(Restore(category));
        }
        return categories;
    }
}
