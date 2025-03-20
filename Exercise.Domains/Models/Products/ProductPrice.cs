using Exercise.Domains.Exceptions;
namespace Exercise.Domains.Models.Products;
/// <summary>
/// 商品単価を表す値オブジェクトクラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public class ProductPrice : IEquatable<ProductPrice>
{
    public int Value { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value"></param>
    public ProductPrice(int value)
    {
        // ビジネスルールの検証
        ValidateProductPrice(value);
        Value = value;
    }

    /// <summary>
    /// ビジネスルールの検証
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static void ValidateProductPrice(int value)
    {
        if (value <= 50 || value >= 10000)
            throw new ValidateException("ProductPriceは50以上10000以下である必要があります。");
    }

    /// <summary>
    /// 等価性検証
    /// 型チェックを行い、不必要なボックス化や型変換を避ける
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ProductPrice? other)
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
        return obj is ProductPrice name && Value == name.Value;
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
        return $"ProductPrice[Value:{Value}]";
    }
}
