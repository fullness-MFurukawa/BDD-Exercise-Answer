using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Products;
using Reqnroll;
namespace CommonsHelpers.Factories;
/// <summary>
/// Data Tables形式の値からProductエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class ProductDataTablesFactory : AbstrctProductFactory<DataTable, Product>
{
    /// <summary>
    /// DataTableからProductエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Product ConvertProduct(DataTable data)
    {
        var dto = data.CreateInstance<ProductDTO>();
        return CreateProduct(dto);
    }
    /// <summary>
    /// DataTableからProductエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override List<Product> ConvertProducts(DataTable data)
    {
        var products = new List<Product>();
        var dtoList = data.CreateSet<ProductDTO>().ToList();
        foreach (var d in dtoList)
        {
            products.Add(CreateProduct(d));
        }
        return products;
    }
}
