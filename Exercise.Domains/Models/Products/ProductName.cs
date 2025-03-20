using Exercise.Domains.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domains.Models.Products;
/// <summary>
/// 商品名を表す値オブジェクトクラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</auth
public class ProductName : IEquatable<ProductName>
{
    public string? Value { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value"></param>
    public ProductName(string? value)
    {
        // ビジネスルールの検証
        ValidateProductName(value);
        Value = value;
    }

    /// <summary>
    /// ビジネスルールの検証
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static void ValidateProductName(string? value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ValidateException("ProductNameは必須です。");
        if (value.Length > 30)
            throw new ValidateException("ProductNameは30文字以内である必要があります。");
    }

    /// <summary>
    /// 等価性検証
    /// 型チェックを行い、不必要なボックス化や型変換を避ける
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ProductName? other)
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
        return obj is ProductName name && Value == name.Value;
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
        return $"ProductName[Value:{Value}]";
    }
}
