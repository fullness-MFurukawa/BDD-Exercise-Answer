using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
namespace CommonsHelpers.Factories;
/// <summary>
/// シナリオに定義された値からCategory、List<Category>を生成するファクトリクラス
/// 提供
/// </summary>
public abstract class AbstractCategoryFactory<I, O>
{
    /// <summary>
    /// CategoryDTOからCategoryエンティティを生成する
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    protected Category CreateCategory(CategoryDTO dto)
    {
        var category = new Category(
                new CategoryId(dto.Id),
                new CategoryName(dto.Name));
        return category;
    }
    /// <summary>
    /// CategoryDTOからCategoryDBModelを生成する
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    protected CategoryDBModel CreateCategoryDBModel(CategoryDTO dto)
    {
        var model = new CategoryDBModel();
        model.CategoryId = dto.Id!;
        model.Name = dto.Name!;
        return model;
    }
    /// <summary>
    /// Categoryエンティティを生成する
    /// </summary>
    /// <param name="data">Data TablesまたはDoc Strings(JSON , YAML)</param>
    /// <returns></returns>
    public abstract O ConvertCategory(I data);
    /// <summary>
    /// Categoryエンティティのリストを生成する
    /// </summary>
    /// <param name="data">Data TablesまたはDoc Strings(JSON , YAML)</param>
    /// <returns></returns>
    public abstract List<O> ConvertCategories(I data);

}
