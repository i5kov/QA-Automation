using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class ResizablePage : BasePage
    {

        private readonly By _resizeBoxWithRestriction = By.Id("resizableBoxWithRestriction");
        private readonly By _handleForBoxWithRestriction = By.CssSelector("#resizableBoxWithRestriction .react-resizable-handle");
        private readonly By _resizableBox = By.Id("resizable");
        private readonly By _handleForResizableBox = By.CssSelector("#resizable .react-resizable-handle");

        public ResizablePage(IWebDriver driver) : base(driver) { }

        public string SizeOfResizeBox(bool isRestricted)
        {
            By[] locators = LocatorToBeUsed(isRestricted);
            return FindElement(locators[1]).GetAttribute("style");
        }

        public void ResizeElementByOffset(int offsetX, int offsetY, bool isRestricted)
        {
            By[] locators = LocatorToBeUsed(isRestricted);
            MoveByOffset(FindElement(locators[0]), offsetX, offsetY);
        }

        private By[] LocatorToBeUsed(bool isRestricted)
        {
            return 
                isRestricted ? 
                new By[2] { _handleForBoxWithRestriction, _resizeBoxWithRestriction } : 
                new By[2] { _handleForResizableBox, _resizableBox };

        }


    }
}