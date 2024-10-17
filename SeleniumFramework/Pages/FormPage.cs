using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class FormPage : BasePage
    {
        private readonly By inputText = By.Id("input-texto");
        private readonly By inputEmail = By.Id("input-email");
        private readonly By inputPassword = By.Id("input-password");
        private readonly By selectOptions = By.Id("select-opciones");
        private readonly By radio1 = By.Id("radio1");
        private readonly By checkbox1 = By.Id("checkbox1");
        private readonly By buttonSubmit = By.Id("boton-enviar");
        private readonly By emailErrorMessage = By.XPath("//div[@class='invalid-feedback' and contains(text(),'Por favor, ingresa un correo electrónico válido (nombre@organizacion.dominio)')]");

        public FormPage(IWebDriver driver) : base(driver) { }

        // Métodos para interactuar con los elementos de la página
        public void EnterText(string text)
        {
            Write(inputText, text);
        }

        public void EnterEmail(string email)
        {
            Write(inputEmail, email);
        }

        public void EnterPassword(string password)
        {
            Write(inputPassword, password);
        }

        public void SelectOption(string value)
        {
            SelectFromDropdownByValue(selectOptions, value);
        }

        public void SelectRadio1()
        {
            ClickElement(radio1);
        }

        public void SelectCheckbox1()
        {
            ClickElement(checkbox1);
        }

        public void SubmitForm()
        {
            ClickElement(buttonSubmit);
        }

        // Método para verificar si el mensaje de error está visible
        public bool IsEmailInvalid()
        {
            return ElementHasInvalidClassBootstrap5(inputEmail);
        }

        public bool IsEmailErrorMessageDisplayed()
        {
            return ElementIsDisplayed(emailErrorMessage);
        }
    }
}
