using Framework.Core;
using Framework.Logging;
using iText.StyledXmlParser.Jsoup.Nodes;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private static TimeSpan defaultTimeout = TimeSpan.FromSeconds(3);
        protected Control(IWebElement element, string name)
        {
            _element = element;
            _name = name;
        }

        public string Name => _name;

        public void Click()
        {
            var logMessage = $"Clicking on element '{_name}'";
            try
            {
                _element.Click();
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public void ClickByLocation()
        {
            var logMessage = $"Clicking on element '{_name}' on location {_element.Location}'";
            try
            {
                logger.Info(logMessage);
                Actions actions = new Actions(driver);
                actions.MoveToElement(_element);
                actions.Click();
                actions.Perform();
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public void SendKeys(string text)
        {
            var logMessage = $"Sending keys '{text}' to element '{_name}'";
            try
            {
                logger.Info(logMessage);
                _element.SendKeys(text);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public void WaitUntilVisible(TimeSpan timeout = default)
        {
            try
            {
                if (timeout == default)
                    timeout = defaultTimeout;
                var wait = new WebDriverWait(driver, timeout);
                wait.Until(driver => _element.Displayed);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"Waiting failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public void WaitUntilEnabled(TimeSpan timeout = default)
        {
            try
            {
                if (timeout == default)
                    timeout = defaultTimeout;
                var wait = new WebDriverWait(driver, timeout);
                wait.Until(driver => _element.Enabled);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"Waiting failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public bool IsDisplayed()
        {
            var logMessage = $"Checking if element '{_name}' is displayed";
            try
            {
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
                return _element.Displayed;
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public bool IsEnabled()
        {
            var logMessage = $"Checking if element '{_name}' is enabled";
            try
            {
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
                return _element.Enabled;
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public bool IsSelected()
        {
            var logMessage = $"Checking if element '{_name}' is selected";
            try
            {
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info }, capture: true);
                return _element.Selected;
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public string GetAttribute(string attributeName)
        {
            var logMessage = $"Getting attribute '{attributeName}' of element '{_name}'";
            try
            {
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info });
                return _element.GetAttribute(attributeName);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public string GetCssValue(string propertyName)
        {
            var logMessage = $"Getting CSS value '{propertyName}' of element '{_name}'";
            try
            {
                logger.Info(logMessage);
                report.AddLogEvent(new CustomLogEventInfo { Message = logMessage, Level = NLog.LogLevel.Info });
                return _element.GetCssValue(propertyName);
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"{logMessage} failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }

        public IWebElement GetWebElement()
        {
            try
            {
                return _element;
            }
            catch (Exception ex)
            {
                report.AddLogEvent(new CustomLogEventInfo { Message = $"Getting the element failed because '{ex.Message}'", Level = NLog.LogLevel.Error }, capture: true);
                ReportGenerator.Instance.GenerateReport();
                throw;
            }
        }
    }
}
