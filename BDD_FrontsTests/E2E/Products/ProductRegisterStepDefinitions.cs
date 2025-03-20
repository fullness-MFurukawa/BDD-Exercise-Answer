using BDD_FrontsTests.E2E.Commons;
using Microsoft.Playwright;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Products;
/// <summary>
/// 商品登録機能のE2Eテストドライバ
/// 提供
/// </summary>
[Binding]
public class ProductRegisterStepDefinitions
{
    // IPageインターフェイス
    private readonly IPage _page;
    // メニュー遷移検証共通ステップ
    private readonly GoMenuCommonSteps _menuCommons;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="page">IPageインターフェイス</param>
    /// <param name="menuCommons">メニュー遷移検証共通ステップ</param>
    public ProductRegisterStepDefinitions(
        IPage page, 
        GoMenuCommonSteps menuCommons)
    {
        _page = page;
        _menuCommons = menuCommons;
    }

    /// <summary>
    /// 商品登録画面が提供されることを検証する
    /// </summary>
    [Given("商品登録画⾯を表⽰するリクエストを送信する{string}")]
    public async Task Given商品登録画を表するリクエストを送信する(string url)
    {
        await _page.GotoAsync(url); // 入力画面に遷移する
    }

    [When("商品登録画⾯が表⽰される")]
    public async Task When商品登録画が表される()
    {
        // ページの読み込みが完了するまで待機する
        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    [Then("⼊⼒に必要な項⽬が表⽰されていることを評価する")]
    public async Task Thenに必要な項が表されていることを評価する(DataTable dataTable)
    {
        foreach (var row in dataTable.Rows)
        {
            // var itemName = row["項目名"];
            // var expectedValue = row["値"];
            var itemName = row[0];  // 1列目を項目名として扱う
            var expectedValue = row[1];  // 2列目を期待値として扱う
            switch (itemName)
            {
                case "pageTitle":   // ページタイトル
                    var pageTitle = await _page.TitleAsync();
                    Assert.AreEqual(expectedValue, pageTitle);
                    break;
                case "titleText":   // 画面タイトル
                    var titleText = await _page.InnerTextAsync("h2");
                    Assert.AreEqual(expectedValue, titleText);
                    break;
                case "productName_placeholder":     //  商品名
                    var productNamePlaceholder =
                        await _page.GetAttributeAsync("#ProductName", "placeholder");
                    Assert.AreEqual(expectedValue, productNamePlaceholder);
                    break;
                case "productPrice_placeholder":    //  単価  
                    var productPricePlaceholder =
                        await _page.GetAttributeAsync("#ProductPrice", "placeholder");
                    Assert.AreEqual(expectedValue, productPricePlaceholder);
                    break;
                case "register_btn":    //  [登録]ボタン
                    var registerBtnText =
                        await _page.InnerTextAsync("button[name='action'][value='Register']");
                    Assert.AreEqual(expectedValue, registerBtnText);
                    break;
                case "end_btn":         //  [終了]ボタン
                    var endBtnText =
                        await _page.InnerTextAsync("button[name='action'][value='End']");
                    Assert.AreEqual(expectedValue, endBtnText);
                    break;
                case "category_options": // カテゴリ(プルダウン)
                    var options =
                        await _page.QuerySelectorAllAsync("select[name='CategoryId'] option");
                    var optionTexts = new List<string>();
                    foreach (var option in options)
                    {
                        optionTexts.Add(await option.InnerTextAsync());
                    }
                    var expectedOptions = expectedValue.Split(',');
                    CollectionAssert.AreEqual(expectedOptions, optionTexts.ToArray());
                    break;
                default:
                    Assert.Fail($"Unknown item: {itemName}");
                    break;
            }
        }
    }

    /// <summary>
    /// 登録されていない商品を登録すると完了画面に遷移することを検証する
    /// </summary>
    [When("すべての⼊⼒項⽬に値を⼊⼒して[登録]ボタンをクリックする {string} {string} {string}")]
    public async Task Whenすべての項に値をして登録ボタンをクリックする(string name, string price, string category)
    {
        // 商品名を入力する
        await _page.FillAsync("#ProductName", name);
        // 単価を入力する
        await _page.FillAsync("#ProductPrice", price);
        // カテゴリを選択する
        await _page.SelectOptionAsync("#CategoryId",
            new[] { new SelectOptionValue { Label = category } });
        // [登録]ボタンをクリックする
        await _page.ClickAsync("button[value='Register']");
    }

    [Then("以下のメッセージが表⽰される")]
    public async Task Then以下のメッセージが表される(DataTable dataTable)
    {
        // ページ上のh4タグのテキストを順に取得
        var actualMessages = await _page.QuerySelectorAllAsync("h4");

        // DataTableの行をループして期待値と実際の値を比較
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            var expectedMessage = dataTable.Rows[i][0];  // DataTableの1列目のメッセージを取得
            var actualMessageText = await actualMessages[i+1].InnerTextAsync();  // 対応するh4のテキストを取得

            // 期待値と実際の値を比較
            Assert.AreEqual(expectedMessage, actualMessageText);
        }
    }

