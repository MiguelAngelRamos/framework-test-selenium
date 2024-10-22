using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class MercadoLibrePage : BasePage
    {
        private readonly By searchBox = By.Name("as_word");
        private readonly By searchButton = By.CssSelector("button.nav-search-btn");
        private readonly By secondResult = By.XPath("//li[2]//h2/a");
        private readonly By addCartButton = By.XPath("//*[@id=':R16qakck4um:']");
        
        private readonly By messageRegisterAccount = By.CssSelector(".center-card__title");
        // private readonly By addCartButton = By.Id(":R2aqakck4um:");
        // center-card__title

        public MercadoLibrePage(IWebDriver driver) : base(driver) { }


        public void NavigateToMercadoLibre()
        {
            NavigateTo("https://www.mercadolibre.cl/");
        }

        public void EnterSearchCriteria(string criteria)
        {
            Write(searchBox, criteria);
        }

        public void ClickSearchButton()
        {
            ClickElement(searchButton);
        }

        public void PickSecondItem()
        {
            ClickElement(secondResult);
        }

        public void AddToCard()
        {
            ClickElement(addCartButton);
        }

        public string GetMessageCreateAccount()
        {
            return GetTextFromElement(messageRegisterAccount);
        }
    }
}