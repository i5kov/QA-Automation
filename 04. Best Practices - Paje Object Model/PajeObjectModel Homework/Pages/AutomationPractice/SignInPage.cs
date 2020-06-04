using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.AutomationPractice
{
    public class SignInPage : BasePage
    {
        private readonly By _emailFieldForCreateAccount = By.Id("email_create");
        private readonly By _createAccountButton = By.Id("SubmitCreate");

        public SignInPage(IWebDriver driver) : base(driver) { }

        public CreateAccountPage CreateAccount(string email)
        {
            WaitUntilElementExists(_emailFieldForCreateAccount, 15).SendKeys(email);
            ClickElement(_createAccountButton);
            return new CreateAccountPage(Driver);
        }
    }
}