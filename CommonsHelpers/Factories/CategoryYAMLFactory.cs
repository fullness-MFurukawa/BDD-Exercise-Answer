using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Categories;
using Reqnroll;
using YamlDotNet.Serialization;
namespace CommonsHelpers.Factories;
/// <summary>
/// DocStrings(YAML)形式の値からCategoryエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class CategoryYAMLFactory : AbstractCategoryFactory<string, Category>
{
    /// <summary>
    /// YAMLからCategoryエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Category ConvertCategory(string data)
    {
        var deserializer = new Deserializer();
        // CategoryDTO にデシリアライズ
        var dto = deserializer.Deserialize<CategoryDTO>(data);
        return CreateCategory(dto);
    }
    /// <summary>
    /// YAMLからCategoryエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override List<Category> ConvertCategories(string data)
    {

        var deserializer = new Deserializer();
        var dtoList = deserializer.Deserialize<List<CategoryDTO>>(data);

        var categories = new List<Category>();
        foreach (var d in dtoList)
        {
            categories.Add(CreateCategory(d));
        }
        return categories;
    }
}
