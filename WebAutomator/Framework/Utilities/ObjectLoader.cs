using Framework.Core;
using Framework.Objects;
using OpenQA.Selenium;

namespace Framework.Utilities
{
    public static class ObjectLoader
    {
        static readonly List<IWebElement> webElements = new List<IWebElement>();
        static readonly IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        
        private static void AddObjects()
        {
            webElements.Clear();
            webElements.AddRange(driver.FindElements(By.XPath(@"//*")));
        }

        private static IWebElement FindElement((int,int)coordinates)
        {
            AddObjects();
            foreach (var element in webElements)
            {
                if (coordinates.Item1 - element.Location.X < 10 && coordinates.Item2 - element.Location.Y < 10)
                {
                    return element;
                }
            }
            return null;
        }

        private static Control ObjectBuilder(string file)
        {
            var tempPath = Constants.Temp;
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            if (!FileHelper.FileExistsInTemp(file, tempPath))
                ImageScanning.CropToSmallestSize(file);
            var element = FindElement(ImageScanning.GetCoordinates(file));
            var name = FileHelper.GetNameFromFile(file);
            switch (FileHelper.GetTypeFromFile(file).ToLower())
            {
                case "button":
                    return new Button(element, name);
                case "checkbox":
                    return new Checkbox(element, name);
                case "image":
                    return new Image(element, name);
                case "label":
                    return new Label(element, name);
                case "select":
                    return new Select(element, name);
                case "table":
                    return new Table(element, name);
                case "textarea":
                    return new TextArea(element, name);
            }
            return null;
        }

        public static Control LoadImage(string imagePath)
        {
            return ObjectBuilder(imagePath);
        }
    }
}
