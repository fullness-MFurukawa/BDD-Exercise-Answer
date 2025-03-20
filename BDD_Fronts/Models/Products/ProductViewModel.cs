using BDD_Fronts.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace BDD_Fronts.Models.Products;
/// <summary>
/// 商品ビューモデル
/// 提供
/// </summary>
public class ProductViewModel
{
    // 商品Id
    public string? ProductId { get; set; }
    // 商品名
    [Required(ErrorMessage = "商品名を入力してください")]
    public string? ProductName { get; set; }
    // 単価
    [Required(ErrorMessage = "単価を入力してください")]
    public int? ProductPrice { get; set; }
    // カテゴリ
    public CategoryViewModel? Category { get; set; }
}
