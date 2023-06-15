using Framework.Core;
using Framework.Utilities;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Framework.Logging
{
    public class ReportGenerator
    {
        private static ReportGenerator _instance;
        private readonly string _reportFilePath;
        private readonly List<CustomLogEventInfo> _logEvents;

        private ReportGenerator(string reportFilePath)
        {
            _reportFilePath = reportFilePath;
            _logEvents = new List<CustomLogEventInfo>();
        }

        public static ReportGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportGenerator(Path.Combine(Constants.Temp,Constants.Report));
                }
                return _instance;
            }
        }

        public void AddLogEvent(CustomLogEventInfo logEvent, bool capture = false)
        {
            if (capture)
            {
                ITakesScreenshot screenshotDriver = FrameworkInitializer.Instance.GetDriver() as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                byte[] screenshotAsByteArray = screenshot.AsByteArray;
                logEvent.Screenshot = screenshotAsByteArray;
            }

            _logEvents.Add(logEvent);
        }

        public void GenerateReport()
        {
            PdfDocument document = new PdfDocument(new PdfWriter(_reportFilePath));
            Document layoutDocument = new Document(document);
            Paragraph logParagraph = new Paragraph("Log Information:");
            layoutDocument.Add(logParagraph);

            foreach (var logEvent in _logEvents)
            {
                string logMessage = logEvent.Message;
                NLog.LogLevel logLevel = logEvent.Level;
                byte[] screenshot = logEvent.Screenshot;
                string formattedLog = $"[{logLevel.Name}] {logMessage}";
                Div logEntryContainer = new Div();
                Paragraph logEntryParagraph = new Paragraph(formattedLog);
                logEntryContainer.Add(logEntryParagraph);

                if (screenshot != null)
                {
                    Image screenshotImage = new Image(ImageDataFactory.Create(screenshot));
                    logEntryContainer.Add(screenshotImage);
                }

                layoutDocument.Add(logEntryContainer);
            }
            layoutDocument.Close();
            document.Close();
        }
    }
}
