using Framework.Core;
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
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 
        FrameworkInitializer.Instance.NavigateToWebsite("https://www.reddit.com");
        FrameworkInitializer.Instance.GetObjects(@"C:\Github\Web-Automator\WebAutomator\Testing\Resources\");
        _scenarioContext.Pending();
    }
}