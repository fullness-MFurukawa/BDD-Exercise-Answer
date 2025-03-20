using Microsoft.Playwright;
using Reqnroll;
namespace BDD_FrontsTests.E2E.Commons;
/// <summary>
/// [終了]ボタンをクリックするとメニュー(トップ)に遷移することを検証する共通ステップ
/// 提供
/// </summary>
[Binding]
public class GoMenuCommonSteps
{
    private readonly IPage _page;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="page"></param>
    public GoMenuCommonSteps(IPage page)
    {
        _page = page;
    }
    [Given("テスト対象のページリクエストを送信する {string}")]
    public async Task Givenテスト対象のページリクエストを送信する(string url)
    {
        await _page.GotoAsync(url); // 入力画面に遷移する
    }

    [When("[終了]ボタンをクリックする")]
    public async Task When終了ボタンをクリックする()
    {
        // [終了]ボタンをクリックする
        await _page.ClickAsync("button[type='submit'][value='End']");
        // メニュー画面が完全に読み込まれるまで待機する
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("メニュー画⾯が表⽰されたことを評価する")]
    public async Task Thenメニュー画が表されたことを評価する()
    {
        var url = _page.Url;

        Assert.IsTrue(url.Contains("/exercise/menu"));
        // タイトルを検証
        var title = await _page.TitleAsync();
        Assert.AreEqual("トップ", title);
    }
}
