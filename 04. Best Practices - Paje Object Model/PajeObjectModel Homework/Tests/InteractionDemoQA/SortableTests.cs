using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;
using System.Collections.Generic;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class SortableTests : BaseTest
    {
        private InteractionsPage _interactionsPage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _interactionsPage = new HomePage(Driver).GoToInteractionsMenu();
        }

        [Test]
        public void Test1_Verify_FirstBox_Is_Placed_In_The_End()
        {
            List<string> expectedOrder = new List<string>()
            {
                "Two", "Three", "Four", "Five", "Six", "One"
            };
            SortablePage sortablePage = _interactionsPage.NavigateToInteractionsSection("Sortable", "List");

            sortablePage.ChangePositionOfBox(1, 500);

            List<string> actualOrder = sortablePage.OrderOfBoxes;

            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }

        [Test]
        public void Test2_Verify_Order_Of_Boxes_After_Moving_Elements_And_Page_Refresh()
        {
            SortablePage sortablePage = _interactionsPage.NavigateToInteractionsSection("Sortable", "List");
            List<string> orderInBeginning = sortablePage.OrderOfBoxes;

            sortablePage.ChangeOrderOfAllBoxes();

            List<string> orderAfterActions = sortablePage.OrderOfBoxes;
            CollectionAssert.AreNotEqual(orderInBeginning, orderAfterActions);

            sortablePage.RefreshPage();

            List<string> orderAfterResfresh = sortablePage.OrderOfBoxes;
            CollectionAssert.AreEqual(orderInBeginning, orderAfterResfresh);
        }
    }
}
