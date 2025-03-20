using Microsoft.Playwright;
using Reqnroll.BoDi;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Hooks;
/// <summary>
/// Playwrightを利用したE2Eテスト用フック
/// 提供
/// </summary>
[Binding]
public class PlaywrightHooks
{
    // ReqnrollのObjectContainerへの参照
    private readonly IObjectContainer _objectContainer;
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="objectContainer"></param>
    /// <param name="scenarioContext"></param>
    public PlaywrightHooks(
        IObjectContainer objectContainer,
        ScenarioContext scenarioContext)
    {
        _objectContainer = objectContainer;
        _scenarioContext = scenarioContext;
    }

    /// <summary>
    /// シナリオ実行前にブラウザとページをセットアップする
    /// </summary>
    /// <returns></returns>
    [BeforeScenario]
    public async Task SetupPlaywright()
    {
        // Playwrightの初期化
        IPlaywright playwright = await Playwright.CreateAsync();
        // ヘッドレスモードでChromiumブラウザを起動
        IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true // ブラウザをヘッドレスモードで起動
        });
        // ブラウザコンテキストの生成
        IBrowserContext context = await browser.NewContextAsync();
        // 新しいページを作成
        IPage page = await context.NewPageAsync();
        // ObjectContainerにブラウザインスタンスを登録
        _objectContainer.RegisterInstanceAs(browser);
        // ObjectContainerにページインスタンスを登録
        _objectContainer.RegisterInstanceAs(page);
    }
    /// <summary>
    /// シナリオ実行後にブラウザをクローズ
    /// </summary>
    /// <returns></returns>
    [AfterScenario]
    public async Task CleanupPlaywright()
    {
        // ブラウザをクローズしてリソースを解放する
        var browser = _objectContainer!.Resolve<IBrowser>();
        // ブラウザをクローズしてリソースを解放する
        await browser.CloseAsync();
    }

    [BeforeScenario("@Video")]
    public async Task BeforeScenarioSetup()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // ヘッドフルモードでブラウザを起動
        });
        var projectDir = Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory, "..\\..\\..\\..\\BDD_FrontsTests"));
        var videoPath = Path.Combine(projectDir, "E2E");
        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = videoPath
        });
        var page = await context.NewPageAsync();
        _objectContainer.RegisterInstanceAs(browser);
        _objectContainer.RegisterInstanceAs(page);
    }

    [AfterScenario("@Video")]
    public async Task AfterScenarioSaveVideo()
    {
        var page = _objectContainer!.Resolve<IPage>();
        var projectDir = Path.GetFullPath(Path.Combine(
        AppContext.BaseDirectory, "..\\..\\..\\..\\BDD_FrontsTests"));
        var videoPath = Path.Combine(projectDir, "E2E");
        videoPath = Path.Combine(videoPath, $"{_scenarioContext.ScenarioInfo.Title}.webm");
        var video = await page.Video!.PathAsync();
        File.Move(video, videoPath);
        var browser = _objectContainer!.Resolve<IBrowser>();
        await browser.CloseAsync();
    }
}
