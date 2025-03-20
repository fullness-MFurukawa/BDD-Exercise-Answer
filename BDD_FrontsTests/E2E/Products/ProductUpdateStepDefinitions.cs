using BDD_FrontsTests.E2E.Commons;
using CommonsHelpers.Factories;
using Microsoft.Playwright;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Products;
/// <summary>
/// 演習-17 商品変更機能のシナリオ、テストドライバ、コントローラを作成する
/// </summary>
[Binding]
public class ProductUpdateStepDefinitions
{
    // IPageインターフェイス
    private readonly IPage _page;
    // メニュー画面遷移評価共通ステップ
    private readonly GoMenuCommonSteps _goMenuCommonSteps;
    // DataTableをProductに変換するファクトリ
    private readonly ProductDataTablesFactory _productDataTablesFactory;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="page">IPageインターフェイス</param>
    /// <param name="goMenuCommonSteps">メニュー画面遷移評価共通ステップ</param>
    /// <param name="productDataTablesFactory">DataTableをProductに変換するファクトリ</param>
    public ProductUpdateStepDefinitions(
        IPage page, 
        GoMenuCommonSteps goMenuCommonSteps, 
        ProductDataTablesFactory productDataTablesFactory)
    {
        _page = page;
        _goMenuCommonSteps = goMenuCommonSteps;
        _productDataTablesFactory = productDataTablesFactory;
    }

    [Given("検索画面を表示する {string}")]
    public async Task Given検索画面を表示する(string url)
    {
        await _page.GotoAsync(url); // 検索画面に遷移する
    }
    [Given("検索画面が表示される")]
    public async Task Given検索画面が表示される()
    {
        // 画面表示が完了するまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
    [Given("キーワードを入力し [検索] ボタンをクリックする {string}")]
    public async Task Givenキーワードを入力し検索ボタンをクリックする(string keyword)
    {
        // キーワードを入力し、[検索]ボタンをクリックする
        await _page.FillAsync("#keyword", keyword);
        await _page.ClickAsync("button[type='submit'][name='action'][value='Search']");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
    [Given("変更する商品を選択する {string}")]
    public async Task Given変更する商品を選択する(string productName)
    {
        // 表示された商品名のリンクを取得してクリックする
        var productLink = await _page.WaitForSelectorAsync($"a:has-text('{productName}')");
        await productLink!.ClickAsync();
    }

    [When("変更画面が表示される")]
    public async Task When変更画面が表示される()
    {
        // 画面表示が完了するまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
    [Then("変更画面の表示内容を評価する")]
    public async Task Then変更画面の表示内容を評価する(DataTable dataTable)
    {
        // タイトルを評価する
        var pageTitle = await _page.InnerTextAsync("h2");
        Assert.AreEqual("商品変更", pageTitle);
        // 期待値をProductに変換する
        var expectedProduct = _productDataTablesFactory.ConvertProduct(dataTable);
        // 表示された値を取得する
        var productId = await _page.GetAttributeAsync("#ProductId", "value");
        var productName = await _page.GetAttributeAsync("#ProductName", "value");
        var productPrice = await _page.GetAttributeAsync("#ProductPrice", "value");
        // 表示された値を評価する
        Assert.AreEqual(expectedProduct.Id.Value, productId);
        Assert.AreEqual(expectedProduct.Name.Value, productName);
        Assert.AreEqual(expectedProduct.Price.Value.ToString(), productPrice);
    }

    [When("単価を変更して、[変更]ボタンをクリックする {string}")]
    public async Task When単価を変更して変更ボタンをクリックする(string newPrice)
    {
        // 単価を変更する
        await _page.FillAsync("#ProductPrice", newPrice);
        // 変更ボタンをクリックする
        await _page.ClickAsync("button[type='submit'][name='action'][value='Update']");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("変更完了画面が表示されることを評価する")]
    public async Task Then変更完了画面が表示されることを評価する()
    {
        // 変更完了画面の表示を評価する
        var pageTitle = await _page.InnerTextAsync("h2");
        Assert.AreEqual("商品変更", pageTitle);

        // 商品名と単価が正しく表示されていることを評価する
        var successMessage = await _page.InnerTextAsync("#change-message");
        Assert.AreEqual("以下の商品を変更しました。", successMessage);
        var changeDetails = await _page.InnerTextAsync("#change-details");
        Assert.IsTrue(changeDetails.Contains("商品:水性ボールペン 赤"));
        Assert.IsTrue(changeDetails.Contains("単価:180"));
    }

    [When("商品名と単価をクリアする")]
    public async Task When商品名と単価をクリアする()
    {
        // 商品名と単価をクリアする
        await _page.FillAsync("#ProductName", "");
        await _page.FillAsync("#ProductPrice", "");
    }

    [When("[変更]ボタンをクリックする")]
    public async Task When変更ボタンをクリックする()
    {
        // 変更ボタンをクリックする
        await _page.ClickAsync("button[type='submit'][name='action'][value='Update']");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("以下のエラーメッセージが表示されることを評価する")]
    public async Task Then以下のエラーメッセージが表示されることを評価する(DataTable dataTable)
    {
        // エラーメッセージを取得して評価する
        var validationSummary = await _page.InnerTextAsync(".text-danger");

        foreach (var row in dataTable.Rows)
        {
            var expectedMessage = dataTable.Rows[0][0];
            Assert.IsTrue(validationSummary.Contains(expectedMessage));
        }
    }

    [When("商品名をクリアする")]
    public async Task When商品名をクリアする()
    {
        // 商品名をクリアする
        await _page.FillAsync("#ProductName", "");
    }

    [When("単価をクリアする")]
    public async Task When単価をクリアする()
    {
        // 単価をクリアする
        await _page.FillAsync("#ProductPrice", "");
    }

    [When("[検索]ボタンをクリックする")]
    public async Task When検索ボタンをクリックする()
    {
        // 検索ボタンをクリックする
        await _page.ClickAsync("button[type='submit'][name='action'][value='Search']");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("検索画面が表示されたことを評価する")]
    public async Task Then検索画面が表示されたことを評価する()
    {
        // 検索画面が表示されたことを評価する
        var pageTitle = await _page.InnerTextAsync("h2");
        Assert.AreEqual("商品キーワード検索", pageTitle);
    }
}
