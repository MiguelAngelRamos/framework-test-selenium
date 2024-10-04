using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver driver;

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Metodo navegar a hacia google
        public void NavigateToGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }
    }
}
