using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Categories;
using Reqnroll;
using System.Text.Json;
namespace CommonsHelpers.Factories;
/// <summary>
/// DocStrings(JSON)形式の値からCategoryエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class CategoryJSONFactory : AbstractCategoryFactory<string, Category>
{
    /// <summary>
    /// JSONからCategoryエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Category ConvertCategory(string data)
    {
        var dto = JsonSerializer.Deserialize<CategoryDTO>(data);
        return CreateCategory(dto!);
    }
    /// <summary>
    /// JSONからCategoryエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override List<Category> ConvertCategories(string data)
    {
        var categories = new List<Category>();
        List<CategoryDTO> dtoList = JsonSerializer.Deserialize<List<CategoryDTO>>(data)!;
        foreach (var d in dtoList)
        {
            categories.Add(CreateCategory(d));
        }
        return categories;
    }
}
