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
    }
}

// dotnet test --filter "TestCategory=MercadoLibre"