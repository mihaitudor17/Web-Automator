using Framework.Core;
using Framework.Logging;
using Framework.Objects;
using Testing.Utils;

namespace Testing.Steps;

[Binding]
public sealed class StepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private Control GetObject(string name) => FrameworkInitializer.Instance.GetObject(FileDictionary.FileDict[name]);
    private Control GetObject(string searchText, string name, string type) => FrameworkInitializer.Instance.GetObject(searchText, name, type);
    public StepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [When(@"I signup into the website with the following email: '([^']*)'")]
    public void LogIntoTheWebsiteWithUserAndPassword(string email)
    {
        GetObject("LoginAccess").Click();
        GetObject("Sign up", "Signup", "Label").Click();
        GetObject("Email").SendKeys(email);
        GetObject("Continue").Click();
        ReportGenerator.Instance.GenerateReport(_scenarioContext.ScenarioInfo.Title);
    }
}