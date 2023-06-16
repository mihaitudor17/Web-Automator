using Framework.Core;
using OpenCvSharp;
using OpenQA.Selenium;

namespace Framework.Utilities;

public static class ImageScanning
{
    public static (int, int) GetCoordinates(string smallImagePath)
    {
        IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(Constants.Screenshot, ScreenshotImageFormat.Png);
        var image = new Mat(Constants.Screenshot);
        var template = new Mat(smallImagePath);
        double minVal, maxVal;
        OpenCvSharp.Point minLoc, maxLoc;
        Mat result = new Mat();
        Cv2.MatchTemplate(image, template, result, TemplateMatchModes.CCoeffNormed);
        Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);
        return (maxLoc.X, maxLoc.Y);
    }

    public static void CropToSmallestSize(string imagePath)
    {
        Mat image = new Mat(imagePath, ImreadModes.Color);
        Mat grayImage = new Mat();
        Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
        Mat binaryImage = new Mat();
        Cv2.AdaptiveThreshold(grayImage, binaryImage, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 11, 2);
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchy;
        Cv2.FindContours(binaryImage, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
        double maxArea = 0;
        int maxAreaIndex = -1;
        for (int i = 0; i < contours.Length; i++)
        {
            double area = Cv2.ContourArea(contours[i]);
            if (area > maxArea)
            {
                maxArea = area;
                maxAreaIndex = i;
            }
        }
        if (maxAreaIndex >= 0)
        {
            Rect boundingRect = Cv2.BoundingRect(contours[maxAreaIndex]);
            Mat croppedImage = new Mat(image, boundingRect);
            string croppedImagePath = Path.Combine(Constants.Temp,Path.GetFileName(imagePath));
            croppedImage.SaveImage(croppedImagePath);
            image.Dispose();
            grayImage.Dispose();
            binaryImage.Dispose();
            croppedImage.Dispose();

            return;
        }
        image.Dispose();
        grayImage.Dispose();
        binaryImage.Dispose();
    }
}
