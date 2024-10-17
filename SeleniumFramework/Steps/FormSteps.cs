using OpenQA.Selenium;
using SeleniumFramework.Pages;
using TechTalk.SpecFlow;


namespace SeleniumFramework.Steps
{
    [Binding]
    [Scope(Tag = "Form")] // Aplica solo a escenarios con el tag MercadoLibre
    public class FormSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private readonly FormPage formPage;


        public FormSteps(ScenarioContext scenarioContex)
        {
            this.scenarioContext = scenarioContex;
            this.driver = (IWebDriver)scenarioContext["WebDriver"];
            this.formPage = new FormPage(driver);
        }

        [Given(@"el usuario navega al formulario")]
        public void GivenElUsuarioNavegaAlFormulario()
        {
            formPage.NavigateTo("https://seleniumtestweb.netlify.app/");
        }

        [When(@"el usuario ingresa ""(.*)"" en el campo de texto")]
        public void WhenElUsuarioIngresaEnElCampoDeTexto(string text)
        {
            formPage.EnterText(text);
        }

        [When(@"el usuario ingresa ""(.*)"" en el campo de correo electrónico")]
        public void WhenElUsuarioIngresaEnElCampoDeCorreoElectronico(string email)
        {
            formPage.EnterEmail(email);
        }

        [When(@"el usuario ingresa ""(.*)"" en el campo de contraseña")]
        public void WhenElUsuarioIngresaEnElCampoDeContrasena(string password)
        {
            formPage.EnterPassword(password);
        }

        [When(@"el usuario selecciona ""(.*)"" del desplegable")]
        public void WhenElUsuarioSeleccionaDelDesplegable(string value)
        {
            formPage.SelectOption(value);
        }

        [When(@"el usuario selecciona el radio button")]
        public void WhenElUsuarioSeleccionaElRadioButton()
        {
            formPage.SelectRadio1();
        }

        [When(@"el usuario marca el checkbox")]
        public void WhenElUsuarioMarcaElCheckbox()
        {
            formPage.SelectCheckbox1();
        }

        [When(@"el usuario envía el formulario")]
        public void WhenElUsuarioEnviaElFormulario()
        {
            formPage.SubmitForm();
        }

        [Then(@"el mensaje de error de correo inválido debe aparecer")]
        public void ThenElMensajeDeErrorDeCorreoInvalidoDebeAparecer()
        {
            // Aserciones usando NUnit directamente
            Assert.IsTrue(formPage.IsEmailInvalid(), "El correo electrónico debería ser inválido");
            Assert.IsTrue(formPage.IsEmailErrorMessageDisplayed(), "El mensaje de error debería mostrarse");
        }
    }
}
