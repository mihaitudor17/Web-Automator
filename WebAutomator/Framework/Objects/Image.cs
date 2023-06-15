using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Image : Control
    {
        public Image(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
