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
        [When(@"el usuario selecciona el tercer artículo")]
        public void WhenTheUserSelectsTheThirdItem()
        {
            mercadoLibrePage.PickThirdItem(); // Selecciona el tercer elemento en la página de resultados
        }
        [Then(@"después de hacer click para agregar el artículo al carrito, se le pide al usuario que inicie sesión o cree una cuenta")]
        public void ThenTheUserIsAbleToAddTheItemToTheCart()
        {

            mercadoLibrePage.AddToCard();
                                      //Assert.IsTrue(_mercadoPage.GetAddedToCartMessage().Contains("cantidad")); // Verifica que el mensaje de "añadido al carrito" esté presente
            Assert.IsTrue(mercadoLibrePage.GetMessageCreateAccount().Contains("¡Hola! Para agregar al carrito, ingresa a tu cuenta"));
        }
    }
}

// dotnet test --filter "TestCategory=MercadoLibre"