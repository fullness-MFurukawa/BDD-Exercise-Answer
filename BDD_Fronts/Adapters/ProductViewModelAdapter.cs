using BDD_Fronts.Models.Categories;
using BDD_Fronts.Models.Products;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;

namespace BDD_Fronts.Adapters;
/// <summary>
/// ProductからProductViewModelへの変換と
/// Productへ復元するAdapterインターフェイスの実装
/// 提供
/// </summary>
public class ProductViewModelAdapter : IProductAdapter<ProductViewModel>
{
    // 商品カテゴリ相互変換アダプタ
    private readonly ICategoryAdapter<CategoryViewModel> _categoryAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="categoryAdapter">商品カテゴリ相互変換アダプタ</param>
    public ProductViewModelAdapter(ICategoryAdapter<CategoryViewModel> categoryAdapter)
    {
        _categoryAdapter = categoryAdapter;
    }

    public ProductViewModel Convert(Product product)
    {
        var model = new ProductViewModel();
        model.ProductId = product.Id.Value;
        model.ProductName = product.Name.Value;
        model.ProductPrice = product.Price.Value;
        if (product.Category != null)
        {
            var categoryModel = new CategoryViewModel();
            categoryModel.CategoryId = product.Category.Id.Value;
            categoryModel.CategoryName = product.Category.Name.Value;
            model.Category = categoryModel;
        }
        return model;
    }

    public List<ProductViewModel> ConvertList(List<Product> products)
    {
        var list = new List<ProductViewModel>();
        foreach (var product in products)
        {
            list.Add(Convert(product));
        }
        return list;
    }

    public Product Restore(ProductViewModel model)
    {
        var productName = new ProductName(model.ProductName!);
        var productPrice = new ProductPrice(model.ProductPrice!.Value);

        Product? product;
        if (model.ProductId != null)
        {
            var productId = new ProductId(model.ProductId);
            product = new Product(productId, productName, productPrice, null);
        }
        else
        {
            product = new Product(productName, productPrice, null);
        }

        if (model.Category != null)
        {
            var category = new Category(
                new CategoryId(model.Category.CategoryId!),
                new CategoryName(model.Category.CategoryName!));
            product.ChangeCategory(category);
        }

        return product;
    }

    public List<Product> RestoreList(List<ProductViewModel> models)
    {
        var list = new List<Product>();
        foreach (var model in models)
        {
            list.Add(Restore(model));
        }
        return list;
    }
}
