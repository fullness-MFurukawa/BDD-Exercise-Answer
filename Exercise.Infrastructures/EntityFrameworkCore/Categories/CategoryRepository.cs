using Exercise.Domains.Exceptions;
using Exercise.Domains.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Infrastructures.EntityFrameworkCore.Categories;
/// <summary>
/// 永続化層から商品カテゴリをCRUD操作するRepositoryインターフェイスの実装
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/11</date>
/// <author>Fullness,Inc</author>
public class CategoryRepository : ICategoryRepository
{
    // EFCore DbContext
    private readonly AppDbContext _appDbContext;
    // 商品カテゴリ相互変換アダプタ
    private readonly ICategoryAdapter<CategoryDBModel> _categoryAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">EFCore DbContext</param>
    /// <param name="categoryAdapter">商品カテゴリ相互変換アダプタ</param>
    public CategoryRepository(
        AppDbContext appDbContext,
        ICategoryAdapter<CategoryDBModel> categoryAdapter)
    {
        _appDbContext = appDbContext;
        _categoryAdapter = categoryAdapter;
    }
    /// <summary>
    /// すべての商品カテゴリを取得する
    /// </summary>
    /// <returns>Categoryのリスト</returns>
    public List<Category> FindAll()
    {
        try
        {
            // CategoryDBModelで結果が返される
            var results = _appDbContext.Categories!.AsNoTracking().ToList();
            // CategoryDBModelからCategoryエンティティに変換して呼び出し側へ返す
            return _categoryAdapter.RestoreList(results);
        }
        catch (Exception e)
        {
            throw new InternalException("すべての商品カテゴリ取得に失敗しました。", e);
        }
    }
    /// <summary>
    /// 商品カテゴリIdで取得する
    /// </summary>
    /// <param name="id">商品カテゴリId</param>
    /// <returns>Category</returns>
    public Category FindById(CategoryId id)
    {
        try
        {
            var result = _appDbContext.Categories!.
            Where(c => c.CategoryId == id.Value).FirstOrDefault();
            if (result == null)// 該当データが存在しない場合nullを返す
            {
                return null!;
            }
            return _categoryAdapter.Restore(result);
        }
        catch (Exception e)
        {
            throw new InternalException("商品カテゴリ取得に失敗しました。", e);
        }
    }
}
