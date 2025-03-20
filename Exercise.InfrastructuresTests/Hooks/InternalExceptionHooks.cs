using CommonsHelpers.Configs;
using Exercise.Infrastructures.EntityFrameworkCore;
using Exercise.Infrastructures.EntityFrameworkCore.Categories;
using Exercise.Infrastructures.EntityFrameworkCore.Products;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reqnroll;
namespace Exercise.InfrastructuresTests.Hooks;
/// <summary>
/// InternalExceptionテストに必要なインスタンス登録フック
/// 提供
/// </summary>
[Binding]
public class InternalExceptionHooks
{
    /// <summary>
    /// @InternalExceptionタグを付加してFeatureの前処理
    /// </summary>
    [BeforeFeature("@InternalException")]
    public static void SetupInternalException(FeatureContext featureContext)
    {
        // ここで Logger インスタンスを取得または生成する（依存性注入が使えない場合）
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var _logger = loggerFactory.CreateLogger<InternalExceptionHooks>();

        _logger!.LogInformation("@InternalExceptionの前処理 - 開始!!");
        // テストターゲットのインスタンスを保持したIServiceProviderを取得する
        var provider = ServiceProviderBuilder
            .GetServiceProvider("appsettings.InternalExceotion.json");
        var dbContext = provider!.GetRequiredService<AppDbContext>();
        // テーブルモデルを無効化する
        dbContext.Categories = null;
        dbContext.Products = null;
        featureContext.Set(dbContext, "InternalDbContext");

        var categoryRepository =
            new CategoryRepository(dbContext, new CategoryDBModelAdapter());
        featureContext.Set(categoryRepository, "InternalExceptionCategoryRepository");

        // 演習-07で追加
        var productRepository =
            new ProductRepository(dbContext,
                new ProductDBModelAdapter(new CategoryDBModelAdapter()));
        featureContext.Set(productRepository, "InternalExceptionProductRepository");

        _logger!.LogInformation("ICategoryRepository - インスタンスを登録しました");
        _logger!.LogInformation("@InternalExceptionの前処理 - 完了!!");
    }

    /// <summary>
    /// @InternalExceptionタグを付加してFeatureの後処理
    /// </summary>
    [AfterFeature("@InternalException")]
    public static void CleanupInternalException(FeatureContext featureContext)
    {
        var dbContext = featureContext.Get<AppDbContext>("InternalDbContext");
        dbContext.Dispose();
        featureContext.Clear();
    }
}
