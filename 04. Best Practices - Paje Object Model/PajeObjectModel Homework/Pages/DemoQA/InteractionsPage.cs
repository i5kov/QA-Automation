using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class InteractionsPage : BasePage
    {
        private IWebElement SubMenu(string menuText) => FindElement(By.XPath($"//nav//a[text()='{menuText}']"));

        public InteractionsPage(IWebDriver driver) : base(driver) { }

        public dynamic NavigateToInteractionsSection(string sectionName)
        {
            Driver.Navigate().GoToUrl($"http://www.demoqa.com/{sectionName.ToLower()}");

            return (sectionName.ToLower()) switch
            {
                "dragabble" => new DragabblePage(Driver),
                //"droppable" => new DroppablePage(Driver),
                "sortable" => new SortablePage(Driver),
                "selectable" => new SelectablePage(Driver),
                "resizable" => new ResizablePage(Driver),
                _ => null,
            };
        }

       public void ClickOnSubMenu(string subMenuText)
       {
            ClickElement(SubMenu(subMenuText));
       }
    }
}
