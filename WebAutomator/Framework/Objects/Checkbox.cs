using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Checkbox : Control
    {
        public Checkbox(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
