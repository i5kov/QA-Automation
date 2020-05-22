using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumAdvancedHomework
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        private readonly By _signIn = By.CssSelector(".login");
        private readonly By _createAccountButton = By.Id("SubmitCreate");
        private readonly By _emailFieldCreateAccount = By.Id("email_create");

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            MaximizeBrowserWindow();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        protected void FindElementAndClick(By selector)
        {
            FindElement(selector).Click();
        }

        protected void FindElementAndFillText(By selector, string text)
        {
            FindElement(selector).SendKeys(text);
        }

        protected string FindElementAndGetAttribute(By selector, string attribute)
        {
            return FindElement(selector).GetAttribute(attribute);
        }

        protected IWebElement WaitForElement(By selector, int timeout = 10)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout))
                .Until(element => element.FindElement(selector));
        }

        protected void SelectFromDropdownByText(IWebElement dropdown, string text)
        {
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText(text);
        }

        protected void SetAttributeToElement(IWebElement element, string attribute, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                element, attribute, value);
        }

        protected Actions PerformActions()
        {
            return new Actions(_driver);
        }

        protected IWebElement FindElement(By selector)
        {
            return _driver.FindElement(selector);
        }

        protected IList<IWebElement> FindElements(By selector)
        {
            return _driver.FindElements(selector);
        }

        protected void MaximizeBrowserWindow()
        {
            _driver.Manage().Window.Maximize();
        }

        protected void NavigateToRegistrationPageWithEmail(string email)
        {
            _driver.Url = "http://automationpractice.com/index.php";
            FindElementAndClick(_signIn);
            WaitForElement(_createAccountButton, 20);
            FindElementAndFillText(_emailFieldCreateAccount, email);
            FindElementAndClick(_createAccountButton);
        }

        protected void NavigateToInteractionSection(string section)
        {
            _driver.Url = $"http://www.demoqa.com/{section}";
        }
    }
}