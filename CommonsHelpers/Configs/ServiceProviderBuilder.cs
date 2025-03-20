using BDD_Fronts.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace CommonsHelpers.Configs;
/// <summary>
/// テストターゲットインスタンスを提供するServiceProvider構築クラス
/// 提供
/// </summary>
public static class ServiceProviderBuilder
{
    /// <summary>
    /// ServiceProviderを返す
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider GetServiceProvider(string appsettings)
    {
        // 設定ファイルの読み込み
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(appsettings).Build();
        // ServiceCollectionを生成する
        var services = new ServiceCollection();
        // アプリケーションの依存関係を構築する
        SetupAppDependency.SettingDependencyInjection(configuration, services);
        // ロギングサービスを追加する
        services.AddLogging(configure => configure.AddConsole());
        // ServiceProviderの構築する
        var provider = services.BuildServiceProvider();
        return provider;
    }
}
