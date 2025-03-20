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
namespace Exercise.InfrastructuresTests.EntityFrameworkCore.Categories
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CategoryRepositoryFeature
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = new string[] {
                "InfraDependency"};
        
#line 1 "CategoryRepository.feature"
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
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EntityFrameworkCore/Categories", "CategoryRepository", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CategoryRepository")))
            {
                await global::Exercise.InfrastructuresTests.EntityFrameworkCore.Categories.CategoryRepositoryFeature.FeatureSetupAsync(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("存在する商品カテゴリIdでカテゴリを取得できることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task 存在する商品カテゴリIdでカテゴリを取得できることを検証する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("存在する商品カテゴリIdでカテゴリを取得できることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 14
    await testRunner.GivenAsync("商品カテゴリIdを⽤意する \'40cffd3bf63645c69a875c87ecb6f200\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 15
 await testRunner.WhenAsync("⽤意した商品カテゴリIdで商品カテゴリを取得する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 16
 await testRunner.ThenAsync("取得した商品カテゴリを評価する", "  Id: \"40cffd3bf63645c69a875c87ecb6f200\"\r\n  Name: \"文房具\"", ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("存在しない商品カテゴリIdで商品カテゴリを取得するとnullが返されることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task 存在しない商品カテゴリIdで商品カテゴリを取得するとNullが返されることを検証する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("存在しない商品カテゴリIdで商品カテゴリを取得するとnullが返されることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 22
 await testRunner.GivenAsync("商品カテゴリIdを⽤意する \'40cffd3bf63645c69a875c87ecb6f201\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 23
 await testRunner.WhenAsync("⽤意した商品カテゴリIdで商品カテゴリを取得する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 24
 await testRunner.ThenAsync("取得した商品カテゴリがnullであることを評価する", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("すべての商品カテゴリを取得できることを検証する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task すべての商品カテゴリを取得できることを検証する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("すべての商品カテゴリを取得できることを検証する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 29
    await testRunner.GivenAsync("取得する商品カテゴリを⽤意する", "- Id: \"40cffd3bf63645c69a875c87ecb6f200\"\r\n  Name: \"文房具\"\r\n- Id: \"0fc3f7819af345009" +
                        "d018c0ded8a94ee\"\r\n  Name: \"雑貨\"\r\n- Id: \"9a66b0c5c7b0407684fb0a92eca871d9\"\r\n  Name" +
                        ": \"PC周辺機器\"", ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 38
    await testRunner.WhenAsync("すべての商品カテゴリを取得する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 39
    await testRunner.ThenAsync("すべての商品カテゴリが取得されたことを評価する", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
