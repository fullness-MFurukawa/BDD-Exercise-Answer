using BDD_Fronts.Extensions;
using BDD_Fronts.Models.Categories;
using BDD_Fronts.Models.Products;
using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Products;
/// <summary>
/// 商品登録コントローラ
/// 提供
/// </summary>
[Route("exercise/product/register")]
public class RegisterController : Controller
{
    private readonly IProductRegisterService _productRegisterService;
    private readonly ICategoryAdapter<CategoryViewModel> _categoryAdapter;
    private readonly IProductAdapter<RegisterViewModel> _productAdapter;
    private readonly ILogger<RegisterController> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productRegisterService">商品登録サービス</param>
    /// <param name="categoryAdapter">CategoryとCategoryViewModelの相互変換</param>
    /// <param name="productAdapter">ProductとRegisterViewModelの相互変換</param>
    /// <param name="logger">ロガー</param>
    public RegisterController(
        IProductRegisterService productRegisterService,
        ICategoryAdapter<CategoryViewModel> categoryAdapter,
        IProductAdapter<RegisterViewModel> productAdapter,
        ILogger<RegisterController> logger)
    {
        _productRegisterService = productRegisterService;
        _categoryAdapter = categoryAdapter;
        _productAdapter = productAdapter;
        _logger = logger;
    }

    /// <summary>
    /// 入力画面表示ハンドラ
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        // 商品登録ビューモデルを生成する
        var model = new RegisterViewModel();
        // 登録サービスからカテゴリリストを取得する
        var categories = _productRegisterService.GetCategories();
        // ビューモデルのCategriesにカテゴリビューモデルに変換したリストを格納する
        model.Categories = _categoryAdapter.ConvertList(categories);
        // セッションのカテゴリビューモデルのリストを格納する
        HttpContext.Session.SetObject("Categories", model.Categories);
        return View(model);
    }
    /// <summary>
    /// 入力画面のボタンクリックハンドラ
    /// </summary>
    /// <param name="model">入力データ</param>
    /// <param name="action">選択アクション</param>
    /// <returns></returns>
    [HttpPost]
    [Route("EnterButtonClick")]
    public IActionResult EnterButtonClick(RegisterViewModel model, string action)
    {
        if (action.Equals("End")) // [終了]ボタンクリック?
        {
            // メニュー(トップ)にリダイレクトする
            return RedirectToAction("menu", "exercise");
        }
        if (ModelState.IsValid) // バリデーションエラー無し
        {

            try
            {
                // 既に商品が登録済みかを確認する
                _productRegisterService.Exists(new ProductName(model.ProductName!));
            }
            catch (ExistsException e) // 登録済み例外
            {
                // エラーメッセージをModelStateに格納する
                ModelState.AddModelError("", e.Message);
                _logger.LogError(e.Message);
                // セッションからカテゴリビューモデルのリストを取得する
                model.Categories = HttpContext.Session.GetObject<List<CategoryViewModel>>("Categories");
                // 入力画面に遷移する
                return View("Enter", model);
            }

            // カテゴリIdを取得する
            var id = new CategoryId(model.CategoryId!);
            // カテゴリIdでカテゴリ情報を取得する
            var category = _productRegisterService.GetCategory(id);
            model.CategoryName = category.Name.Value;
            // TempDataにModelを格納する
            TempData.SetObject("registerViewModel", model);
            // CompleteActionにリダイレクトする(PRGパターン)
            return RedirectToAction("CompleteAction");
        }
        else // バリデーションエラー
        {
            // セッションからカテゴリビューモデルのリストを取得する
            model.Categories = HttpContext.Session.GetObject<List<CategoryViewModel>>("Categories");
            // 入力画面に遷移する
            return View("Enter", model);
        }
    }
    /// <summary>
    /// 商品登録完了
    /// </summary>
    /// <returns></returns>
    [HttpGet("CompleteAction")]
    public IActionResult CompleteAction()
    {
        // TempDataから商品登録ビューモデルを取得する
        var model = TempData.GetObject<RegisterViewModel>("registerViewModel");
        // 商品登録用のドメインオブジェクトを作成する
        var product = _productAdapter.Restore(model!);
        // 商品を永続化する
        _productRegisterService.Register(product);
        // 登録完了画面に遷移する
        return View("Complete", model);
    }
    /// <summary>
    /// [終了]ボタンクリックハンドラ
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("EndButtonClick")]
    public IActionResult EndButtonClick(string action)
    {
        if (action.Equals("End"))
        {
            return RedirectToAction("menu", "exercise");
        }
        return RedirectToAction("Enter");
    }
}
