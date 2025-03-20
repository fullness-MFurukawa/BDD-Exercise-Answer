using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Microsoft.EntityFrameworkCore;
namespace Exercise.Infrastructures.EntityFrameworkCore.Products;
/// <summary>
/// 永続化層から商品をCRUD操作するRepositoryインターフェイスの実装
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/11</date>
/// <author>Fullness,Inc</author>
public class ProductRepository : IProductRepository
{
    // EFCore DbContext
    private readonly AppDbContext _appDbContext;
    // 商品相互変換アダプタ
    private readonly IProductAdapter<ProductDBModel> _productAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext"> EFCore DbContext</param>
    /// <param name="productAdapter">商品相互変換アダプタ</param>
    public ProductRepository(
        AppDbContext appDbContext,
        IProductAdapter<ProductDBModel> productAdapter)
    {
        _appDbContext = appDbContext;
        _productAdapter = productAdapter;
    }



    /// <summary>
    /// 指定された商品の存在有無を返す
    /// </summary>
    /// <param name="name">商品名</param>
    /// <returns>true:存在する/false:存在しない</returns>
    public bool Exists(ProductName name)
    {
        try
        {
            return _appDbContext.Products!.Any(p => p.Name == name.Value);
        }
        catch (Exception e)
        {
            throw new InternalException("商品の存在チェックに失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品Idで検索する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>取得結果</returns>
    public Product FindById(ProductId id)
    {
        try
        {
            var product = _appDbContext.Products!
              .SingleOrDefault(p => p.ProductId == id.Value);
            if (product == null)// 該当データが存在しない場合nullを返す
            {
                return null!;
            }
            return _productAdapter.Restore(product!);
        }
        catch (Exception e)
        {
            throw new InternalException("商品Idでの取得に失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品名で部分一致検索する
    /// </summary>
    /// <param name="partialName">キーワード</param>
    /// <returns>取得結果</returns>
    public List<Product> FindByNameContains(ProductName partialName)
    {
        try
        {
            var products = _appDbContext.Products!
                     .Include(p => p.Category)  // カテゴリも一緒に取得する
                     .Where(p => EF.Functions.Like(p.Name, $"%{partialName.Value}%"))
                     .AsNoTracking()
                     // 必要なフィールドのみを選択し、CategoryEntity の Products プロパティを除外する
                     .Select(p => new ProductDBModel
                     {
                         Id = p.Id,
                         ProductId = p.ProductId,
                         Name = p.Name,
                         Price = p.Price,
                         CategoryId = p.CategoryId,
                         Category = new CategoryDBModel
                         {
                             Id = p.Category!.Id,
                             CategoryId = p.Category.CategoryId,
                             Name = p.Category.Name,
                             // Products プロパティは設定しないことで無視する
                         }
                     })
                     .ToList();
            // 該当データが存在しない、または件数が0の場合nullを返す
            if (products == null || products.Count == 0)
            {
                return null!;
            }
            return _productAdapter.RestoreList(products);
        }
        catch (Exception e)
        {
            throw new InternalException("キーワードでの取得に失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品を永続化する
    /// </summary>
    /// <param name="product">商品</param>
    /// <returns>永続化結果</returns>
    public Product Create(Product product)
    {
        var entity = _productAdapter.Convert(product);
        try
        {
            // カテゴリの主キーを取得する
            var category = _appDbContext.Categories!
                .FirstOrDefault(c => c.CategoryId == product.Category!.Id.Value);
            entity.CategoryId = category!.Id;// カテゴリの主キーを設定する
            entity.Category = null;// Categoryプロパティはnullにする
            _appDbContext.Products!.Add(entity!);
            _appDbContext.SaveChanges();
            return product;
        }
        catch (Exception e)
        {
            throw new InternalException("商品の登録に失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品を置き換える
    /// </summary>
    /// <param name="product">商品</param>
    /// <returns>変更結果</returns>
    public Product UpdateById(Product product)
    {
        try
        {
            var entity = _appDbContext.Products!
            .FirstOrDefault(p => p.ProductId == product.Id.Value);
            if (entity == null)// 該当データが存在しない場合nullを返す
            {
                return null!;
            }
            entity.Name = product.Name.Value!;
            entity.Price = product.Price.Value;
            _appDbContext.SaveChanges();
            return product;
        }
        catch (Exception e)
        {
            throw new InternalException("商品の変更に失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品Idで削除する
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <returns>削除結果</returns>
    public Product DeleteById(ProductId id)
    {
        try
        {
            var product = _appDbContext.Products!
                .SingleOrDefault(p => p.ProductId == id.Value);
            if (product == null)// 該当データが存在しない場合nullを返す
            {
                return null!;
            }
            _appDbContext.Products!.Remove(product);
            _appDbContext.SaveChanges();
            return _productAdapter.Restore(product);
        }
        catch (Exception e)
        {
            throw new InternalException("商品の削除に失敗しました。", e);
        }
    }
}
