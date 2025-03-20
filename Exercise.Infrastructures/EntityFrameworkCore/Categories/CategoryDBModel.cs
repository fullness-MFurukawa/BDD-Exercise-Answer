using Exercise.Infrastructures.EntityFrameworkCore.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise.Infrastructures.EntityFrameworkCore.Categories;
/// <summary>
/// product_categoryテーブルデータを扱うモデル
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/10</date>
/// <author>Fullness,Inc.</author>
[Table("product_category")]
public class CategoryDBModel
{
    // レコード識別Id
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // カテゴリId
    [Column("category_id")]
    public string CategoryId { get; set; } = string.Empty;
    // カテゴリ名
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// 結合で取得した商品格納プロパティ
    /// </summary>
    public List<ProductDBModel>? Products { get; set; }

    public override string ToString()
    {
        return $"CategoryDBModel[Id:{Id},CategoryId:{CategoryId},Name:{Name}]";
    }
}
