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