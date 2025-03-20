using Exercise.Domains.Exceptions;
namespace Exercise.Domains.Models.Categories;
/// <summary>
/// 商品カテゴリを表すエンティティクラス
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public class Category : IEquatable<Category>
{
    // Categoryエンティティを構成する属性
    public CategoryId Id { get; private set; }
    public CategoryName Name { get; private set; }

    // <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">カテゴリID</param>
    /// <param name="name">カテゴリ名</param>
    public Category(CategoryId id, CategoryName name)
    {
        Id = id ?? throw new ValidateException("CategoryIdは必須です。");
        Name = name ?? throw new ValidateException("CategoryNameは必須です。");
    }
    /// <summary>
    /// コンストラクタ
    /// カテゴリIDを新規に生成する
    /// </summary>
    /// <param name="name">カテゴリ名</param>
    public Category(CategoryName name)
    : this(new CategoryId(Guid.NewGuid().ToString().Replace("-", "")), name)
    {
    }

    /// <summary>
    /// カテゴリ名の変更(可変性)
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName(CategoryName name)
    {
        if (name == null)
        {
            throw new ValidateException("CategoryNameは必須です。");
        }
        Name = name;
    }

    /// <summary>
    /// エンティティの等価性
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Category? other)
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
        if (obj is Category other)
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
    public override string ToString()
    {
        return $"Category[Id:{Id}, Name:{Name}]";
    }
}
