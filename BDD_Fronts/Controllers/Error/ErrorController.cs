using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Error;
/// <summary>
/// エラーページ遷移コントローラ
/// 提供
/// </summary>
[Route("exercise/error")]
public class ErrorController : Controller
{
    /// <summary>
    /// エラー画面を送信
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}
