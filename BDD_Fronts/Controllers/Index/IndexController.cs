using BDD_Fronts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BDD_Fronts.Controllers.Index;
/// <summary>
/// デフォルトリクエストへ応答するコントローラ
/// 提供
/// </summary>
public class IndexController : Controller
{
    private readonly ILogger<IndexController> _logger;
    public IndexController(ILogger<IndexController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        // コントローラー名とアクション名を指定してリダイレクト
        return RedirectToAction("menu", "exercise");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
