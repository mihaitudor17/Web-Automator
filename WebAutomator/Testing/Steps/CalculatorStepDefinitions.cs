using Framework.Core;
using Framework.Logging;
using Framework.Objects;
using Framework.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace Testing.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        FrameworkInitializer.Instance.NavigateToWebsite("https://www.reddit.com");
        List<Control> test = FrameworkInitializer.Instance.GetObjects(Path.GetFullPath(Constants.Resources));
        foreach(var item in test)
        {
            if(item != null) 
            item.Click();
        }
        ReportGenerator.Instance.GenerateReport();
        _scenarioContext.Pending();
    }
}