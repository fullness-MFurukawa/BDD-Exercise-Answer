using Exercise.Domains.Exceptions;
namespace Exercise.Domains.Models.Products;
/// <summary>
/// 商品Idを表す値オブジェクトクラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author
public class ProductId : IEquatable<ProductId>
{
    public string? Value { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value"></param>
    public ProductId(string? value)
    {
        // ビジネスルールの検証
        ValidateProductId(value);
        Value = value;
    }

    /// <summary>
    /// ビジネスルールの検証
    /// </summary>
    /// <param name="value"></param>
    private static void ValidateProductId(string? value)
    {
        // Nullチェック
        if (string.IsNullOrEmpty(value))
            throw new ValidateException("ProductIdは必須です。");
        // 長さチェック
        if (value.Length != 32)
            throw new ValidateException("ProductIdは32文字である必要があります。");
        // UUID形式チェック
        if (!Guid.TryParse(value, out _))
            throw new ValidateException("ProductIdは有効なUUID形式である必要があります。");
    }

    /// <summary>
    /// 等価性検証
    /// 型チェックを行い、不必要なボックス化や型変換を避ける
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ProductId? other)
    {
        if (other == null) return false;
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
        return obj is ProductId name && Value == name.Value;
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
        return $"ProductId[Value:{Value}]";
    }
}
