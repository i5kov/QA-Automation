using OpenQA.Selenium;
using System.Linq;

namespace PajeObjectModel_Homework.Pages.DemoQA
{
    public class SelectablePage : InteractionsPage
    {

        private readonly By _selectableOptions = By.CssSelector("#verticalListContainer li");
        private IWebElement SelectableOption(int option) => FindElement(By.CssSelector($"#verticalListContainer li:nth-of-type({option})"));

        public SelectablePage(IWebDriver driver) : base(driver) { }

        public int SelectableOptions 
        {
            get
            {
                return FindElements(_selectableOptions).Count;
            }
        }

        public int SelectedOptions 
        {  
            get
            {
                return FindElements(_selectableOptions)
                    .Where(x => x.GetAttribute("class")
                    .Contains("active"))
                    .Count();
            }
        }

        public void SelectOptions(int optionsCount)
        {
            for (int i = 1; i <= optionsCount; i++)
            {
                ClickElement(SelectableOption(i));
            }
        }
    }
}