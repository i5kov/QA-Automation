using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.AutomationPractice
{
    public class CreateAccountPage : BasePage
    {
        private readonly By _email = By.Id("email");
        private readonly By _registerButton = By.Id("submitAccount");
        private readonly By _firstName = By.Id("customer_firstname");
        private readonly By _lastName = By.Id("customer_lastname");
        private readonly By _password = By.Id("passwd");
        private readonly By _address = By.Id("address1");
        private readonly By _city = By.Id("city");
        private readonly By _state = By.Id("id_state");
        private readonly By _zip = By.Id("postcode");
        private readonly By _mobilePhone = By.Id("phone_mobile");
        private readonly By _errorMessageField = By.CssSelector(".alert-danger");
        private readonly By _errorMessageText = By.CssSelector("ol li");

        public bool ErrorIsVisible 
        {
            get 
            {
                return FindElement(_errorMessageField).Displayed;
            }
        }

        public string ErrorMessageText
        {
            get
            {
                return FindElement(_errorMessageText).Text;
            }
        }

        public CreateAccountPage(IWebDriver driver) : base(driver) { }

        public string GetEmailFieldValue()
        {
            WaitUntilElementExists(_registerButton, 20);
            return FindElement(_email).GetAttribute("value");
        }

        public void FillOutAllRequiredFieldsAndSubmit(string firstName, string lastName, string password, string address, string city, string state, string zip, string mobilePhone)
        {
            WaitUntilElementExists(_firstName, 20);
            FindElementAndTypeText(_firstName, firstName);
            FindElementAndTypeText(_lastName, lastName);
            FindElementAndTypeText(_password, password);
            FindElementAndTypeText(_address, address);
            FindElementAndTypeText(_city, city);
            SelectFromDropdownByText(FindElement(_state), state);
            FindElementAndTypeText(_zip, zip);
            FindElementAndTypeText(_mobilePhone, mobilePhone);
            ClickElement(_registerButton);
        }
    }
}