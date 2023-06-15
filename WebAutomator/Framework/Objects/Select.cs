using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Select : Control
    {
        public Select(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
