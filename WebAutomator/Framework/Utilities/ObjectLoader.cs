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

        public static List<Control> LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            if(files.Length >0) 
            {
                List<Control> objects = new List<Control>();
                files.ToList().ForEach(file => {
                    ObjectBuilder(file);
                    });
                return objects;
            }
            return null;
        }

        private static Control ObjectBuilder(string file)
        {
            var tempPath = ConfigurationManager.AppSettings["Temp"];
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            if (!FileHelper.FileExistsInFolder(file, ConfigurationManager.AppSettings["Temp"]))
                ImageScanning.CropToSmallestSize(file);
            var element = FindElement(ImageScanning.GetCoordinates(file));
            var name = FileHelper.GetNameFromFile(file);
            return new Control(element,name);
        }
    }
}
