using Framework.Core;
using Framework.Logging;

namespace Testing.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the website '(.*)'")]
        public void NavigateToTheWebsite(string url)
        {
            FrameworkInitializer.Instance.GetDriver().Navigate().GoToUrl(url);
        }
        [Then(@"I generate and save the report")]
        public void GenerateReport()
        {
            ReportGenerator.Instance.AddLogEvent(new CustomLogEventInfo { Message = "Report created", Level = NLog.LogLevel.Info }, capture: true);
            ReportGenerator.Instance.GenerateReport(_scenarioContext.ScenarioInfo.Title);
        }
        [Then(@"I close the instance")]
        public void CloseTheInstance()
        {
            FrameworkInitializer.Instance.GetDriver().Quit();
        }
    }
}