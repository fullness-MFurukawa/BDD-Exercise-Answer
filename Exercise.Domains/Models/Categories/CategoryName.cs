using Exercise.Domains.Exceptions;
namespace Exercise.Domains.Models.Categories;
/// <summary>
/// 商品カテゴリ名を表す値オブジェクトクラス
/// 提供
/// </summary
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public class CategoryName : IEquatable<CategoryName>
{
    public string? Value { get; private set; }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value"></param>
    public CategoryName(string? value)
    {
        // バリデーション(自己検証)
        ValidateCategoryName(value);
        Value = value;
    }

    /// <summary>
    /// バリデーション
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static void ValidateCategoryName(string? value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ValidateException("CategoryNameは必須です。");
        if (value.Length > 30)
            throw new ValidateException("CategoryNameは30文字以内である必要があります。");
    }

    /// <summary>
    /// 等価性検証
    /// 型チェックを行い、不必要なボックス化や型変換を避ける
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(CategoryName? other)
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
        return obj is CategoryName name && Value == name.Value;
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
        return $"CategoryName[Value:{Value}]";
    }
}
