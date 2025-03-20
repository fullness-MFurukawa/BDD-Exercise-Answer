using BDD_FrontsTests.E2E.Commons;
using CommonsHelpers.Factories;
using Microsoft.Playwright;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Products;
/// <summary>
/// 演習-15 商品検索機能のシナリオ、テストドライバ、コントローラを作成する
/// </summary>
[Binding]
public class ProductSearchStepDefinitions
{
    // IPageインターフェイス
    private readonly IPage _page;
    // DataTable変換ファクトリ
    private readonly ProductDataTablesFactory _dataTablesFactory;
    // メニュー遷移評価共通ステップ
    private readonly GoMenuCommonSteps _menuCommons;
    // シナリオコンテキスト
    private readonly ScenarioContext _scenarioContext;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="page">IPageインターフェイス</param>
    /// <param name="dataTablesFactory">DataTable変換ファクトリ</param>
    /// <param name="menuCommons">メニュー遷移評価共通ステップ</param>
    public ProductSearchStepDefinitions(
        IPage page, 
        ProductDataTablesFactory dataTablesFactory, 
        GoMenuCommonSteps menuCommons,
        ScenarioContext scenarioContext)
    {
        _page = page;
        _dataTablesFactory = dataTablesFactory;
        _menuCommons = menuCommons;
        _scenarioContext = scenarioContext;
    }

    [Given("検索画面を表示するリクエストを送信する {string}")]
    public async Task Given検索画面を表示するリクエストを送信する(string url)
    {
        // 指定のURLでリクエストを送信する
        await _page.GotoAsync(url); 
    }
    [When("検索画面が表示される")]
    public async Task When検索画面が表示される()
    {
        // ページが完全に読み込まれるまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
    [Then("キーワード入力項目と[検索]ボタンが表示されたことを評価する")]
    public async Task Thenキーワード入力項目と検索ボタンが表示されたことを評価する()
    {
        // 入力項目とボタンを取得する
        var keywordInput = await _page.QuerySelectorAsync("#keyword");
        var searchButton = await _page.QuerySelectorAsync(
                            "button[name='action'][value='Search']");
        Assert.IsNotNull(keywordInput);
        Assert.IsNotNull(searchButton);
    }

  
    [When("キーワードを入力し [検索] ボタンをクリックする {string}")]
    public async Task Whenキーワードを入力し検索ボタンをクリックする(string keyword)
    {
        // キーワードを入力する
        await _page.FillAsync("#keyword", keyword);
        // [検索]ボタンをクリックする
        await _page.ClickAsync("button[name='action'][value='Search']");
        // 検索結果が読み込まれるまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("検索結果として以下の内容が表示されたことを評価する")]
    public async Task Then検索結果として以下の内容が表示されたことを評価する(DataTable dataTable)
    {
        // テーブル行を取得
        var rows = await _page.QuerySelectorAllAsync("table tbody tr");
        // DataTableをProduct型に変換する
        var products = _dataTablesFactory.ConvertProducts(dataTable);
        // 両方の件数が正しいことを評価する
        Assert.AreEqual(products.Count, rows.Count);

        // 表示内容の詳細を評価する
        for (int i = 0; i < products.Count; i++)
        {
            var expectedRow = products[i];
            var actualRow = rows[i];
            // 各セルのテキストを取得して評価する
            var cells = await actualRow.QuerySelectorAllAsync("td");
            Assert.AreEqual(3, cells.Count); // 各行には3つのセルがあることを評価
                                             // セルの値を取得する
            var productIdText = await cells[0].InnerTextAsync();
            var productNameText = await cells[1].InnerTextAsync();
            var productPriceText = await cells[2].InnerTextAsync();
            // 取得した結果を評価する
            Assert.AreEqual(expectedRow.Id.Value, productIdText);
            Assert.AreEqual(expectedRow.Name.Value, productNameText);
            Assert.AreEqual(expectedRow.Price.Value.ToString(), productPriceText);
        }
    }

    [When("キーワードを入力せずに [検索] ボタンをクリックする")]
    public async Task Whenキーワードを入力せずに検索ボタンをクリックする()
    {
        // [検索]ボタンをクリックする
        await _page.ClickAsync("button[name='action'][value='Search']");
        // ページが再読み込みされるまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("エラーメッセージが表示されたことを評価する {string}")]
    public async Task Thenエラーメッセージが表示されたことを評価する(string expectedMessage)
    {
        // エラーメッセージを取得する
        var errorMessageElement = await _page.QuerySelectorAsync(".text-danger");
        var errorMessageText = await errorMessageElement!.InnerTextAsync();
        Assert.AreEqual(expectedMessage, errorMessageText);
    }

    [AfterScenario("@PDF")]
    public async Task AfterScenarioTakePdf()
    {
        if (_scenarioContext.ScenarioInfo.Tags.Contains("PDF"))
        {
            var projectDir = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\BDD_FrontsTests"));
            var pdfPath = Path.Combine(projectDir, "E2E");
            var filePath = Path.Combine(pdfPath, $"{_scenarioContext.ScenarioInfo.Title}.pdf");
            await _page.PdfAsync(new PagePdfOptions { Path = filePath });
        }
    }
}
