using CommonsHelpers.Configs;
using Exercise.Domains.Models.Categories;
using Exercise.Domains.Models.Products;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reqnroll;
using Microsoft.Extensions.DependencyInjection;
namespace Exercise.InfrastructuresTests.Hooks;
/// <summary>
/// インフラストラクチャ層のテスト対象をDIコンテナから取得するクラス
/// 提供
/// </summary>
[Binding]
public class InfraDependencyHooks
{
    /// <summary>
    /// Featute毎のテストの前処理
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキスト</param>
    [BeforeFeature("@InfraDependency")]
    public static void SetupDependency(FeatureContext featureContext)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var _logger = loggerFactory.CreateLogger<InfraDependencyHooks>();
        // テストターゲットのインスタンスを保持したIServiceProviderを取得する
        var provider = ServiceProviderBuilder
            .GetServiceProvider("appsettings.Development.json");
        // ロガーを取得する
        _logger = provider.GetRequiredService<ILogger<InfraDependencyHooks>>();
        _logger.LogInformation("すべてのテストの前処理 - 開始!!!");
        try
        {
            // ICategoryAdapter<CategoryModel>のインスタンスを登録する
            featureContext.Set(
                provider!.GetRequiredService<ICategoryAdapter<CategoryDBModel>>());
            _logger.LogInformation("ICategoryAdapter<CategoryDBModel> - インスタンスを登録しました");

            // 演習-05で追加 IProductAdapter<ProductModel>のインスタンスを登録する
            featureContext.Set(
                provider!.GetRequiredService<IProductAdapter<ProductDBModel>>());
            _logger.LogInformation("IProductAdapter<ProductDBModel> - インスタンスを登録しました");

            // CategoryRepositoryのインスタンスを登録する
            featureContext.Set(
                provider!.GetRequiredService<ICategoryRepository>());
            _logger.LogInformation("ICategoryRepository - インスタンスを登録しました");

            // 演習-07で追加 IProductRepositoryのインスタンスを登録する
            featureContext.Set(
                provider!.GetRequiredService<IProductRepository>());
            _logger.LogInformation("IProductRepository - インスタンスを登録しました");

            // AppDbContextのインスタンスを登録する
            featureContext.Set(provider!.GetRequiredService<AppDbContext>());
            _logger.LogInformation("AppDbContext - インスタンスを登録しました");

            _logger.LogInformation("すべてのテストの前処理 - 終了!!!");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "すべてのテストの前処理 - エラーが発⽣しました!!!");
            throw;
        }
    }

    /// <summary>
    /// Featute毎のテストの後処理
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキスト</param>
    [AfterFeature("@InfraDependency")]
    public static void CleanupDependency(FeatureContext featureContext)
    {
        featureContext.Clear();
    }
}
