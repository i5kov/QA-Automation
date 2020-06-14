using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class DragabblePage : InteractionsPage
    {
        private readonly By _dragBox = By.Id("dragBox");
        private readonly By _restrictedX = By.Id("restrictedX");

        public DragabblePage(IWebDriver driver) : base(driver) { }

        public string GetElementPosition => FindElement(_dragBox).GetAttribute("style");

        public string GetRestrictedElementPosition => FindElement(_restrictedX).GetAttribute("style").Split("; ")[2];

        public void MoveElementByOffset(int x, int y, bool isRestricted)
        {
            var locatorToBeUsed = isRestricted ? _restrictedX : _dragBox;
            PerformActions()
               .ClickAndHold(FindElement(locatorToBeUsed))
               .MoveByOffset(x, y)
               .Release()
               .Perform();
        }
    }
}