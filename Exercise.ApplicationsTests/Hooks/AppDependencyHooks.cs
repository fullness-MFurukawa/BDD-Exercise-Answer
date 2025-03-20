using CommonsHelpers.Configs;
using Exercise.Applications.Services;
using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reqnroll;
namespace Exercise.ApplicationsTests.Hooks;
/// <summary>
/// アプリケーション層のテストに必要なインスタンスを用意するフック
/// 提供
/// </summary>
[Binding]
public class AppDependencyHooks
{
    /// <summary>
    /// すべてのテストの前処理
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    [BeforeFeature("@AppDependency")]
    public static void SetupDependency(FeatureContext featureContext)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var _logger = loggerFactory.CreateLogger<AppDependencyHooks>();
        // テストターゲットのインスタンスを保持したIServiceProviderを取得する
        var provider = ServiceProviderBuilder
            .GetServiceProvider("appsettings.Development.json");
        // ロガーを取得する
        _logger = provider.GetRequiredService<ILogger<AppDependencyHooks>>();
        _logger.LogInformation("すべてのテストの前処理 - 開始!!!");
        try
        {
            // AppDbContextのインスタンスを登録する
            featureContext.Set(provider!.GetRequiredService<AppDbContext>());
            _logger.LogInformation("AppDbContext - インスタンスを登録しました");

            // 演習-09 IProductSearchServiceインターフェイスとその実装を準備する
            featureContext.Set(
                provider!.GetRequiredService<IProductSearchService>());
            _logger.LogInformation("IProductSearchService - インスタンスを登録しました");

            // 演習-11 IProductRegisterServiceインターフェイスとその実装を用意する
            featureContext.Set(
                provider!.GetRequiredService<IProductRegisterService>());
            _logger.LogInformation("IProductRegisterService - インスタンスを登録しました");

            // 演習-13 IProductUpdateServiceインターフェイスとその実装を用意する
            featureContext.Set(
                provider!.GetRequiredService<IProductUpdateService>());
            _logger.LogInformation("IProductUpdateService - インスタンスを登録しました");

            _logger.LogInformation("すべてのテストの前処理 - 終了!!!");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "すべてのテストの前処理 - エラーが発⽣しました!!!");
            throw;
        }
    }

    /// <summary>
    /// すべてのテストの前処理
    /// </summary>
    /// <param name="featureContext">フィーチャーコンテキス</param>
    [AfterFeature("@AppDependency")]
    public static void CleanupDependency(FeatureContext featureContext)
    {
        featureContext.Clear();
    }
}
