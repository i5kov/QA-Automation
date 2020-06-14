using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class SortablePage : BasePage
    {
        private IWebElement Box(int boxNumber) => FindElement(By.CssSelector($"div.list-group-item:nth-of-type({boxNumber})"));
        private List<IWebElement> AllBoxes => FindElements(By.CssSelector(".vertical-list-container div")).ToList();

        public SortablePage(IWebDriver driver) : base(driver) { }

        public List<string> OrderOfBoxes => AllBoxes.Select(x => x.Text).ToList();

        public void ChangePositionOfBox(int boxNumber, int offset)
        {
            PerformActions()
                .DragAndDropToOffset(Box(boxNumber), 0, offset)
                .Perform();
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