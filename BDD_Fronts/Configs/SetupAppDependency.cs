using BDD_Fronts.Adapters;
using BDD_Fronts.Controllers.Products;
using BDD_Fronts.Models.Categories;
using BDD_Fronts.Models.Products;
using Exercise.Applications.Impls;
using Exercise.Applications.Services;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Microsoft.EntityFrameworkCore;
namespace BDD_Fronts.Configs;
/// <summary>
/// アプリケーションの依存関係セッティングクラス
/// 提供
/// </summary>
/// <version>1.0</version>
/// <date>2024/10/10</date>
/// <author>Fullness,Inc.</author>
public static class SetupAppDependency
{
    /// <summary>
    /// アプリケーション全体の依存関係を構築する
    /// </summary>
    /// <param name="configuration">アプリケーション環境情報</param>
    /// <param name="services">DIコンテナ</param>
    public static void SettingDependencyInjection(
        IConfiguration configuration, IServiceCollection services)
    {
        // EntityFramework Coreのインスタンス生成と依存定義
        SettingEntityFrameworkCore(configuration, services);
        // インフラストラクチャ層のインスタンス生成と依存定義
        SettingInfrastructures(services);
        // アプリケーション層のインスタンス生成と依存定義
        SettingApplications(services);
        // プレゼンテーション層のインスタンス⽣成と依存定義
        SetupPresentations(services);
    }

    /// <summary>
    /// EntityFramework Coreのインスタンス生成と依存定義
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="services"></param>
    private static void SettingEntityFrameworkCore(
        IConfiguration configuration, IServiceCollection services)
    {
        // appsetting.jsonから接続文字列を取得
        var connectionString = configuration.GetConnectionString("ExerciseDB");
        // EntityFrameworkのインスタンス化とServiceCollectionへの登録
        services.AddDbContext<AppDbContext>(options =>
        {
            // デバッグレベルのログをコンソール出力する
            options.LogTo(Console.WriteLine, LogLevel.Debug);
            // SQLServerに接続する
            options.UseSqlServer(connectionString);
        });
    }
    /// <summary>
    /// インフラストラクチャ層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services"></param>
    private static void SettingInfrastructures(IServiceCollection services)
    {
        // CategoryとCategoryDBModelを相互変換するAdapter
        services.AddScoped<ICategoryAdapter<CategoryDBModel>, CategoryDBModelAdapter>();
        // 演習-05で追加 ProductとProductDBModelを相互変換するAdapter
        services.AddScoped<IProductAdapter<ProductDBModel>, ProductDBModelAdapter>();

        // 永続化層から商品カテゴリをCRUD操作するRepository
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        // 演習-07で追加 永続化層から商品をCRUD操作するRepository
        services.AddScoped<IProductRepository, ProductRepository>();
    }
    /// <summary>
    /// アプリケーション層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services"></param>
    private static void SettingApplications(IServiceCollection services)
    {
        // 演習-09 IProductSearchServiceインターフェイスとその実装を用意する
        services.AddScoped<IProductSearchService, ProductSearchService>();
        // 演習-11 IProductRegisterServiceインターフェイスとその実装を用意する
        services.AddScoped<IProductRegisterService, ProductRegisterService>();
        // 演習-13 IProductUpdateServiceインターフェイスとその実装を用意する
        services.AddScoped<IProductUpdateService, ProductUpdateService>();
    }
    /// <summary>
    /// プレゼンテーション層のインスタンス⽣成と依存定義
    /// </summary>
    /// <param name="services"></param>
    private static void SetupPresentations(IServiceCollection services)
    {
        services.AddScoped<ICategoryAdapter<CategoryViewModel>, CategoryViewModelAdapter>();
        services.AddScoped<IProductAdapter<ProductViewModel>, ProductViewModelAdapter>();
        services.AddScoped<IProductAdapter<RegisterViewModel>, RegisterViewModelAdapter>();
        // ヘルパークラスの依存定義
        services.AddScoped<ProductRegisterHelper>();
    }
}
