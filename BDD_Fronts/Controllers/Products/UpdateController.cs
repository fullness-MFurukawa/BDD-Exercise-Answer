using BDD_Fronts.Models.Products;
using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Products;
/// <summary>
/// 演習-17 商品変更機能のシナリオ、テストドライバ、コントローラを作成する
/// 商品変更コントローラ
/// </summary>
[Route("exercise/product/update")]
public class UpdateController : Controller
{
    // 商品変更サービス
    private readonly IProductUpdateService _productUpdateService;
    // ProductとProductViewModelの相互変換
    private readonly IProductAdapter<ProductViewModel> _productAdapter;
    // ロガー
    private readonly ILogger<UpdateController> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productUpdateService">商品変更サービス</param>
    /// <param name="productAdapter">ProductとProductViewModelの相互変換</param>
    /// <param name="logger">ロガー</param>
    public UpdateController(
        IProductUpdateService productUpdateService, 
        IProductAdapter<ProductViewModel> productAdapter, 
        ILogger<UpdateController> logger)
    {
        _productUpdateService = productUpdateService;
        _productAdapter = productAdapter;
        _logger = logger;
    }

    /// <summary>
    /// 変更画面表示ハンドラ
    /// </summary>
    /// <param name="id">検索画面で選択された商品のId</param>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter(string id)
    {
        var productId = new ProductId(id);
        var product = _productUpdateService.GetProduct(productId);
        var viewModel = _productAdapter.Convert(product);
        return View(viewModel);
    }

    [HttpPost]
    [Route("EnterButtonClick")]
    public IActionResult EnterButtonClick(ProductViewModel model, string action)
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
                // ProductViewModelからProductを復元する
                var product = _productAdapter.Restore(model);
                // 商品情報(商品名、単価)を変更する
                _productUpdateService.Execute(product);
                // 登録完了画面に遷移する
                return View("Complete", model);
            }
            catch (NotFoundException e)
            {
                // エラーメッセージをModelStateに格納する
                ModelState.AddModelError("", e.Message);
                _logger.LogError(e.Message);
                // 入力画面に遷移する
                return View("Enter", model);
            }
        }
        else
        {
            // 入力画面に遷移する
            return View("Enter", model);
        }
    }

    /// <summary>
    /// [終了]、[検索]ボタンクリックハンドラ
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
        return RedirectToAction("Index", "search");
    }
}
