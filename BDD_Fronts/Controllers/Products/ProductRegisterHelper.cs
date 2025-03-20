using BDD_Fronts.Models.Categories;
using BDD_Fronts.Models.Products;
using Exercise.Applications.Services;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;

namespace BDD_Fronts.Controllers.Products;
/// <summary>
/// 商品登録コントローラ用ヘルパ
/// </summary>
public class ProductRegisterHelper
{
    private readonly IProductRegisterService _productRegisterService;
    private readonly ICategoryAdapter<CategoryViewModel> _categoryAdapter;
    private readonly IProductAdapter<RegisterViewModel> _productAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productRegisterService">商品登録サービス</param>
    /// <param name="categoryAdapter">CategoryとCategoryViewModelの相互変換</param>
    /// <param name="productAdapter">ProductとRegisterViewModelの相互変換</param>
    public ProductRegisterHelper(
        IProductRegisterService productRegisterService, 
        ICategoryAdapter<CategoryViewModel> categoryAdapter, 
        IProductAdapter<RegisterViewModel> productAdapter)
    {
        _productRegisterService = productRegisterService;
        _categoryAdapter = categoryAdapter;
        _productAdapter = productAdapter;
    }

    /// <summary>
    /// 商品登録ビューモデルを生成する
    /// </summary>
    /// <returns></returns>
    public RegisterViewModel CreateRegisterViewModel()
    {
        var model = new RegisterViewModel();
        var categories = _productRegisterService.GetCategories();
        model.Categories = _categoryAdapter.ConvertList(categories);
        return model;
    }

    /// <summary>
    /// 登録する商品の有無を調べる
    /// </summary>
    /// <param name="model"></param>
    public void Exists(RegisterViewModel model)
    {
        _productRegisterService.Exists(new ProductName(model.ProductName!));
    }

    /// <summary>
    /// カテゴリ名を取得する
    /// </summary>
    /// <param name="model">RegisterViewModel</param>
    public void GetCategoryById(RegisterViewModel model)
    {
        var category = _productRegisterService.GetCategory(new CategoryId(model.CategoryId));
        model.CategoryName = category.Name.Value;
    }

    /// <summary>
    /// 商品を登録する
    /// </summary>
    /// <param name="model">RegisterViewModel</param>
    public void Register(RegisterViewModel model)
    {
        // 商品登録用のドメインオブジェクトを復元する
        var product = _productAdapter.Restore(model);
        // 商品を永続化する
        _productRegisterService.Register(product);
    }
}
