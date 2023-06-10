using Framework.Core;
using OpenCvSharp;
using OpenQA.Selenium;

namespace Framework.Utilities;

public class ImageScanning
{
    public static (int, int) GetCoordinates(string smallImagePath)
    {
        IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        var image = new Mat("screenshot.png");
        var template = new Mat(smallImagePath);
        double minVal, maxVal;
        Point minLoc, maxLoc;
        Mat result = new Mat();
        Cv2.MatchTemplate(image, template, result, TemplateMatchModes.CCoeffNormed);
        Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);
        return (maxLoc.X, maxLoc.Y);
    }
}
