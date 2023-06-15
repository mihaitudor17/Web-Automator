using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Label : Control
    {
        public Label(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
