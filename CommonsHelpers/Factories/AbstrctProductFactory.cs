using CommonsHelpers.Dtos;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
namespace CommonsHelpers.Factories;
/// <summary>
/// シナリオに定義された値からProduct、List<Product>を生成するファクトリクラス
/// 提供
/// </summary>
public abstract class AbstrctProductFactory<I, O>
{
    /// <summary>
    /// ProductDTOからProductエンティティを生成する
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    protected Product CreateProduct(ProductDTO dto)
    {
        Category? category = null;
        if (dto.CategoryId != null && dto.CategoryName != null)
        {
            category = new Category(
                new CategoryId(dto.CategoryId),
                new CategoryName(dto.CategoryName));
        }
        var product = new Product(
            new ProductId(dto.Id),
            new ProductName(dto.Name),
            new ProductPrice(int.Parse(dto.Price!)),
            category);
        return product;
    }
    /// <summary>
    /// ProductDTOからProductDBModelを生成する
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    protected ProductDBModel CreateProductDBModel(ProductDTO dto)
    {
        var model = new ProductDBModel();
        model.ProductId = dto.Id!;
        model.Name = dto.Name!;
        model.Price = int.Parse(dto.Price!);
        if (dto.CategoryId != null && dto.CategoryName != null)
        {
            var category = new CategoryDBModel();
            category.CategoryId = dto.CategoryId!;
            category.Name = dto.CategoryName!;
            model.Category = category;
        }
        return model;
    }
    /// <summary>
    /// Productエンティティを生成する
    /// </summary>
    /// <param name="data">Data TablesまたはDoc Strings(JSON , YAML)</param>
    /// <returns></returns>
    public abstract O ConvertProduct(I data);
    /// <summary>
    /// Productエンティティのリストを生成する
    /// </summary>
    /// <param name="data">Data TablesまたはDoc Strings(JSON , YAML)</param>
    /// <returns></returns>
    public abstract List<O> ConvertProducts(I data);
}
