using Framework.Core;
using OpenCvSharp;
using OpenQA.Selenium;
using System.Drawing;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Configuration;

namespace Framework.Utilities;

public static class ImageScanning
{
    public static (int, int) GetCoordinates(string smallImagePath)
    {
        IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        var image = new Mat("screenshot.png");
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
        Bitmap originalImage = new Bitmap(imagePath);
        Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
        Bitmap grayscaleImage = filter.Apply(originalImage);
        Threshold thresholdFilter = new Threshold(128);
        Bitmap binaryImage = thresholdFilter.Apply(grayscaleImage);
        BlobCounter blobCounter = new BlobCounter();
        blobCounter.FilterBlobs = true;
        blobCounter.MinWidth = 10;
        blobCounter.MinHeight = 10; 
        blobCounter.CoupledSizeFiltering = true;
        blobCounter.ProcessImage(binaryImage);
        Blob[] blobs = blobCounter.GetObjectsInformation();
        if (blobs.Length == 0)
        {
            originalImage.Save(imagePath);
            return;
        }
        Blob largestBlob = blobs[0];
        for (int i = 1; i < blobs.Length; i++)
        {
            if (blobs[i].Area > largestBlob.Area)
            {
                largestBlob = blobs[i];
            }
        }
        Rectangle cropRectangle = largestBlob.Rectangle;
        int expansionFactor = 2;
        cropRectangle.Inflate(cropRectangle.Width * expansionFactor, cropRectangle.Height * expansionFactor);
        cropRectangle.Intersect(new Rectangle(0, 0, originalImage.Width, originalImage.Height));
        Crop cropFilter = new Crop(cropRectangle);
        Bitmap croppedImage = cropFilter.Apply(originalImage);
        croppedImage.Save(ConfigurationManager.AppSettings["Temp"] + FileHelper.GetNameFromFile(imagePath));
        originalImage.Dispose();
        croppedImage.Dispose();
    }
}
