using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace SeleniumFramework.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        // private readonly By searchBox = By.Id("APjFqb");
        private readonly By searchBox = By.Name("q");
        private readonly By searchButton = By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@name='btnK']");
        private readonly By elementosH3 = By.CssSelector("h3.LC20lb.MBeuO.DKV0Md");
        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
            // Inicializa WebDriverWait para esperas explícitas
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Metodo navegar a hacia google
        public void NavigateToGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void EnterSearchText(string searchText)
        {
            driver.FindElement(searchBox).SendKeys(searchText);
        }

        public void ClickSearchButton()
        {
            driver.FindElement(searchButton).Click();
        }
        public bool GetContainSubString()
        {
            // Espera hasta que los elementos H3 estén presentes en el DOM
            wait.Until(ExpectedConditions.ElementIsVisible(elementosH3));
            return driver.FindElements(elementosH3).FirstOrDefault()?.Text.Contains("Java") ?? false;
        }
    }
}

//dotnet test --filter "TestCategory=Google"