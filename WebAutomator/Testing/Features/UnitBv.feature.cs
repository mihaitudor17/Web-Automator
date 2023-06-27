﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Testing.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UnitBvFeature : object, Xunit.IClassFixture<UnitBvFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UnitBv.feature"
#line hidden
        
        public UnitBvFeature(UnitBvFeature.FixtureData fixtureData, Testing_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UnitBv", "As a user I want to use the search function", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Search Tabere")]
        [Xunit.TraitAttribute("FeatureTitle", "UnitBv")]
        [Xunit.TraitAttribute("Description", "Search Tabere")]
        [Xunit.TraitAttribute("Category", "Automated")]
        public virtual void SearchTabere()
        {
            string[] tagsOfScenario = new string[] {
                    "Automated"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search Tabere", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
testRunner.Given("I navigate to the website \'https://www.unitbv.ro/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table11.AddRow(new string[] {
                            "Text",
                            "false"});
#line 8
 testRunner.When("I press the button with name \'Acceptare toate\' with the next settings:", ((string)(null)), table11, "When ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table12.AddRow(new string[] {
                            "Image",
                            "true"});
#line 11
  testRunner.And("I press the button with name \'Search\' with the next settings:", ((string)(null)), table12, "And ");
#line hidden
#line 14
  testRunner.And("I send \'tabere\' to the \'SearchBox\' textarea and confirm", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table13.AddRow(new string[] {
                            "Text",
                            "false"});
#line 15
  testRunner.And("I press the button with name \'Acceptare toate\' with the next settings:", ((string)(null)), table13, "And ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table14.AddRow(new string[] {
                            "Text",
                            "false"});
#line 18
  testRunner.And("I press the button with name \'Tabere 2023\' with the next settings:", ((string)(null)), table14, "And ");
#line hidden
#line 21
  testRunner.And("I change tab to \'Facultatea de Litere\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table15.AddRow(new string[] {
                            "Text",
                            "false"});
#line 22
  testRunner.And("I press the button with name \'Acceptare toate\' with the next settings:", ((string)(null)), table15, "And ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "ByLocation"});
                table16.AddRow(new string[] {
                            "Text",
                            "false"});
#line 25
  testRunner.And("I press the button with name \'Calendar tabere\' with the next settings:", ((string)(null)), table16, "And ");
#line hidden
#line 28
  testRunner.And("I change tab to \'Nota_calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.Then("URL contains \'https://litere.unitbv.ro/images/Tabere_2023\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
  testRunner.And("I generate and save the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
  testRunner.And("I close the instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UnitBvFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UnitBvFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion