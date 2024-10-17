using OpenQA.Selenium;
using SeleniumFramework.Pages;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Steps
{

    [Binding]
    [Scope(Tag = "Google")]
    public class GoogleSearchSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private readonly GooglePage googlePage;


        public GoogleSearchSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)this.scenarioContext["WebDriver"]; // Obtiene el WebDriver del contexto
            googlePage = new GooglePage(driver);
        }

        [Given(@"I am on the google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            googlePage.NavigateToGoogle();
        }

        [When(@"I enter ""(.*)""")] //I enter "Java" 
        public void WhenEnter(string searchText)
        {
            googlePage.EnterSearchText(searchText);
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            googlePage.ClickSearchButton();
        }

        // The search results should contain the term Java
        [Then(@"The search results should contain the term Java")]
        public void ThenIShouldSeeSearchResults()
        {
            Assert.IsTrue(googlePage.GetContainSubString());
        }


    }
 
}

/*
 Feature: Característica
 Scenario: Escenario
 Given: Dado que / Que
 When: Cuando
 And: Y / Además
 Then: Entonces / Luego
 */