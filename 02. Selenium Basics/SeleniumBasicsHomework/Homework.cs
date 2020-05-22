using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumBasicsHomework
{
    public class Homework
    {
        private IWebDriver _webDriver;
        // URLS for sites under testing
        private const string GoogleSite = "https://www.google.com";
        private const string SoftUniSite = "http://www.softuni.bg";
        private const string AutomationPracticeSite = "http://automationpractice.com/index.php";
        // Selectors for Google Test
        private readonly By googleSearchField = By.CssSelector("input.gLFyf");
        private readonly By googleResultsAfterSearch = By.CssSelector(".r h3");
        // Selectors for SoftUni Test
        private readonly By softUniTrainingMenu = By.CssSelector(".toggle-nav li.dropdown-item:nth-of-type(2) a");
        private readonly By softUniQAAutomation2020 = By.CssSelector("a[href='/trainings/2550/qa-automation-may-2020']");
        private readonly By softUniCourseHeader = By.CssSelector("h1");
        // Selectors for Automation Practice Test
        private readonly By signInButton = By.CssSelector(".login");
        private readonly By emailRegistrationField = By.Id("email_create");
        private readonly By createAccountButton = By.Id("SubmitCreate");
        private readonly By emailField = By.Id("email");
        private readonly By passwordField = By.Id("passwd");
        private readonly By submitLoginFormButton = By.Id("SubmitLogin");
        private readonly By myAccountHeading = By.CssSelector(".page-heading");
        private readonly By registerButton = By.Id("submitAccount");

        [SetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void GoogleSite_VerifySearchBasedOnSpecificWord()
        {
            NavigateTo(GoogleSite);
            FillInTextInElement(googleSearchField, "selenium" + Keys.Enter);
            IList<IWebElement> googleResults = _webDriver.FindElements(googleResultsAfterSearch);
            googleResults[0].Click();
            Assert.AreEqual("https://www.selenium.dev/", _webDriver.Url);
            Assert.AreEqual("SeleniumHQ Browser Automation", _webDriver.Title);
        }

        [Test]
        public void SoftUniSite_VerifyUserIsCorrectlyNavigatedToQAAutomationCourse()
        {
            NavigateTo(SoftUniSite);
            ClickElement(softUniTrainingMenu);
            ClickElement(softUniQAAutomation2020);
            WaitUntilElementExists(softUniCourseHeader);
            Assert.AreEqual("QA Automation - май 2020", FindElement(softUniCourseHeader).Text);
        }

        [Test]
        public void AutomationPracticeSite_Registration()
        {
            Random random = new Random();
            int randNumber = random.Next(int.MinValue, int.MaxValue);
            string emailForRegistration = "super_strange_" + randNumber + "@test.com";
            NavigateTo(AutomationPracticeSite);
            ClickElement(signInButton);
            WaitUntilElementExists(emailRegistrationField, 15);
            FillInTextInElement(emailRegistrationField, emailForRegistration);
            ClickElement(createAccountButton);
            WaitUntilElementExists(registerButton);
            Assert.AreEqual(emailForRegistration, FindElement(emailField).GetAttribute("value"), "Email for registration is not correct!");
        }

        [Test]
        public void AutomationPracticeSite_SuccessfulLogin()
        {
            NavigateTo(AutomationPracticeSite);
            ClickElement(signInButton);
            WaitUntilElementExists(emailField, 15);
            FillInTextInElement(emailField, "test123email@abv.bg");
            FillInTextInElement(passwordField, "test123");
            ClickElement(submitLoginFormButton);
            Assert.IsTrue(FindElement(myAccountHeading).Displayed, "MY ACCOUNT text is not displayed, so the user is not logged in successfuly.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }


        private IWebElement FindElement(By locator)
        {
            return _webDriver.FindElement(locator);
        }

        private void ClickElement(By locator)
        {
            FindElement(locator).Click();
        }

        private void FillInTextInElement(By locator, String text)
        {
            FindElement(locator).SendKeys(text);
        }

        private void NavigateTo(string url)
        {
            _webDriver.Url = url;
        }

        private IWebElement WaitUntilElementExists(By selector, int timeout = 10)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(element => element.FindElement(selector));
        }

    }
}