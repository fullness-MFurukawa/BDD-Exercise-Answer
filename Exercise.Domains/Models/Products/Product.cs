using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domains.Models.Products;
/// <summary>
/// 商品を表すエンティティクラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/05/26</date>
/// <author>Fullness,Inc</author>
public class Product : IEquatable<Product>
{
    public ProductId Id { get; private set; }
    public ProductName Name { get; private set; }
    public ProductPrice Price { get; private set; }
    public Category? Category { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">商品ID</param>
    /// <param name="name">商品名</param>
    /// <param name="price">商品単価</param>
    /// <param name="category">カテゴリ</param>
    public Product(ProductId id, ProductName name, ProductPrice price, Category? category)
    {
        Id = id ?? throw new ValidateException("ProductIdは必須です。");
        Name = name ?? throw new ValidateException("ProductNameは必須です。");
        Price = price ?? throw new ValidateException("ProductPriceは必須です。");
        Category = category;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">商品名</param>
    /// <param name="price">商品単価</param>
    /// <param name="category">カテゴリ</param>
    public Product(ProductName name, ProductPrice price, Category? category)
    : this(new ProductId(Guid.NewGuid().ToString().Replace("-", "")), name, price, category)
    {
    }

    /// <summary>
    /// 商品名を変更する(可変性)
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName(ProductName name)
    {
        if (name == null)
        {
            throw new ValidateException("ProductNameは必須です。");
        }
        Name = name;
    }
    /// <summary>
    /// 商品単価を変更する(可変性)
    /// </summary>
    /// <param name="price"></param>
    public void ChangePrice(ProductPrice price)
    {
        if (price == null)
        {
            throw new ValidateException("ProductPriceは必須です。");
        }
        Price = price;
    }
    /// <summary>
    /// カテゴリを変更する(可変性)
    /// </summary>
    /// <param name="category"></param>
    public void ChangeCategory(Category? category)
    {
        Category = category;
    }

    /// <summary>
    /// エンティティの等価性
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Product? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    /// <summary>
    /// エンティティの等価性
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is Product other)
        {
            return Id.Equals(other.Id);
        }
        return false;
    }
    /// <summary>
    /// ハッシュコードを取得する
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// インスタンス出力
    /// </summary>
    /// <returns></returns>
    public override string? ToString()
    {
        if (Category != null)
        {
            return $"Product[Id:{Id},Name:{Name},Price:{Price},Category:{Category}]";
        }
        else
        {
            return $"Product[Id:{Id},Name:{Name},Price:{Price},Category:null]";
        }
    }
}
