using CommonsHelpers.Utils;
using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reqnroll;
namespace Exercise.ApplicationsTests.Hooks;
/// <summary>
/// テストデータを復元するフック
/// 提供
/// </summary>
[Binding]
public class RestoringDataHooks
{
    /// <summary>
    /// シナリオ実行後のデータ復元
    /// </summary>
    [AfterScenario("@Restoring")]
    public void RestoringData(FeatureContext featureContext)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<RestoringData>();
        logger!.LogInformation("RestoringDataHooks - データ復旧開始!!!");
        var r = new RestoringData(
            featureContext.Get<AppDbContext>(),
            logger);
        try
        {
            r.Restoring();
            logger!.LogInformation("RestoringDataHooks - データ復旧終了!!!");
        }
        catch (Exception)
        {
            return;
        }
    }
}
