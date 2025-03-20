using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Microsoft.EntityFrameworkCore;
namespace Exercise.Infrastructures.EntityFrameworkCore;
/// <summary>
/// EntityFrameworkCore アプリケーション用DbContextクラス
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/10</date>
/// <author>Fullness,Inc.</author>
public class AppDbContext : DbContext
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// DbSet<T>プロパティ
    /// </summary>
    public DbSet<CategoryDBModel>? Categories { get; set; }
    public DbSet<ProductDBModel>? Products { get; set; }

    /// <summary>
    /// Modelの結合定義
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDBModel>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey("CategoryId");
    }
}