    /// <summary>
    /// 必須入力項目のすべてが未入力で[登録]ボタンをクリックすると、
    /// エラーメッセージが表示されることを検証する
    /// </summary
    [When("何も入力せずに[登録]ボタンをクリックする")]
    public async Task When何も入力せずに登録ボタンをクリックする()
    {
        // [登録]ボタンをクリックする
        await _page.ClickAsync("button[value='Register']");
    }

    [Then("以下のエラーメッセージが表示される")]
    public async Task Then以下のエラーメッセージが表示される(DataTable dataTable)
    {
        // エラーメッセージを取得する
        var validationSummary = await _page.InnerTextAsync(".text-danger");
        // DataTableの行をループして期待値と実際の値を比較
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            var expectedMessage = dataTable.Rows[i][0];
            Assert.IsTrue(validationSummary.Contains(expectedMessage), $"Expected message: {expectedMessage}");
        }
    }
    /// <summary>
    /// 商品名が未入力で[登録]ボタンをクリックすると、
    /// エラーメッセージが表示されることを検証する
    /// </summary>
    [When("単価を入力してカテゴリを選択たら[登録]ボタンをクリックする　{string} {string}")]
    public async Task When単価を入力してカテゴリを選択たら登録ボタンをクリックする(string price, string category)
    {
        // 単価を入力する
        await _page.FillAsync("#ProductPrice", price);
        // カテゴリを選択する
        await _page.SelectOptionAsync("#CategoryId", 
            new[] { new SelectOptionValue { Label = category } });
        // [登録]ボタンをクリックする
        await _page.ClickAsync("button[value='Register']");
    }
    /// <summary>
    /// 単価が未入力で[登録]ボタンをクリックすると、
    /// エラーメッセージが表示されることを検証する
    /// </summary>
    [When("商品名を入力してカテゴリを選択たら[登録]ボタンをクリックする　{string} {string}")]
    public async Task When商品名を入力してカテゴリを選択たら登録ボタンをクリックする(string name, string category)
    {
        // 商品名を入力する
        await _page.FillAsync("#ProductName", name);
        // カテゴリを選択する
        await _page.SelectOptionAsync("#CategoryId", 
            new[] { new SelectOptionValue { Label = category } });
        // [登録]ボタンをクリックする
        await _page.ClickAsync("button[value='Register']");
    }
    // <summary>
    /// カテゴリが未選択で[登録]ボタンをクリックすると、
    /// エラーメッセージが表示されることを検証する
    /// </summary>
    [When("商品名と単価を入力して[登録]ボタンをクリックする　{string} {string}")]
    public async Task When商品名と単価を入力して登録ボタンをクリックする(string name, string price)
    {
        // 商品名を入力する
        await _page.FillAsync("#ProductName", name);
        // 単価を入力する
        await _page.FillAsync("#ProductPrice", price);
        // [登録]ボタンをクリックする
        await _page.ClickAsync("button[value='Register']");
    }
}
