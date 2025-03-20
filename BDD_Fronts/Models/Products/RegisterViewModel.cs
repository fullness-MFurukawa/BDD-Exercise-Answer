using BDD_Fronts.Models.Categories;
using System.ComponentModel.DataAnnotations;
namespace BDD_Fronts.Models.Products;
/// <summary>
/// 商品登録ビューモデル
/// 提供
/// </summary>
public class RegisterViewModel
{
    // 商品名
    [Required(ErrorMessage = "商品名を入力してください")]
    public string? ProductName { get; set; }
    // 単価
    [Required(ErrorMessage = "単価を入力してください")]
    public int? ProductPrice { get; set; }
    // カテゴリId
    [Required(ErrorMessage = "カテゴリを選択してください")]
    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }
}
