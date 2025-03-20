using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Products;
using Reqnroll;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
namespace CommonsHelpers.Factories;
/// <summary>
/// DocStrings(YAML)形式の値からProductエンティティを生成するファクトリクラス
/// 提供
/// </summary>
[Binding]
public class ProductYAMLFactory : AbstrctProductFactory<string, Product>
{
    /// <summary>
    /// YAMLからProductエンティティを生成する
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public override Product ConvertProduct(string data)
    {
        var deserializer = new DeserializerBuilder()
           .WithNamingConvention(new PascalCaseNamingConvention()).Build();
        var dto = deserializer.Deserialize<ProductDTO>(data);
        return CreateProduct(dto);
    }
    /// <summary>
    /// JSONからProductエンティティのリストを生成する
    /// </summary>
    /// <param name="data"></param> 
    /// <returns></returns>
    public override List<Product> ConvertProducts(string data)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(new PascalCaseNamingConvention()).Build();
        var dtoList = deserializer.Deserialize<List<ProductDTO>>(data);

        var products = new List<Product>();
        foreach (var d in dtoList)
        {
            products.Add(CreateProduct(d));
        }
        return products;
    }
}
