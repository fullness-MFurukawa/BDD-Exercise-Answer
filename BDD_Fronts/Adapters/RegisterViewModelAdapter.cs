using BDD_Fronts.Models.Products;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;

namespace BDD_Fronts.Adapters;
/// <summary>
/// ProductViewModelからProductを復元する
/// Adapterインターフェイスの実装
/// 提供
/// </summary>
public class RegisterViewModelAdapter : IProductAdapter<RegisterViewModel>
{
    public RegisterViewModel Convert(Product product)
    {
        throw new NotImplementedException();
    }
    public List<RegisterViewModel> ConvertList(List<Product> products)
    {
        throw new NotImplementedException();
    }
    public Product Restore(RegisterViewModel model)
    {
        // 商品登録用のドメインオブジェクトを作成する
        var category = new Category(
            new CategoryId(model!.CategoryId!),
            new CategoryName(model.CategoryName!));
        var product = new Product(
            new ProductName(model.ProductName!),
            new ProductPrice(model.ProductPrice.GetValueOrDefault()),
            null);
        product.ChangeCategory(category);
        return product;
    }
    public List<Product> RestoreList(List<RegisterViewModel> models)
    {
        throw new NotImplementedException();
    }
}
