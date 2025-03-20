using BDD_Fronts.Models.Products;
using Exercise.Applications.Services;
using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Products;
/// <summary>
/// 演習-16 商品検索機能のシナリオ、テストドライバ、コントローラを作成する
/// 商品検索コントローラ
/// </summary>
[Route("exercise/product/search")]
public class SearchController : Controller
{
    // 商品検索サービス
    private readonly IProductSearchService _searchService;
    // ProductとProductViewModelの相互変換
    private readonly IProductAdapter<ProductViewModel> _productAdapter;
    // ロガー
    private readonly ILogger<SearchController> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="searchService">商品検索サービス</param>
    /// <param name="productAdapter">ProductとProductViewModelの相互変換</param>
    /// <param name="logger">ロガー</param>
    public SearchController(
        IProductSearchService searchService, 
        IProductAdapter<ProductViewModel> productAdapter, 
        ILogger<SearchController> logger)
    {
        _searchService = searchService;
        _productAdapter = productAdapter;
        _logger = logger;
    }

    /// <summary>
    /// 検索画面表示リクエストへの応答
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
        return View(new SearchViewModel());
    }

    /// <summary>
    ///  [検索]ボタンクリックによるリクエストへの応答
    /// </summary>
    /// <param name="keyword">検索キーワード</param>
    /// <returns></returns>
    [HttpPost]
    [Route("SerarchButtonClick")]
    public IActionResult SerarchButtonClick(SearchViewModel model, string action)
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
                var productName = new ProductName(model.Keyword);
                var results = _searchService.Execute(productName);
                model.Products = _productAdapter.ConvertList(results);
                return View("Index", model);  // 検索結果をIndexビューに渡す
            }
            catch (NotFoundException e)
            {
                // エラーメッセージをModelStateに格納する
                ModelState.AddModelError("", e.Message);
                _logger.LogError(e.Message);
                return View("Index", model);
            }
        }
        else
        {
            return View("Index", model);
        }
    }
}
