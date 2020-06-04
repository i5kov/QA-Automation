using OpenQA.Selenium;

namespace PajeObjectModel_Homework.Pages
{
    public class GooglePage : BasePage
    {
        public GooglePage(IWebDriver driver) : base(driver) { }

        private readonly By _searchField = By.CssSelector("input.gLFyf");
        private readonly By _googleResultsAfterSearch = By.CssSelector(".r h3");

        public void SearchByEnteredText(string text)
        {
            FindElementAndTypeText(_searchField, text);
        }

        public void ClickOnGoogleResultLinkByNumber(int result)
        {
            FindElements(_googleResultsAfterSearch)[result - 1].Click();
        }
    }
}
