using Framework.Core;
using Framework.Logging;

namespace Testing.Hooks
{
    [Binding]
    public class Hooks
    {
        [Given(@"I navigate to the website '(.*)'")]
        public void NavigateToTheWebsite(string url)
        {
            FrameworkInitializer.Instance.NavigateToWebsite(url);
        }
        [Then(@"I generate and save the report")]
        public void GenerateReport()
        {
            ReportGenerator.Instance.GenerateReport(ScenarioContext.Current.ScenarioInfo.Title);
        }
    }
}