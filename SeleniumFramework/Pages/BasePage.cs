using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        protected Actions actions; // Instancia de Actions a nivel de clase

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver); // Inicializar Actions una vez
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
            IWebElement element = FindElement(locator);
            // Desplazar al centro antes de intentar el clic
            ScrollToElementCenter(locator);
            try
            {
                Console.WriteLine("Intentando hacer click con Actions..."); // Registro de intento con Actions
                actions.MoveToElement(element).Click().Perform(); // Usar Actions para hacer click
                Console.WriteLine("Click realizado con Actions.");
            }
            catch (ElementClickInterceptedException)
            {
                Console.WriteLine("Clic con Actions fallido, intentando con scroll..."); // Registro de intento de scroll
                ScrollToElement(locator); // Desplazar si es necesario
                FindElement(locator).Click(); // Intentar el clic nuevamente
                Console.WriteLine("Clic realizado después del scroll.");
            }

            /*
             El try: Intenta hacer clic en el elemento usando un método más confiable (Actions). 
             Si el clic es exitoso, la ejecución continúa sin problemas.
             El catch: Si ocurre la excepción ElementClickInterceptedException, 
             el bloque de catch toma el control. 
             En lugar de solo mostrar un mensaje de error, se hace un nuevo 
             intento después de desplazarse al elemento para asegurarse
             de que esté completamente visible y clicable.


            ¿Por qué no lanzar un mensaje de error directamente en el catch?
             El objetivo del catch en este caso es intentar recuperar la acción fallida (hacer clic en el elemento) 
             antes de considerar la prueba como fallida. En las pruebas de UI con Selenium, 
             este enfoque es común para hacerlas más robustas y menos propensas a fallar por 
             condiciones transitorias o problemas de sincronización de la página.
             */
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

        // Método para desplazar al elemento
        public void ScrollToElement(By locator)
        {
            IWebElement element = FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        // Desplazar hacia el centro del elemento
        public void ScrollToElementCenter(By locator)
        {
            IWebElement element = FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }

    }
}