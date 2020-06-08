using OpenQA.Selenium;

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

            return (sectionName.ToLower()) switch
            {
                "dragabble" => new DragabblePage(Driver, subMenu),
                "droppable" => new DroppablePage(Driver, subMenu),
                "sortable" => new SortablePage(Driver, subMenu),
                "selectable" => new SelectablePage(Driver, subMenu),
                _ => null,
            };
        }
    }
}
