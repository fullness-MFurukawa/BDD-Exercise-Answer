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
    public partial class CategoryDBModelAdapterFeature
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = new string[] {
                "InfraDependency"};
        
#line 1 "CategoryDBModelAdapter.feature"
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
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EntityFrameworkCore/Categories", "CategoryDBModelAdapter", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CategoryDBModelAdapter")))
            {
                await global::Exercise.InfrastructuresTests.EntityFrameworkCore.Categories.CategoryDBModelAdapterFeature.FeatureSetupAsync(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CategoryをCategoryDBModelに変換する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryDBModelAdapter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task CategoryをCategoryDBModelに変換する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("CategoryをCategoryDBModelに変換する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 11
 await testRunner.GivenAsync("Categoryを⽤意する", "{\r\n\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\"Name\": \"⽂房具\"\r\n}", ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 18
 await testRunner.WhenAsync("CategoryをCategoryModelに変換する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 19
 await testRunner.ThenAsync("CategoryDBModelのプロパティを検証する", "{\r\n\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\"Name\": \"⽂房具\"\r\n}", ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CategoryのリストをCategoryDBModelのリストに変換する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryDBModelAdapter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task CategoryのリストをCategoryDBModelのリストに変換する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("CategoryのリストをCategoryDBModelのリストに変換する", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 await testRunner.GivenAsync("Categoryのリストを⽤意する", "[\r\n\t{\r\n\t\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\t\"Name\": \"⽂房具\"\r\n\t},\r\n\t{\r\n\t\t\"" +
                        "Id\": \"0fc3f7819af345009d018c0ded8a94ee\",\r\n\t\t\"Name\": \"雑貨\"\r\n\t},\r\n\t{\r\n\t\t\"Id\": \"9a66" +
                        "b0c5c7b0407684fb0a92eca871d9\",\r\n\t\t\"Name\": \"PC周辺機器\"\r\n\t}\r\n]", ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 44
 await testRunner.WhenAsync("CategoryのリストをCategoryModelのリストに変換する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 45
 await testRunner.ThenAsync("リスト内のCategoryDBModelのプロパティを検証する", "[\r\n\t{\r\n\t\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\t\"Name\": \"⽂房具\"\r\n\t},\r\n\t{\r\n\t\t\"" +
                        "Id\": \"0fc3f7819af345009d018c0ded8a94ee\",\r\n\t\t\"Name\": \"雑貨\"\r\n\t},\r\n\t{\r\n\t\t\"Id\": \"9a66" +
                        "b0c5c7b0407684fb0a92eca871d9\",\r\n\t\t\"Name\": \"PC周辺機器\"\r\n\t}\r\n]", ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CategoryDBModelからCategoryを復元する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryDBModelAdapter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task CategoryDBModelからCategoryを復元する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("CategoryDBModelからCategoryを復元する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 65
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 66
 await testRunner.GivenAsync("CategoryDBModelを⽤意する", "{\r\n\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\"Name\": \"⽂房具\"\r\n}", ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 73
 await testRunner.WhenAsync("CategoryModelからCategoryを復元する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 74
 await testRunner.ThenAsync("Categoryのプロパティを検証する", "{\r\n\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\"Name\": \"⽂房具\"\r\n}", ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CategoryDBModelのリストからCategoryのリストを復元する")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CategoryDBModelAdapter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InfraDependency")]
        public async System.Threading.Tasks.Task CategoryDBModelのリストからCategoryのリストを復元する()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("CategoryDBModelのリストからCategoryのリストを復元する", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 81
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 82
 await testRunner.GivenAsync("CategoryDBModelのリストを⽤意する", "[\r\n\t{\r\n\t\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\t\"Name\": \"⽂房具\"\r\n\t},\r\n\t{\r\n\t\t\"" +
                        "Id\": \"0fc3f7819af345009d018c0ded8a94ee\",\r\n\t\t\"Name\": \"雑貨\"\r\n\t},\r\n\t{\r\n\t\t\"Id\": \"9a66" +
                        "b0c5c7b0407684fb0a92eca871d9\",\r\n\t\t\"Name\": \"PC周辺機器\"\r\n\t}\r\n]", ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 99
 await testRunner.WhenAsync("CategoryDBModelのリストからCategoryのリストを復元する", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 100
 await testRunner.ThenAsync("リスト内のCategoryのプロパティを検証する", "[\r\n\t{\r\n\t\t\"Id\": \"40cffd3bf63645c69a875c87ecb6f200\",\r\n\t\t\"Name\": \"⽂房具\"\r\n\t},\r\n\t{\r\n\t\t\"" +
                        "Id\": \"0fc3f7819af345009d018c0ded8a94ee\",\r\n\t\t\"Name\": \"雑貨\"\r\n\t},\r\n\t{\r\n\t\t\"Id\": \"9a66" +
                        "b0c5c7b0407684fb0a92eca871d9\",\r\n\t\t\"Name\": \"PC周辺機器\"\r\n\t}\r\n]", ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
