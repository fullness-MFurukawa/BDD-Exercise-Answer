using Exercise.Domains.Exceptions;
namespace Exercise.Domains.Models.Categories;
/// <summary>
/// 商品カテゴリIdを表す値オブジェクトクラス
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public class CategoryId : IEquatable<CategoryId>
{
    public string? Value { get; private set; }

    public CategoryId(string? value)
    {
        // ビジネスルールの検証(自己検証)
        ValidateCategoryId(value);
        Value = value;
    }

    /// <summary>
    /// ビジネスルールの検証
    /// </summary>
    /// <param name="value"></param>
    private static void ValidateCategoryId(string? value)
    {
        // Nullチェック
        if (string.IsNullOrEmpty(value))
            throw new ValidateException("CategoryIdは必須です。");
        // 長さチェック
        if (value.Length != 32)
            throw new ValidateException("CategoryIdは32文字である必要があります。");
        // UUID形式チェック
        if (!Guid.TryParse(value, out _))
            throw new ValidateException("CategoryIdは有効なUUID形式である必要があります。");
    }

    /// <summary>
    /// 等価性検証
    /// 型チェックを行い、不必要なボックス化や型変換を避ける
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(CategoryId? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Value, other.Value);
    }

    /// <summary>
    /// 任意のオブジェクトとの等価性をチェックする
    /// 型が不明な状況での比較や、異なる型のオブジェクトとの比較に使用する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is CategoryId id &&
               Value == id.Value;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    /// <summary>
    /// インスタンス出力
    /// </summary>
    /// <returns></returns>
    public override string? ToString()
    {
        return $"CategoryId[Value:{Value}]";
    }
}
