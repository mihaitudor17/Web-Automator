using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Objects
{
    public class Control : WebElement
    {
        string name;
        public Control(WebDriver parentDriver, string id, string name) : base(parentDriver, id)
        {
            this.name = name;
        }
    }
}
