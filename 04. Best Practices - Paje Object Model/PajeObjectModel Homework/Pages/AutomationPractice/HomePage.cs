using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.AutomationPractice
{
    class HomePage : BasePage
    {
        private readonly By _signInButton = By.CssSelector(".login");

        public HomePage(IWebDriver driver) : base(driver) { }

        public SignInPage ClickSignIn()
        {
            ClickElement(_signInButton);
            return new SignInPage(Driver);
        }
    }
}
