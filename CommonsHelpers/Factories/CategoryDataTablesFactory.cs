using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Categories;
using Reqnroll;
namespace CommonsHelpers.Factories;
/// <summary>
/// Data Tables形式の値からCategoryエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class CategoryDataTablesFactory : AbstractCategoryFactory<DataTable, Category>
{
    /// <summary>
    /// DataTableからCategoryエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Category ConvertCategory(DataTable data)
    {
        var dto = data.CreateInstance<CategoryDTO>();
        return CreateCategory(dto);
    }
    /// <summary>
    /// DataTableからCategoryエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override List<Category> ConvertCategories(DataTable data)
    {
        var categories = new List<Category>();
        var dtoList = data.CreateSet<CategoryDTO>().ToList();
        foreach (var d in dtoList)
        {
            categories.Add(CreateCategory(d));
        }
        return categories;
    }
}
