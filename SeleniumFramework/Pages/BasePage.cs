using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Metodo navegar a cualquier sitio
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // Cerrar el Navegador
        public void CloseBrowser()
        {
            driver.Quit();
        }

        // Para buscar un elemento html
        public IWebElement FindElement(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Para realizar click en elementos (button, input)
        public void ClickElement(By locator)
        {
            FindElement(locator).Click();
        }

        // Para poder escribir un elemento
        public void Write(By locator, string textToWrite)
        {
            // var element = FindElement(locator);
            IWebElement element = FindElement(locator);
            element.Clear();
            element.SendKeys(textToWrite);

        }

        // Para elementos que son Visibles por condición
        public bool ElementIsDisplayed(By locator)
        {
            return FindElement(locator).Displayed;
        }

        public string GetTextFromElement(By locator)
        {
            return FindElement(locator).Text;
        }

        // Metodo Obtener valor del select 
        public void SelectFromDropdownByValue(By locator, string value)
        {
            var dropdown = new SelectElement(FindElement(locator));
            dropdown.SelectByValue(value);
        }

        // Método para verificar si un elemento tiene la clase 'is-invalid' - las pruebas de formulario con bootstrap 5
        public bool ElementHasInvalidClassBootstrap5(By locator)
        {
            // Esta es la línea nueva agregada de Pruebadeformato invalido
            return FindElement(locator).GetAttribute("class").Contains("is-invalid");
        }

    }
}