using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumFramework.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {
            // ChromeOptions options = new ChromeOptions();
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            return new ChromeDriver(options);
        }


    }
}
