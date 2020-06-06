using NUnit.Framework;
using PajeObjectModel_Homework.Pages.AutomationPractice;
using System;

namespace PajeObjectModel_Homework.Tests.AutomationPractice
{
    class AutomationPracticeTests : BaseTest
    {
        private string _email;
        private HomePage _homePage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.AutomationPracticeSite);
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000);
            _email = $"random_test_mail_{randomInt}@test.test";
            _homePage = new HomePage(Driver);
        }

        [Test]
        public void Verify_Email_When_TryToCreateANewAccount()
        {
            CreateAccountPage createAccountPage = NavigateToCreateAccount();

            Assert.AreEqual(_email, createAccountPage.GetEmailFieldValue());
        }

        [Test]
        [TestCase("",              "Test LastName","Test Password","Test Address","Test City","firstname is required.")]
        [TestCase("Test FirstName","",             "Test Password","Test Address","Test City","lastname is required.")]
        [TestCase("Test FirstName","Test LastName","",             "Test Address","Test City","passwd is required.")]
        [TestCase("Test FirstName","Test LastName","Test Password","",            "Test City","address1 is required.")]
        [TestCase("Test FirstName","Test LastName","Test Password","Test Address","",         "city is required.")]
        public void Verify_Required_Fields(string firstName, string lastName, string password, string address, string city, string errorMessage)
        {
            string expectedError = errorMessage;

            CreateAccountPage createAccountPage = NavigateToCreateAccount();
            createAccountPage.FillOutAllRequiredFieldsAndSubmit(
                    firstName, lastName, password, address, city, "California", "00000", "1234567890");

            Assert.IsTrue(createAccountPage.ErrorIsVisible);
            Assert.AreEqual(expectedError, createAccountPage.ErrorMessageText);
        }

        private CreateAccountPage NavigateToCreateAccount()
        {
            var signInPage = _homePage.ClickSignIn();
            CreateAccountPage createAccountPage = signInPage.CreateAccount(_email);
            return createAccountPage;
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
