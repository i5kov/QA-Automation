using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class DroppableTests : BaseTest
    {
        private DroppablePage _droppablePage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _droppablePage = new HomePage(Driver).NavigateToInteractionsPage().NavigateToInteractionsSection("Droppable");
        }

        [Test]
        public void Test1_Verify_DragBox_Is_Placed_Inside_A_Box()
        {
            string dropBoxText = _droppablePage.DropHereBox.Text;

            _droppablePage.DragAndDrop(_droppablePage.DragMeBox, _droppablePage.DropHereBox);

            string dropBoxTextAfterActions = _droppablePage.DropHereBox.Text;

            Assert.AreNotEqual(dropBoxText, dropBoxTextAfterActions,
                "Drop here text was not change, but should be changed to 'Dropped!'");
        }

        [Test]
        public void Test2_Verify_InnerDroppableBox_Is_Greedy()
        {
            _droppablePage.ClickOnSubMenu("Prevent Propogation");

            _droppablePage.DragAndDrop(_droppablePage.DragBox, _droppablePage.GreedyInnerDroppableBox);
            
            Assert.IsTrue(_droppablePage.GreedyInnerDroppableBox.Text == "Dropped!");
            Assert.AreEqual(_droppablePage.GreedyInnerDroppableBox.GetCssValue("background-color"), "rgba(70, 130, 180, 1)");
            Assert.AreEqual(_droppablePage.GreedyDropBox.Text.Split("\r\n")[0], "Outer droppable");
        }

        [Test]
        public void Test3_Verify_Color_Changed_In_Both_DroppableBoxes()
        {
            _droppablePage.ClickOnSubMenu("Prevent Propogation");

            _droppablePage.DragAndDrop(_droppablePage.DragBox, _droppablePage.NotGreedyInnerBox);
            
            Assert.AreEqual(_droppablePage.NotGreedyDropBox.Text.Split("\r\n")[0], "Dropped!");
            Assert.AreEqual(_droppablePage.NotGreedyDropBox.GetCssValue("background-color"), "rgba(70, 130, 180, 1)");
            Assert.IsTrue(_droppablePage.NotGreedyInnerBox.Text == "Dropped!");
            Assert.AreEqual(_droppablePage.NotGreedyInnerBox.GetCssValue("background-color"), "rgba(70, 130, 180, 1)");
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
