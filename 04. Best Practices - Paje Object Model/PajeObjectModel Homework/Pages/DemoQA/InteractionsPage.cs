using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    class InteractionsPage : BasePage
    {

        private IWebElement sectionMenu(string section) => FindElement(By.XPath($"//div[text()='{section}']"));

        public InteractionsPage(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateToInteractionsSection(string sectionName)
        {
            ClickElement(sectionMenu(sectionName));
        }
    }
}
