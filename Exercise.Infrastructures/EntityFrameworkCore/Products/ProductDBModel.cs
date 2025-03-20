using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Exercise.Infrastructures.EntityFrameworkCore.Products;
/// <summary>
/// productテーブルデータを扱うモデル
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/10</date>
/// <author>Fullness,Inc.</author>
[Table("product")]
public class ProductDBModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("product_id")]
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    [Column("category_fk_id")]
    public int CategoryId { get; set; }
    /// <summary>
    /// 結合で取得したカテゴリ格納プロパティ
    /// </summary>
    public CategoryDBModel? Category { get; set; }

    public override string? ToString()
    {
        return $"ProductEntity[Id:{Id},ProductId:{ProductId},Name:{Name},Price:{Price},CategoryId:{CategoryId}]";
    }
}
