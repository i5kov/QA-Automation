using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class DroppablePage : InteractionsPage
    {
        public IWebElement DragMeBox => FindElement(By.Id("draggable"));
        public IWebElement DropHereBox => FindElement(By.Id("droppable"));
        public IWebElement DragBox => FindElement(By.Id("dragBox"));
        public IWebElement GreedyInnerDroppableBox => FindElement(By.Id("greedyDropBoxInner"));
        public IWebElement GreedyDropBox => FindElement(By.Id("greedyDropBox"));
        public IWebElement NotGreedyDropBox => FindElement(By.Id("notGreedyDropBox"));
        public IWebElement NotGreedyInnerBox => FindElement(By.Id("notGreedyInnerDropBox"));

        public DroppablePage(IWebDriver driver) : base(driver) { }

        public void DragAndDrop(IWebElement source, IWebElement target)
        {
            PerformActions()
                .DragAndDrop(source, target)
                .Perform();
        }
    }
}