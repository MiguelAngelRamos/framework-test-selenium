using OpenQA.Selenium;
using SeleniumFramework.Pages;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Steps
{
    [Binding]
    [Scope(Tag = "MercadoLibre")]
    public class MercadoLibreSearchSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private readonly MercadoLibrePage mercadoLibrePage;

        public MercadoLibreSearchSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driver = (IWebDriver)scenarioContext["WebDriver"];
            this.mercadoLibrePage = new MercadoLibrePage(this.driver);

        }

        // Hacer los pasos del Gherkin

        [Given(@"el usuario navega a www.mercadolibre.cl")]
        public void GivenTheUserNavigatesToMercadoLibre()
        {
            mercadoLibrePage.NavigateToMercadoLibre();
        }
        [When(@"el usuario busca ""(.*)""")]
        public void WhenTheUserSearchesFor(string searchText)
        {
            mercadoLibrePage.EnterSearchCriteria(searchText); // Ingresa el término de búsqueda
            mercadoLibrePage.ClickSearchButton(); // Haz clic en el botón de búsqueda
        }
        [When(@"el usuario selecciona el segundo artículo")]
        public void WhenTheUserSelectsTheThirdItem()
        {
            mercadoLibrePage.PickSecondItem(); // Selecciona el tercer elemento en la página de resultados
        }
        [Then(@"después de hacer click para agregar el artículo al carrito, se le pide al usuario que inicie sesión o cree una cuenta")]
        public void ThenTheUserIsAbleToAddTheItemToTheCart()
        {
            mercadoLibrePage.AddToCard();

            // Obtiene el mensaje que aparece en la página
            var actualMessage = mercadoLibrePage.GetMessageCreateAccount();

            // Verifica si el mensaje recibido es uno de los dos posibles
            bool isExpectedMessage = actualMessage.Contains("¡Hola! Para agregar al carrito, ingresa a tu cuenta") ||
                                     actualMessage.Contains("¡Hola! Para comprar, ingresa a tu cuenta");

            Assert.IsTrue(isExpectedMessage, $"El mensaje recibido fue: '{actualMessage}', pero se esperaba '¡Hola! Para agregar al carrito, ingresa a tu cuenta' o '¡Hola! Para comprar, ingresa a tu cuenta'.");
        }

    }
}

// dotnet test --filter "TestCategory=MercadoLibre"