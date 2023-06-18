using Framework.Core;
using Framework.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.DOM;

namespace Framework.Utilities
{
    public static class ObjectLoader
    {
        static readonly List<IWebElement> webElements = new List<IWebElement>();
        static readonly IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
        
        private static void AddObjects(string type="*")
        {
            webElements.Clear();
            webElements.AddRange(driver.FindElements(By.XPath(@$"//{type}")));
        }

        private static IWebElement FindElement((int,int)coordinates, string type)
        {
            AddObjects(type);
            foreach (var element in webElements)
            {
                if (coordinates.Item1 - element.Location.X < 10 && coordinates.Item2 - element.Location.Y < 10)
                {
                    return element;
                }
            }
            AddObjects();
            foreach(var element in webElements)
            {
                if (coordinates.Item1 - element.Location.X < 10 && coordinates.Item2 - element.Location.Y < 10)
                {
                    var children = element.FindElements(By.XPath("./*"));
                    var input = children.Where(child => child.TagName.ToLower().Contains("input")).FirstOrDefault();
                    List<IWebElement> divs = new List<IWebElement>();
                    divs.AddRange(children.Where(child => !child.TagName.ToLower().Contains("input")));
                    while (input == null && divs.Any())
                    {
                        children = divs.Last().FindElements(By.XPath("./*"));
                        input = children.Where(child => child.TagName.ToLower().Contains("input")).FirstOrDefault();
                        divs.RemoveAt(divs.Count - 1);
                        divs.AddRange(children.Where(child => !child.TagName.ToLower().Contains("input")));
                    }
                    if (children.Count() > 0 && input != null)
                    {
                        return input;
                    }
                    return element;
                }
            }
            return null;
        }

        private static Control ObjectBuilder(IWebElement element, string name, string type)
        {
            switch (type.ToLower())
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
                case "textarea":
                    return new TextArea(element, name);
            }
            return null;
        }

        public static Control LoadObject(string imagePath)
        {
            var tempPath = Constants.Temp;
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            if (!FileHelper.FileExistsInTemp(imagePath, tempPath))
                ImageScanning.CropToSmallestSize(imagePath);
            var type = FileHelper.GetTypeFromFile(imagePath);
            var element = FindElement(ImageScanning.GetCoordinates(imagePath), elementTypes[type.ToLower()]);
            var name = FileHelper.GetNameFromFile(imagePath);
            return ObjectBuilder(element, name, type);
        }

        public static Control LoadObject(string searchText, string name, string type)
        {
            var element = driver.FindElement(By.XPath(@$"//*[text()='{searchText}']"));
            return ObjectBuilder(element, name, type);
        }

        private static Dictionary<string, string> elementTypes = new Dictionary<string, string>()
        {
            {"button","button"},
            {"checkbox", "input"},
            {"image", "img" },
            {"label","label" },
            {"textarea","input" },
            {"select","select" }
        };
    }
}
