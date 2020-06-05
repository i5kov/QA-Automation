using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PajeObjectModel_Homework.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        protected void FindElementAndTypeText(By selector, string text)
        {
            FindElement(selector).SendKeys(text);
        }

        protected IList<IWebElement> FindElements(By selector)
        {
            return Driver.FindElements(selector);
        }

        protected void ClickElement(By selector)
        {
            FindElement(selector).Click();
        }

        protected IWebElement FindElement(By selector)
        {
            return Driver.FindElement(selector);
        }

        protected void ClickElement(IWebElement element)
        {
            element.Click();
        }

        protected void SelectFromDropdownByText(IWebElement dropdown, string text)
        {
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText(text);
        }

        protected IWebElement WaitUntilElementExists(By selector, int timeout = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
    }
}
