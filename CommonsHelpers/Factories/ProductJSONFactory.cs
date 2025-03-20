using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Products;
using Reqnroll;
using System.Text.Json;
namespace CommonsHelpers.Factories;
/// <summary>
/// DocStrings(JSON)形式の値からProductエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class ProductJSONFactory : AbstrctProductFactory<string, Product>
{
    /// <summary>
    /// JSONからProductエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Product ConvertProduct(string data)
    {
        var dto = JsonSerializer.Deserialize<ProductDTO>(data);
        return CreateProduct(dto!);
    }
    /// <summary>
    /// JSONからProductエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param> 
    /// <returns></returns>
    public override List<Product> ConvertProducts(string data)
    {
        var products = new List<Product>();
        List<ProductDTO> dtoList = JsonSerializer.Deserialize<List<ProductDTO>>(data)!;
        foreach (var d in dtoList)
        {
            products.Add(CreateProduct(d));
        }
        return products;
    }
}
