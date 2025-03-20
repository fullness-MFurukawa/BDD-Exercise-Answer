﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BDD_FrontsTests.E2E.Products
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ProductRegisterFeature
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "ProductRegister.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly();
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "E2E/Products", "ProductRegister", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute(Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupBehavior.EndOfClass)]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ProductRegister")))
            {
                await global::BDD_FrontsTests.E2E.Products.ProductRegisterFeature.FeatureSetupAsync(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 10
#line hidden
#line 11
await testRunner.GivenAsync("商品登録画⾯を表⽰するリクエストを送信する\'https://localhost:7066/exercise/product/register/Enter\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("商品登録画⾯が提供されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 商品登録画が提供されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("商品登録画⾯が提供されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 15
await testRunner.WhenAsync("商品登録画⾯が表⽰される", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "pageTitle",
                            "商品登録"});
                table1.AddRow(new string[] {
                            "titleText",
                            "商品登録"});
                table1.AddRow(new string[] {
                            "productName_placeholder",
                            "商品名を入力"});
                table1.AddRow(new string[] {
                            "productPrice_placeholder",
                            "単価を入力"});
                table1.AddRow(new string[] {
                            "register_btn",
                            "登録"});
                table1.AddRow(new string[] {
                            "end_btn",
                            "終了"});
                table1.AddRow(new string[] {
                            "category_options",
                            "カテゴリを選択,文房具,雑貨,PC周辺機器"});
#line 16
await testRunner.ThenAsync("⼊⼒に必要な項⽬が表⽰されていることを評価する", ((string)(null)), table1, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("登録されていない商品を登録すると完了画⾯に遷移することを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Restoring")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 登録されていない商品を登録すると完了画に遷移することを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Restoring",
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("登録されていない商品を登録すると完了画⾯に遷移することを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 26
await testRunner.WhenAsync("すべての⼊⼒項⽬に値を⼊⼒して[登録]ボタンをクリックする \'消しゴム\' \'120\' \'文房具\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "以下の商品を登録しました。"});
                table2.AddRow(new string[] {
                            "商品:消しゴム 単価:120"});
#line 27
await testRunner.ThenAsync("以下のメッセージが表⽰される", ((string)(null)), table2, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("終了ボタンをクリックしたら、メニュー画⾯に遷移することを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 終了ボタンをクリックしたらメニュー画に遷移することを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("終了ボタンをクリックしたら、メニュー画⾯に遷移することを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 35
await testRunner.GivenAsync("テスト対象のページリクエストを送信する \'https://localhost:7066/exercise/product/register/Enter\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 36
await testRunner.WhenAsync("[終了]ボタンをクリックする", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 37
await testRunner.ThenAsync("メニュー画⾯が表⽰されたことを評価する", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("必須入力項目のすべてが未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 必須入力項目のすべてが未入力で登録ボタンをクリックするとエラーメッセージが表示されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("必須入力項目のすべてが未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 44
    await testRunner.WhenAsync("何も入力せずに[登録]ボタンをクリックする", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table3 = new global::Reqnroll.Table(new string[] {
                            "商品名を入力してください"});
                table3.AddRow(new string[] {
                            "単価を入力してください"});
                table3.AddRow(new string[] {
                            "カテゴリを選択してください"});
#line 45
    await testRunner.ThenAsync("以下のエラーメッセージが表示される", ((string)(null)), table3, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("商品名が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 商品名が未入力で登録ボタンをクリックするとエラーメッセージが表示されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("商品名が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 51
 await testRunner.WhenAsync("単価を入力してカテゴリを選択たら[登録]ボタンをクリックする　\'100\' \'文房具\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table4 = new global::Reqnroll.Table(new string[] {
                            "商品名を入力してください"});
#line 52
 await testRunner.ThenAsync("以下のエラーメッセージが表示される", ((string)(null)), table4, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("単価が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 単価が未入力で登録ボタンをクリックするとエラーメッセージが表示されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("単価が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 55
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 56
 await testRunner.WhenAsync("商品名を入力してカテゴリを選択たら[登録]ボタンをクリックする　\'消しゴム\' \'文房具\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table5 = new global::Reqnroll.Table(new string[] {
                            "単価を入力してください"});
#line 57
 await testRunner.ThenAsync("以下のエラーメッセージが表示される", ((string)(null)), table5, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("カテゴリが未選択で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task カテゴリが未選択で登録ボタンをクリックするとエラーメッセージが表示されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("カテゴリが未選択で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 60
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 61
 await testRunner.WhenAsync("商品名と単価を入力して[登録]ボタンをクリックする　\'消しゴム\' \'100\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table6 = new global::Reqnroll.Table(new string[] {
                            "カテゴリを選択してください"});
#line 62
 await testRunner.ThenAsync("以下のエラーメッセージが表示される", ((string)(null)), table6, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("登録済みの商品名を入力して[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductRegister")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Video")]
        public async System.Threading.Tasks.Task 登録済みの商品名を入力して登録ボタンをクリックするとエラーメッセージが表示されることを検証する()
        {
            string[] tagsOfScenario = new string[] {
                    "Video"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("登録済みの商品名を入力して[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 68
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
await this.FeatureBackgroundAsync();
#line hidden
#line 69
 await testRunner.WhenAsync("すべての⼊⼒項⽬に値を⼊⼒して[登録]ボタンをクリックする \'蛍光ペン 黄\' \'180\' \'文房具\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "商品名:蛍光ペン 黄は、既に登録済みです。"});
#line 70
 await testRunner.ThenAsync("以下のエラーメッセージが表示される", ((string)(null)), table7, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
