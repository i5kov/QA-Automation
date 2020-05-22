using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumAdvancedHomework
{
    public class AutomationPracticeRegistrationNegativeTests : Utils
    {
        private readonly By _firstName = By.Id("customer_firstname");
        private readonly By _lastName = By.Id("customer_lastname");
        private readonly By _password = By.Id("passwd");
        private readonly By _address = By.Id("address1");
        private readonly By _city = By.Id("city");
        private readonly By _state = By.Id("id_state");
        private readonly By _postCode = By.Id("postcode");
        private readonly By _mobilePhone = By.Id("phone_mobile");
        private readonly By _registerButton = By.Id("submitAccount");
        private readonly By _errorMessageField = By.CssSelector(".alert-danger");
        private readonly By _errorMessages = By.CssSelector("ol li");

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            MaximizeBrowserWindow();
            NavigateToRegistrationPageWithEmail("123@test.bg");
        }

        [Test]
        public void Verify_FirstName_Is_Required()
        {
            FillInRegisterFormRequiredFields("", "LastName", "Password123", "AddressTest", 
                                             "CityTest", "California", "12345", "088123123");
            int expectedErrorMessagesCount = 1;
            int actualErrorMessagesCount = FindElements(_errorMessages).Count;

            string expectedErrorText = "firstname is required.";
            string actualErrorText = FindElement(_errorMessages).Text;
           
            Assert.IsTrue(FindElement(_errorMessageField).Displayed);
            Assert.AreEqual(expectedErrorMessagesCount, actualErrorMessagesCount);
            Assert.AreEqual(expectedErrorText, actualErrorText);
        }

        public void Verify_FirstName_Is_Required_When_FirstName_Not_Filled()
        {
            FillInRegisterFormRequiredFields("", "LastName", "Password123", "AddressTest",
                                             "CityTest", "California", "12345", "088123123");
            int expectedErrorMessagesCount = 1;
            int actualErrorMessagesCount = FindElements(_errorMessages).Count;

            string expectedErrorText = "firstname is required.";
            string actualErrorText = FindElement(_errorMessages).Text;

            Assert.IsTrue(FindElement(_errorMessageField).Displayed);
            Assert.AreEqual(expectedErrorMessagesCount, actualErrorMessagesCount);
            Assert.AreEqual(expectedErrorText, actualErrorText);
        }

        [Test]
        public void Verify_LastName_Is_Required_When_LastName_Not_Filled()
        {
            FillInRegisterFormRequiredFields("FirstName", "", "Password123", "AddressTest",
                                             "CityTest", "California", "12345", "088123123");
            int expectedErrorMessagesCount = 1;
            int actualErrorMessagesCount = FindElements(_errorMessages).Count;

            string expectedErrorText = "lastname is required.";
            string actualErrorText = FindElement(_errorMessages).Text;

            Assert.IsTrue(FindElement(_errorMessageField).Displayed);
            Assert.AreEqual(expectedErrorMessagesCount, actualErrorMessagesCount);
            Assert.AreEqual(expectedErrorText, actualErrorText);
        }

        [Test]
        public void Verify_RequiredFields_Are_Required_When_All_ReuqiredFields_Not_Filled()
        {
            FillInRegisterFormRequiredFields("", "", "", "", "", "-", "", "");
            int expectedErrorMessagesCount = 8;
            int actualErrorMessagesCount = FindElements(_errorMessages).Count;

            List<string> expectedErrorMessages = new List<string>
            {
                "You must register at least one phone number.",
                "lastname is required.",
                "firstname is required.",
                "passwd is required.",
                "address1 is required.",
                "city is required.",
                "The Zip/Postal code you've entered is invalid. It must follow this format: 00000",
                "This country requires you to choose a State."
            };
            IList<IWebElement> actualErrorMessages = FindElements(_errorMessages);

            Assert.IsTrue(FindElement(_errorMessageField).Displayed);
            Assert.AreEqual(expectedErrorMessagesCount, actualErrorMessagesCount);
            for (int i = 0; i < actualErrorMessages.Count; i++)
            {
                string expectedError = expectedErrorMessages[i];
                string actualError = actualErrorMessages[i].Text;
                Assert.AreEqual(expectedError, actualError, $"{expectedError} is not equal to {actualError}");
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        private void FillInRegisterFormRequiredFields(string fname, string lname, string password, string address,
                                                     string city, string state, string postCode, string mobilePhone)
        {
            WaitForElement(_registerButton, 20);
            FindElementAndFillText(_firstName, fname);
            FindElementAndFillText(_lastName, lname);
            FindElementAndFillText(_password, password);
            FindElementAndFillText(_address, address);
            FindElementAndFillText(_city, city);
            SelectFromDropdownByText(FindElement(_state), state);
            FindElementAndFillText(_postCode, postCode);
            FindElementAndFillText(_mobilePhone, mobilePhone);
            FindElementAndClick(_registerButton);
        }
    }
}