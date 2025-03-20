namespace CommonsHelpers.Dtos;
/// <summary>
/// カテゴリ情報変換用DTOクラス
/// 提供
/// </summary>
public class CategoryDTO
{
    public string? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public override string? ToString()
    {
        return $"CategoryDTO[Id={Id},Name={Name}]";
    }
}
