using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class MercadoLibrePage : BasePage
    {
        private readonly By searchBox = By.Name("as_word");
        private readonly By searchButton = By.CssSelector("button.nav-search-btn");
        private readonly By thirdResult = By.XPath("//li[3]//h2/a");
        private readonly By addCartButton = By.CssSelector("button[id=':R2aqakck4um:'] span[class='andes-button__content']");
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

        public void PickThirdItem()
        {
            ClickElement(thirdResult);
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