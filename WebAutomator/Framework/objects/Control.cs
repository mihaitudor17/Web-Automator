using Framework.Core;
using Framework.Logging;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Objects
{
    public abstract class Control
    {
        private readonly IWebElement _element;
        private readonly string _name;
        private readonly IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly ReportGenerator report = ReportGenerator.Instance;
        protected Control(IWebElement element, string name)
        {
            _element = element;
            _name = name;
        }

        public string Name => _name;

        public void Click()
        {
            var logMessage = $"Clicking on element '{_name}'";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            _element.Click();
        }

        public void SendKeys(string text)
        {
            var logMessage = $"Sending keys '{text}' to element '{_name}'";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            _element.SendKeys(text);
        }

        public void WaitUntilVisible(TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(driver => _element.Displayed);
        }

        public bool IsDisplayed()
        {
            var logMessage = $"Checking if element '{_name}' is displayed";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            return _element.Displayed;
        }

        public bool IsEnabled()
        {
            var logMessage = $"Checking if element '{_name}' is enabled";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            return _element.Enabled;
        }

        public bool IsSelected()
        {
            var logMessage = $"Checking if element '{_name}' is selected";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            return _element.Selected;
        }

        public string GetAttribute(string attributeName)
        {
            var logMessage = $"Getting attribute '{attributeName}' of element '{_name}'";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info });
            return _element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            var logMessage = $"Getting CSS value '{propertyName}' of element '{_name}'";
            logger.Info(logMessage);
            report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info });
            return _element.GetCssValue(propertyName);
        }

        public IWebElement GetWebElement()
        {
            return _element;
        }
    }
}
