using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    class SelectableTests : BaseTest
    {
        private const string Selectable = "selectable";

        private readonly By _selectableOptions = By.CssSelector("#verticalListContainer li");

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Selectable);
        }
        [Test]
        public void Test1_Verify_All_SelectableElements_Are_Selected()
        {
            int selectableOptionsCount = FindElements(_selectableOptions).Count;
            for (int i = 1; i <= selectableOptionsCount; i++)
            {
                _driver.FindElement(By.CssSelector($"#verticalListContainer li:nth-of-type({i})")).Click();
            }

            int actualCountOfSelectedItems = FindElements(_selectableOptions)
                .Where(x => x.GetAttribute("class").Contains("active"))
                .Count();

            int expectedCountOfSelectedItems = 4;
            Assert.AreEqual(expectedCountOfSelectedItems, actualCountOfSelectedItems);
        }

        [Test]
        public void Test2_Verify_AllItems_AreNot_Selected_When_They_Were_Selected()
        {
            Test1_Verify_All_SelectableElements_Are_Selected();

            int selectableOptionsCount = FindElements(_selectableOptions).Count;
            for (int i = 1; i <= selectableOptionsCount; i++)
            {
                _driver.FindElement(By.CssSelector($"#verticalListContainer li:nth-of-type({i})")).Click();
            }

            int actualCountOfNotSelectedItems = FindElements(_selectableOptions)
                .Where(x => x.GetAttribute("class").Contains("active"))
                .Count();

            int expectedCountOfNotSelectedItems = 0;
            Assert.AreEqual(expectedCountOfNotSelectedItems, actualCountOfNotSelectedItems);

        }
    }
}
