using CommonsHelpers.Dtos;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Reqnroll;
using System.Text.Json;
namespace CommonsHelpers.Factories;
/// <summary>
/// DocStrings(JSON)形式の値からProductDBModelを生成するファクトリ
/// 提供
/// </summary>
[Binding]
public class ProductDBModelJSONFactory : AbstrctProductFactory<string, ProductDBModel>
{
    /// <summary>
    /// JSONからProductDBModelを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override ProductDBModel ConvertProduct(string data)
    {
        var dto = JsonSerializer.Deserialize<ProductDTO>(data);
        return CreateProductDBModel(dto!);
    }
    /// <summary>
    /// JSONからProductDBModelのリストを生成する
    /// </summary>
    /// <param name="data"></param> 
    /// <returns></returns>
    public override List<ProductDBModel> ConvertProducts(string data)
    {
        var products = new List<ProductDBModel>();
        List<ProductDTO> dtoList = JsonSerializer.Deserialize<List<ProductDTO>>(data)!;
        foreach (var d in dtoList)
        {
            products.Add(CreateProductDBModel(d));
        }
        return products;
    }
}
