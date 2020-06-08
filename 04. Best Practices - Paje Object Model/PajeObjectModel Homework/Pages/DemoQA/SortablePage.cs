using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class SortablePage : BasePage
    {
        private IWebElement Box(int boxNumber) => FindElement(By.CssSelector($"div.list-group-item:nth-of-type({boxNumber})"));
        private readonly By _allBoxes = By.CssSelector(".vertical-list-container div");

        public SortablePage(IWebDriver driver, string subMenu) : base(driver)
        {
            GoToSpecificSubMenu(subMenu);
        }

        public void ChangePositionOfBox(int boxNumber, int offset)
        {
            PerformActions()
                .DragAndDropToOffset(Box(boxNumber), 0, offset)
                .Perform();
        }

        public List<string> OrderOfBoxes 
        {
            get
            {
                return FindElements(_allBoxes).Select(x => x.Text).ToList();
            } 
        }

        public void ChangeOrderOfAllBoxes()
        {
            for (int i = 1; i <= 6; i++)
            {
                PerformActions()
                    .DragAndDropToOffset(Box(i), 0, 150)
                    .Perform();
            }
        }
    }
}