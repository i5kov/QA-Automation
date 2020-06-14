using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;
using System.Collections.Generic;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class SortableTests : BaseTest
    {
        private SortablePage _sortablePage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _sortablePage = new HomePage(Driver).NavigateToInteractionsPage().NavigateToInteractionsSection("Sortable");
        }

        [Test]
        public void Test1_Verify_FirstBox_Is_Placed_In_The_End()
        {
            List<string> expectedOrder = new List<string>()
            {
                "Two", "Three", "Four", "Five", "Six", "One"
            };

            _sortablePage.ChangePositionOfBox(1, 500);

            List<string> actualOrder = _sortablePage.OrderOfBoxes;

            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }

        [Test]
        public void Test2_Verify_Order_Of_Boxes_After_Moving_Elements_And_Page_Refresh()
        {
            List<string> orderInBeginning = _sortablePage.OrderOfBoxes;

            _sortablePage.ChangeOrderOfAllBoxes();

            List<string> orderAfterActions = _sortablePage.OrderOfBoxes;
            CollectionAssert.AreNotEqual(orderInBeginning, orderAfterActions);

            _sortablePage.RefreshPage();

            List<string> orderAfterResfresh = _sortablePage.OrderOfBoxes;
            CollectionAssert.AreEqual(orderInBeginning, orderAfterResfresh);
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
