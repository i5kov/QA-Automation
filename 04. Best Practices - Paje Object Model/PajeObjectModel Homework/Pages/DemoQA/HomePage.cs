using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    class HomePage : BasePage
    {
        private IWebElement _interactionsMenu => Driver.FindElement(By.XPath($"//div[contains(@class, 'top-card')]//h5[text()='Interactions']"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public InteractionsPage GoToInteractionsMenu()
        {
            ClickElement(_interactionsMenu);
            return new InteractionsPage(Driver);
        }
    }
}
