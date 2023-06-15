using OpenQA.Selenium;

namespace Framework.Objects
{
    public class Table : Control
    {
        public Table(IWebElement element, string name) : base(element, name)
        {
        }
    }
}
