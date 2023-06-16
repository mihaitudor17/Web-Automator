using Framework.Objects;
using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Core;
public sealed class FrameworkInitializer
{
    private static readonly FrameworkInitializer instance = new FrameworkInitializer();
    private IWebDriver driver;
    private FrameworkInitializer()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
        options.AddArguments("--incognito");
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalChromeOption("useAutomationExtension", false);
        driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
    }

    public static FrameworkInitializer Instance
    {
        get { return instance; }
    }

    public IWebDriver GetDriver()
    {
        return driver;
    }

    public void Close()
    {
        driver.Quit();
    }
    
    public void NavigateToWebsite(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public Control GetObject(string imagePath)
    {
        return ObjectLoader.LoadImage(imagePath);
    }
}