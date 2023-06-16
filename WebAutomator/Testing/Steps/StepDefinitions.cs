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
    public StepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [When(@"I log into the website with user '([^']*)' and password '([^']*)'")]
    public void LogIntoTheWebsiteWithUserAndPassword(string user, string password)
    {
        GetObject("LoginAccess").Click();
        var username = GetObject("Username");
        username.Click();
        username.SendKeys(user);
        GetObject("Password").Click();
        GetObject("Password").SendKeys(password);
        GetObject("LoginAccount").Click();
        ReportGenerator.Instance.GenerateReport(_scenarioContext.ScenarioInfo.Title);
    }
}