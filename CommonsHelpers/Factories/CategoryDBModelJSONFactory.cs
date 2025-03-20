using CommonsHelpers.Dtos;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Reqnroll;
using System.Text.Json;
namespace CommonsHelpers.Factories;
/// <summary>
/// Doc Strings(JSON)形式の値からCategoryDBModelを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class CategoryDBModelJSONFactory : AbstractCategoryFactory<string, CategoryDBModel>
{
    /// <summary>
    /// JSONからCategoryDBModelを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override CategoryDBModel ConvertCategory(string data)
    {
        var dto = JsonSerializer.Deserialize<CategoryDTO>(data);
        return CreateCategoryDBModel(dto!);
    }
    /// <summary>
    /// JSONからCategoryDBModelのリストを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override List<CategoryDBModel> ConvertCategories(string data)
    {
        var categories = new List<CategoryDBModel>();
        List<CategoryDTO> dtoList = JsonSerializer.Deserialize<List<CategoryDTO>>(data)!;
        foreach (var d in dtoList)
        {
            categories.Add(CreateCategoryDBModel(d));
        }
        return categories;
    }
}
