using Framework.Core;
using Framework.Logging;
using Framework.Objects;
using iText.Layout.Splitting;
using OpenQA.Selenium;
using Testing.Drivers;
using Testing.Utils;
using Xunit;

namespace Testing.Steps;

[Binding]
public sealed class StepDefinitions
{
    private readonly IWebDriver driver = FrameworkInitializer.Instance.GetDriver();
    private Control GetObject(string name) => FrameworkInitializer.Instance.GetObject(FileDictionary.FileDict[name]);
    private Control GetObject(string searchText, string name, string type) => FrameworkInitializer.Instance.GetObject(searchText, name, type);

    [When(@"I signup into the website with the following '([^']*)' email and '([^']*)' password")]
    public void LogIntoTheWebsiteWithUserAndPassword(string email)
    {
        GetObject("LoginAccess").Click();
        GetObject("Sign up", "Signup", "Label").Click();
        GetObject("Email").SendKeys(email);
        GetObject("Continue").Click();
        
    }

    [When(@"I change tab to '([^']*)'")]
    public void ChangeTabTo(string tabName)
    {
        List<string> windowHandles = new List<string>(driver.WindowHandles);
        foreach(var handle in windowHandles)
        {
            driver.SwitchTo().Window(handle);
            if(driver.Title.Contains(tabName))
            {
                break;
            }
        }
    }

    [When(@"I press the button with name '([^']*)' with the next settings:")]
    public void PressTheButtonWithNameImage(string name, Table table)
    {
        var element = table.Rows.First()[table.Header.First()].ToLower().Contains("image") ? GetObject(name) : GetObject(name, $"Button_{name}", "Button");
        if (table.Rows.First()[table.Header.Last()].ToLower().Contains("true"))
        {
            element.ClickByLocation();
        }
        else
        {
            element.Click();
        }
    }

    [When(@"I wait (\d+) seconds")]
    public void WaitSeconds(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }

    [When(@"I send '([^']*)' to the '([^']*)' textarea")]
    public void SendToTheTextarea(string text, string name)
    {
        var textArea = GetObject(name);
        textArea.SendKeys(text);
    }

    [Then(@"URL contains '([^']*)'")]
    public void URLContains(string url)
    {
        Assert.True(driver.Url.Contains(url));
    }

}