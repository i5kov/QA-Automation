using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    internal class DragabblePage : BasePage
    {

        private readonly By _mainHeader = By.CssSelector(".main-header");
        private readonly By _dragBox = By.Id("dragBox");

        public DragabblePage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsDisplayed => FindElement(_mainHeader).Text == "Dragabble" ? true : false;

        public string GetElementPosition => FindElement(_dragBox).GetAttribute("style");

        public void MoveElementByOffset(int x, int y)
        {
            RefreshPage();
            PerformActions()
               .ClickAndHold(FindElement(_dragBox))
               .MoveByOffset(x, y)
               .Release()
               .Perform();
        }
    }
}