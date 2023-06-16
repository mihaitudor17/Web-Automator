using Framework.Core;
using Framework.Utilities;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OpenQA.Selenium;

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

        public void GenerateReport(string scenarioTitle)
        {
            var machineName = Environment.MachineName;
            var osVersion = $"{Environment.OSVersion.Platform} {Environment.OSVersion.Version}";
            var process = Environment.ProcessId.ToString();
            var currentUrl = FrameworkInitializer.Instance.GetDriver().Url;
            var uri = new Uri(currentUrl);
            var baseUri = $"{uri.Scheme}://{uri.Host}{uri.AbsolutePath}";

            PdfDocument document = new PdfDocument(new PdfWriter(_reportFilePath));
            Document layoutDocument = new Document(document);
            Paragraph machineNameParagraph = new Paragraph($"Machine Name: {machineName}");
            layoutDocument.Add(machineNameParagraph);
            Paragraph osVersionParagraph = new Paragraph($"Operating System: {osVersion}");
            layoutDocument.Add(osVersionParagraph);
            Paragraph dateParagraph = new Paragraph($"Date and time: {DateTime.Now}");
            layoutDocument.Add(dateParagraph);
            Paragraph processNameParagraph = new Paragraph()
                .Add("Website Name: ")
                .Add(new Text($"{baseUri}")
                    .SetFontColor(ColorConstants.BLUE)
                    .SetUnderline());
            layoutDocument.Add(processNameParagraph);
            Paragraph logParagraph = new Paragraph($"{scenarioTitle}");
            logParagraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            logParagraph.SetBold();
            logParagraph.SetFontSize(16);
            layoutDocument.Add(logParagraph);

            foreach (var logEvent in _logEvents)
            {
                string logMessage = logEvent.Message;
                NLog.LogLevel logLevel = logEvent.Level;
                byte[] screenshot = logEvent.Screenshot;
                string formattedLog = $"[{logLevel.Name}] {logMessage}";

                Div logEntryContainer = new Div();
                Paragraph logEntryParagraph = new Paragraph(formattedLog);
                logEntryContainer.SetKeepTogether(true);
                logEntryContainer.Add(logEntryParagraph);
                if (screenshot != null)
                {
                    var pageWidth = layoutDocument.GetPdfDocument().GetDefaultPageSize().GetWidth() - 100;
                    Image screenshotImage = new Image(ImageDataFactory.Create(screenshot));
                    screenshotImage.ScaleToFit(pageWidth,screenshotImage.GetImageHeight() * (pageWidth/screenshotImage.GetImageWidth()));
                    logEntryContainer.Add(screenshotImage);
                }
                layoutDocument.Add(logEntryContainer);
            }
            layoutDocument.Close();
            document.Close();
        }

    }
}
