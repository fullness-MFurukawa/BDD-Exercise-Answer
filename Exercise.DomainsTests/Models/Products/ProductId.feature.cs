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
namespace Exercise.DomainsTests.Models.Products
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ProductIdFeature
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "ProductId.feature"
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
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Models/Products", "ProductId", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ProductId")))
            {
                await global::Exercise.DomainsTests.Models.Products.ProductIdFeature.FeatureSetupAsync(null);
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("有効なUUIDを保持したインスタンスが生成される")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        public async System.Threading.Tasks.Task 有効なUUIDを保持したインスタンスが生成される()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("有効なUUIDを保持したインスタンスが生成される", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
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
 await testRunner.GivenAsync("商品Idを用意する \'f073f7c3f35744ffbbdb3815e1d4b6c2\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 11
 await testRunner.WhenAsync("ProductIdを生成する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 12
 await testRunner.ThenAsync("ProductIdの値は \'f073f7c3f35744ffbbdb3815e1d4b6c2\' である", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("空文字を用いてインスタンス生成するとValidateException例外をスローする")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        public async System.Threading.Tasks.Task 空文字を用いてインスタンス生成するとValidateException例外をスローする()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("空文字を用いてインスタンス生成するとValidateException例外をスローする", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 15
 await testRunner.GivenAsync("商品Idを用意する \'\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 16
 await testRunner.WhenAsync("ProductIdを生成する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 17
 await testRunner.ThenAsync("ValidateExceptionがスローされる \'ProductIdは必須です。\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("nullを用いてインスタンス生成するとValidateException例外をスローする")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        public async System.Threading.Tasks.Task Nullを用いてインスタンス生成するとValidateException例外をスローする()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("nullを用いてインスタンス生成するとValidateException例外をスローする", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 19
 await testRunner.GivenAsync("商品Idを用意する \'null\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 20
 await testRunner.WhenAsync("ProductIdを生成する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 21
 await testRunner.ThenAsync("ValidateExceptionがスローされる \'ProductIdは必須です。\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32文字でない文字列でインスタンス生成するとValidateException例外をスローする")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        public async System.Threading.Tasks.Task _32文字でない文字列でインスタンス生成するとValidateException例外をスローする()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("32文字でない文字列でインスタンス生成するとValidateException例外をスローする", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 23
 await testRunner.GivenAsync("商品Idを用意する \'40cffd3bf63645c69a875c87ecb6f\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 24
 await testRunner.WhenAsync("ProductIdを生成する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 25
 await testRunner.ThenAsync("ValidateExceptionがスローされる \'ProductIdは32文字である必要があります。\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("UUID形式でない文字列でインスタンス生成するとValidateException例外をスローする")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        public async System.Threading.Tasks.Task UUID形式でない文字列でインスタンス生成するとValidateException例外をスローする()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("UUID形式でない文字列でインスタンス生成するとValidateException例外をスローする", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 27
 await testRunner.GivenAsync("商品Idを用意する \'abcd-1234-efgh-5678-ijkl-9012xzy\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 28
 await testRunner.WhenAsync("ProductIdを生成する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 29
 await testRunner.ThenAsync("ValidateExceptionがスローされる \'ProductIdは有効なUUID形式である必要があります。\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ProductIdのEqualsメソッド()を検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("f073f7c3f35744ffbbdb3815e1d4b6c2", "f073f7c3f35744ffbbdb3815e1d4b6c2", "true", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("18d30718efec45cbb644af2cf50c286f", "f073f7c3f35744ffbbdb3815e1d4b6c2", "false", null)]
        public async System.Threading.Tasks.Task ProductIdのEqualsメソッドを検証する(string value1, string value2, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("value1", value1);
            argumentsOfScenario.Add("value2", value2);
            argumentsOfScenario.Add("result", result);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("ProductIdのEqualsメソッド()を検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table36 = new global::Reqnroll.Table(new string[] {
                            "value1",
                            "value2"});
                table36.AddRow(new string[] {
                            string.Format("{0}", value1),
                            string.Format("{0}", value2)});
#line 34
 await testRunner.GivenAsync("商品Idを比較する値を用意する", ((string)(null)), table36, "Given ");
#line hidden
#line 37
 await testRunner.WhenAsync("Equalsメソッドを実行する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 38
 await testRunner.AndAsync("object型でEqualsメソッドを実行する", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table37 = new global::Reqnroll.Table(new string[] {
                            "result"});
                table37.AddRow(new string[] {
                            string.Format("{0}", result)});
#line 39
 await testRunner.ThenAsync("Equalsメソッド実行結果を評価する", ((string)(null)), table37, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ProductIdのGetHashCode()メソッドを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ProductId")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("f073f7c3f35744ffbbdb3815e1d4b6c2", "f073f7c3f35744ffbbdb3815e1d4b6c2", "true", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("18d30718efec45cbb644af2cf50c286f", "f073f7c3f35744ffbbdb3815e1d4b6c2", "false", null)]
        public async System.Threading.Tasks.Task ProductIdのGetHashCodeメソッドを検証する(string value1, string value2, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("value1", value1);
            argumentsOfScenario.Add("value2", value2);
            argumentsOfScenario.Add("result", result);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("ProductIdのGetHashCode()メソッドを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table38 = new global::Reqnroll.Table(new string[] {
                            "value1",
                            "value2"});
                table38.AddRow(new string[] {
                            string.Format("{0}", value1),
                            string.Format("{0}", value2)});
#line 50
    await testRunner.GivenAsync("商品Idのハッシュ値を生成する値を用意する", ((string)(null)), table38, "Given ");
#line hidden
#line 53
    await testRunner.WhenAsync("GetHashCodeメソッドを実行する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table39 = new global::Reqnroll.Table(new string[] {
                            "result"});
                table39.AddRow(new string[] {
                            string.Format("{0}", result)});
#line 54
    await testRunner.ThenAsync("GetHashCodeメソッド実行結果の比較結果を評価する", ((string)(null)), table39, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
