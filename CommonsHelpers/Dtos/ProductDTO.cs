namespace CommonsHelpers.Dtos;
/// <summary>
/// 商品情報変換用DTOクラス
/// 提供
/// </summary>
public class ProductDTO
{
    public string? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public string? Price { get; set; } = null;
    public string? CategoryId { get; set; } = null;
    public string? CategoryName { get; set; } = null;
}
