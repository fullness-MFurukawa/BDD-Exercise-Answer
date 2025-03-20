using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
namespace Exercise.Infrastructures.EntityFrameworkCore.Products;
/// <summary>
/// 演習-04 IProductAdapterインターフェイスと実装を作成する
/// Productから他のモデルへの相互変換インターフェイスの実装
/// ProductからProductDBModelに相互変換する
/// </summary>
public class ProductDBModelAdapter : IProductAdapter<ProductDBModel>
{
    // 商品カテゴリの相互変換アダプタ
    private readonly ICategoryAdapter<CategoryDBModel> _categoryAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="categoryAdapter">商品カテゴリの相互変換アダプタ</param>
    public ProductDBModelAdapter(ICategoryAdapter<CategoryDBModel> categoryAdapter)
    {
        _categoryAdapter = categoryAdapter;
    }
    /// <summary>
    /// ProductをProductDBModelに変換する
    /// </summary>
    /// <param name="product">Productのインスタンス</param>
    /// <returns>ProductDBModelの参照</returns>
    public ProductDBModel Convert(Product product)
    {
        var model = new ProductDBModel();
        model.ProductId = product.Id.Value!;
        model.Name = product.Name.Value!;
        model.Price = product.Price.Value!;
        if (product.Category != null)
        {
            var category = _categoryAdapter.Convert(product.Category);
            model.Category = category;
        }
        return model;
    }
    /// <summary>
    /// ProductのリストをProductDBModelのリストに変換する
    /// </summary>
    /// <param name="products">Productのリスト</param>
    /// <returns>ProductDBModelのリスト</returns>
    public List<ProductDBModel> ConvertList(List<Product> products)
    {
        var models = new List<ProductDBModel>();
        foreach (var product in products)
        {
            models.Add(Convert(product));
        }
        return models;
    }
    /// <summary>
    /// ProductDBModelからProductを復元する
    /// </summary>
    /// <param name="model">ProductDBModel</param>
    /// <returns>Productの参照</returns>
    public Product Restore(ProductDBModel model)
    {
        var id = new ProductId(model.ProductId);
        var name = new ProductName(model.Name);
        var price = new ProductPrice(model.Price);
        var product = new Product(id, name, price, null);
        if (model.Category != null)
        {
            product.ChangeCategory(_categoryAdapter.Restore(model.Category));
        }
        return product;
    }
    /// <summary>
    /// ProductDBModelのリストからProductのリストを復元する
    /// </summary>
    /// <param name="models">ProductModelのリスト</param>
    /// <returns>Productのリスト</returns>
    public List<Product> RestoreList(List<ProductDBModel> models)
    {
        var products = new List<Product>();
        foreach (var model in models)
        {
            products.Add(Restore(model));
        }
        return products;
    }
}
