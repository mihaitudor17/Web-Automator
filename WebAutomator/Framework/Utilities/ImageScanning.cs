using Framework.Core;
using OpenCvSharp;
using OpenQA.Selenium;
namespace Framework.Utilities;
using System;
public static class ImageScanning
{
    public static (Tuple<int, int>, Tuple<int, int>) GetCoordinates(string imagePath)
    {
        string screenshotBase64 = ((ITakesScreenshot)FrameworkInitializer.Instance.GetDriver()).GetScreenshot().AsBase64EncodedString;
        byte[] screenshotBytes = Convert.FromBase64String(screenshotBase64);
        var stream = new System.IO.MemoryStream(screenshotBytes);
        Mat largerImage = Cv2.ImDecode(stream.ToArray(), ImreadModes.Grayscale);
        Mat smallerImage = new Mat(imagePath, ImreadModes.Grayscale);
        Mat result = new Mat();
        Cv2.MatchTemplate(largerImage, smallerImage, result, TemplateMatchModes.CCoeffNormed);
        Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out OpenCvSharp.Point maxLoc);
        int topLeftX = maxLoc.X;
        int topLeftY = maxLoc.Y;
        int bottomRightX = topLeftX + smallerImage.Width;
        int bottomRightY = topLeftY + smallerImage.Height;
        Tuple<int, int> topLeftCoordinates = Tuple.Create(topLeftX, topLeftY);
        Tuple<int, int> bottomRightCoordinates = Tuple.Create(bottomRightX, bottomRightY);
        return (topLeftCoordinates, bottomRightCoordinates);
    }
}