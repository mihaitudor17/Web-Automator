using Framework.Core;
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
        List<Control> test = FrameworkInitializer.Instance.GetObjects(@"C:\Users\blaga\Desktop\Web-Automator\WebAutomator\Testing\Resources");
        var test1 = test[0].Element.Location;
        test[1].Element.Click();
        _scenarioContext.Pending();
    }
}