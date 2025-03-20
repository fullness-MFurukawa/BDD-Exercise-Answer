using CommonsHelpers.Configs;
using CommonsHelpers.Utils;
using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Testing.Platform.Logging;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Hooks;
/// <summary>
/// データ復元用フック
/// 提供
/// </summary>
[Binding]
public class UIRestoringDataHooks
{
    /// <summary>
    /// シナリオ実行後のデータ復元
    /// </summary>
    [AfterScenario("@Restoring")]
    public async Task RestoringData()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<RestoringData>();
        // テストターゲットのインスタンスを保持したIServiceProviderを取得する
        var provider = ServiceProviderBuilder.GetServiceProvider("appsettings.Development.json");
        var restoringData = new RestoringData(
           provider.GetRequiredService<AppDbContext>(),logger);

        logger!.LogInformation("UIRestoringDataHooks - データ復旧開始!!!");
        try
        {
            await restoringData.RestoringAsync();
            logger!.LogInformation("RestoringDataHooks - データ復旧終了!!!");
        }
        catch (Exception)
        {
            return;
        }
    }
}
