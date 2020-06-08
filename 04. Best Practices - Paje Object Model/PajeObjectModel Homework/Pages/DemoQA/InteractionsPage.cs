using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    class InteractionsPage : BasePage
    {

        private IWebElement sectionMenu(string section) => FindElement(By.XPath($"//span[text()='{section}']"));

        public InteractionsPage(IWebDriver driver) : base(driver)
        {

        }

        public dynamic NavigateToInteractionsSection(string sectionName)
        {
            Driver.Navigate().GoToUrl($"http://www.demoqa.com/{sectionName.ToLower()}");

            switch (sectionName.ToLower())
            {
                case "dragabble":

                    return new DragabblePage(Driver);
                default: return null;
            }
        }
    }
}
