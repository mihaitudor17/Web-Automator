using Framework.Core;
using System;
using TechTalk.SpecFlow;
using Testing.Drivers;

namespace Testing.Hooks
{
    [Binding]
    public class Hooks
    {
        [Given(@"I navigate to the website '(.*)'")]
        public void GivenINavigateToTheWebsite(string url)
        {
            FrameworkInitializer.Instance.NavigateToWebsite(url);
        }
    }
}