using BDD_Fronts.Extensions;
using BDD_Fronts.Models.Categories;
using BDD_Fronts.Models.Products;
using Exercise.Domains.Exceptions;
using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Products;
/// <summary>
/// 商品登録コントローラ
/// 提供
/// </summary>
[Route("exercise/product/register")]
public class RegisterController : Controller
{
    private readonly ProductRegisterHelper _helper;
    private readonly ILogger<RegisterController> _logger;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="helper">商品登録コントローラ用ヘルパ</param>
    /// <param name="logger">ロガー</param>
    public RegisterController(
        ProductRegisterHelper helper, 
        ILogger<RegisterController> logger)
    {
        _helper = helper;
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
        var model = this._helper.CreateRegisterViewModel();
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
                this._helper.Exists(model);
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
            // カテゴリIdで商品カテゴリを取得してRegisterViewModelに格納する
            _helper.GetCategoryById(model);
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
        // 商品を登録する 
        _helper.Register(model!);
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
