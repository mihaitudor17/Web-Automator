using Framework.Core;
using Framework.Objects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities
{
    public static class ObjectLoader
    {
        static readonly List<IWebElement> webElements = new List<IWebElement>();

        static ObjectLoader()
        {
            webElements.AddRange(FrameworkInitializer.Instance.GetDriver().FindElements(By.XPath(@"//*")));
        }

        private static IWebElement FindElement((int,int)coordinates)
        {
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
            if (!FileHelper.FileExistsInFolder(file, tempPath))
                ImageScanning.CropToSmallestSize(file);
            var element = FindElement(ImageScanning.GetCoordinates(file));
            var name = Path.GetFileName(file);
            return new Control(element, name);
        }

        public static List<Control> LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly);
            if(files.Length >0) 
            {
                List<Control> objects = new List<Control>();
                files.ToList().ForEach(file => {
                    objects.Add(ObjectBuilder(file));
                    });
                return objects;
            }
            return null;
        }
    }
}
