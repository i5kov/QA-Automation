using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    class SortableTests : BaseTest
    {
        private const string Sortable = "sortable";

        private readonly By _oneBox = By.CssSelector("div.list-group-item:nth-of-type(1)");
        private readonly By _allBoxes = By.CssSelector(".vertical-list-container div");    

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Sortable);
        }

        [Test]
        public void Test1_Verify_FirstBox_Is_Placed_In_The_End()
        {
            PerformActions()
                .DragAndDropToOffset(FindElement(_oneBox), 0, 500)
                .Perform();
            List<string> expectedOrder = new List<string>()
            {
                "Two", "Three", "Four", "Five", "Six", "One"
            };
            List<string> actualOrder = new List<string>();

            IList<IWebElement> allBoxes = FindElements(_allBoxes);
            foreach (var element in allBoxes)
            {
                actualOrder.Add(element.Text);
            }
            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }

        [Test]
        public void Test2_Verify_Order_Of_Boxes_After_Moving_Elements_And_Page_Refresh()
        {
            List<string> orderInBeginning = FindElements(_allBoxes)
                .Select(x => x.Text)
                .ToList();

            for (int i = 1; i <= 6; i++)
            {
                PerformActions()
                    .DragAndDropToOffset(_driver.FindElement(By.CssSelector($"div.list-group-item:nth-of-type({i})")), 0, 150)
                    .Perform();
            }
            List<string> orderAfterActions = FindElements(_allBoxes).Select(x => x.Text).ToList();
            CollectionAssert.AreNotEqual(orderInBeginning, orderAfterActions);

            RefreshPage();

            List<string> orderAfterResfresh = FindElements(_allBoxes).Select(x => x.Text).ToList();
            CollectionAssert.AreEqual(orderInBeginning, orderAfterResfresh);
        }
    }
}
