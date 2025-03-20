using System.ComponentModel.DataAnnotations;
namespace BDD_Fronts.Models.Products;
/// <summary>
/// 商品検索ビューモデル
/// 提供
/// </summary>
public class SearchViewModel
{
    /// <summary>
    /// 入力キーワード
    /// </summary>
    [Required(ErrorMessage = "キーワードを入力してください。")]
    public string? Keyword { get; set; }
    /// <summary>
    /// 検索結果d
    /// </summary>
    public List<ProductViewModel>? Products { get; set; }
}
