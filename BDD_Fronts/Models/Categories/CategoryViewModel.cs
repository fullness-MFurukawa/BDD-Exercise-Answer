using System.ComponentModel.DataAnnotations;

namespace BDD_Fronts.Models.Categories;
/// <summary>
/// カテゴリビューモデル
/// 提供
/// </summary>
public class CategoryViewModel
{
    // カテゴリId
    [Required(ErrorMessage = "カテゴリを選択してください")]
    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
