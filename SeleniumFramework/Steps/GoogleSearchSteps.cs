using OpenQA.Selenium;
using SeleniumFramework.Pages;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Steps
{
    public class GoogleSearchSteps
    {
        private readonly GooglePage googlePage;
        private readonly IWebDriver driver;

        public GoogleSearchSteps()
        {
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

        [Then(@"Then The search results should contain the term Java")]
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