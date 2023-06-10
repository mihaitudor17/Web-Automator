using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Objects
{
    public class Control
    {
        string name;
        public Control(IWebElement element, string name)
        {
            Element = element;          
            this.name = name;
        }
        public IWebElement Element { get; set; }
        public string Name()
        {
            return name;
        }
    }
}
