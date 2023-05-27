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
        options.AddArgument("--incognito");
        driver = new ChromeDriver(options);
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
        // Navigate to the specified URL
        driver.Navigate().GoToUrl(url);
    }
}