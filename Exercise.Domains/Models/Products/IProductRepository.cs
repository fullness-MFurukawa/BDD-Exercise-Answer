namespace Exercise.Domains.Models.Products;
/// <summary>
/// 永続化層から商品をCRUD操作するリポジトリ
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/08</date>
/// <author>Fullness,Inc</author>
public interface IProductRepository
{
    /// <summary>
    /// 商品Idで検索する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>取得結果</returns>
    Product FindById(ProductId id);
    /// <summary>
    /// 商品名で部分一致検索する
    /// </summary>
    /// <param name="partialName">キーワード</param>
    /// <returns>取得結果</returns>
    List<Product> FindByNameContains(ProductName partialName);
    /// <summary>
    /// 指定された商品の存在有無を返す
    /// </summary>
    /// <param name="name">商品名</param>
    /// <returns>true:存在する/false:存在しない</returns>
    bool Exists(ProductName name);
    /// <summary>
    /// 商品を永続化する
    /// </summary>
    /// <param name="product">商品</param>
    /// <returns>永続化結果</returns>
    Product Create(Product product);
    /// <summary>
    /// 商品を置き換える
    /// </summary>
    /// <param name="product">商品</param>
    /// <returns>変更結果</returns>
    Product UpdateById(Product product);
    /// <summary>
    /// 商品Idで削除する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>削除結果</returns>
    Product DeleteById(ProductId id);
}
