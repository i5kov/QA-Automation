using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.AutomationPractice
{
    public class CreateAccountPage : BasePage
    {
        private readonly By _email = By.Id("email");
        private readonly By _registerButton = By.Id("submitAccount");

        public CreateAccountPage(IWebDriver driver) : base(driver) { }

        public string GetEmailFieldValue()
        {
            WaitUntilElementExists(_registerButton, 15);
            return FindElement(_email).GetAttribute("value");
        }
    }
}