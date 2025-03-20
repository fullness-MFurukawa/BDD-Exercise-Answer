namespace Exercise.Domains.Models.Products;
/// <summary>
/// 演習-04 IProductAdapterインターフェイスと実装を作成する
/// Productエンティティから他のモデルへの変換する
/// 他のモデルからProductエンティティを復元する
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public interface IProductAdapter<T>
{
    /// <summary>
    /// Productエンティティを他のモデルに変換する
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    T Convert(Product product);

    /// <summary>
    /// 他のモデルからProductエンティティを復元する
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Product Restore(T model);

    /// <summary>
    /// Productエンティティのリストを他のモデルのリストに変換する
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    List<T> ConvertList(List<Product> products);

    /// <summary>
    /// 他のモデルのリストからProductエンティティのリストを復元する
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    List<Product> RestoreList(List<T> models);
}
