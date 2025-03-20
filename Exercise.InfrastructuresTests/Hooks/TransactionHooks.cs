using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Reqnroll;
namespace Exercise.InfrastructuresTests.Hooks;
/// <summary>
/// トランザクションの開始とロールバックするフック
/// 提供
/// </summary>
[Binding]
public class TransactionHooks
{
    // @Transaction タグで FeatureContext と ScenarioContext を利用
    [BeforeScenario("@Transaction")]
    public void SetupTransaction(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        // ロガーを取得する
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var _logger = loggerFactory.CreateLogger<TransactionHooks>();
        // AppDbContextを取得する
        var appDbContext = featureContext.Get<AppDbContext>();
        // トランザクションを開始する
        var transaction = appDbContext!.Database.BeginTransaction();
        // ScenarioContextにトランザクションを登録する
        scenarioContext.Set<IDbContextTransaction>(transaction);
        _logger!.LogInformation("@Transactionタグの前処理 - トランザクションの開始!!");
    }

    /// <summary>
    /// @Transactionタグを付加したシナリオの後処理
    /// </summary>
    [AfterScenario("@Transaction")]
    public void RollbackTransaction(ScenarioContext scenarioContext)
    {
        // ロガーを取得する
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var _logger = loggerFactory.CreateLogger<TransactionHooks>();
        // ObjectContainerからトランザクションを取得する
        var transaction = scenarioContext.Get<IDbContextTransaction>();
        // トランザクションをロールバックする
        transaction.Rollback();
        _logger!.LogInformation(
        "@Transactionタグの後処理 - トランザクションのロールバック!!");
    }
}
