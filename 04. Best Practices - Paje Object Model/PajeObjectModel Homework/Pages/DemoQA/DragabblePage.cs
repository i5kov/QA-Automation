using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class DragabblePage : BasePage
    {

        private readonly By _mainHeader = By.CssSelector(".main-header");
        private readonly By _dragBox = By.Id("dragBox");
        private readonly By _restrictedX = By.Id("restrictedX");
        private IWebElement _subMenu(string subMenuText) => FindElement(By.XPath($"//a[text()='{subMenuText}']"));

        public DragabblePage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsDisplayed => FindElement(_mainHeader).Text == "Dragabble" ? true : false;

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

        public void ClickOnSubMenu(string subMenuText)
        {
            ClickElement(_subMenu(subMenuText));
        }
    }
}