using Microsoft.AspNetCore.Mvc;
namespace BDD_Fronts.Controllers.Menu;
/// <summary>
/// メニューコントローラ
/// 提供
/// </summary>
[Route("exercise/menu")]
public class MenuController : Controller
{
    /// <summary>
    /// メニュー画面を送信する
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("Menu");
    }
}
