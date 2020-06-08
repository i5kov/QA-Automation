using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    class InteractionsPage : BasePage
    {
        public InteractionsPage(IWebDriver driver) : base(driver)
        {

        }

        public dynamic NavigateToInteractionsSection(string sectionName, string subMenu)
        {
            Driver.Navigate().GoToUrl($"http://www.demoqa.com/{sectionName.ToLower()}");

            switch (sectionName.ToLower())
            {
                case "dragabble": return new DragabblePage(Driver, subMenu);
                case "droppable": return new DroppablePage(Driver, subMenu);
                case "sortable": return new SortablePage(Driver, subMenu);
                default: return null;
            }
        }
    }
}
