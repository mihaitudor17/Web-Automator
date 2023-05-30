using Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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

        private static IWebElement FindElement((Tuple<int,int>,Tuple<int,int>)coordinates)
        {
            int test2;
            foreach(var element in webElements)
            {
                if(element.Location.X+element.Size.Width>coordinates.Item1.Item1&& element.Location.X + element.Size.Width<coordinates.Item2.Item1)
                {
                    var test3 = element.Location;
                    test2 = 0;
                }
            //    var location = element.Location;
            //    int test;
            //    if (location.X != 0)
            //        test = 0;
            //    //return element;
            }
            var test = FrameworkInitializer.Instance.GetDriver().FindElement(By.XPath(@"//input[contains(@class,'_1K7ubH9z5v9E6C19j2fjQU')]"));
            var location = test.Location;
            var test1 = test.Size;
            return null;
        }

        public static void LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            if(files.Length >0) 
            {
                files.ToList().ForEach(file => {
                    var element = FindElement(ImageScanning.GetCoordinates(file));
                    var name = ItemType.GetNameFromFile(file);
                    });
            }
        }

        
    }
}
