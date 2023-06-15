using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Button : Control
    {
        public Button(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
