using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class DragabbleTests : BaseTest
    {

        private DragabblePage _dragabblePage;

        [SetUp]
        public void Befor_eEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _dragabblePage = new HomePage(Driver).NavigateToInteractionsPage().NavigateToInteractionsSection("Dragabble");
        }

        [Test]
        public void Test1_SimpleDraggable_Verify_DragBox_Position_Changed()
        {
            string dragBoxStartingPosition = _dragabblePage.GetElementPosition;

            _dragabblePage.MoveElementByOffset(500, 350, false);

            string dragBoxPositionAfterActions = _dragabblePage.GetElementPosition;
            Assert.AreNotEqual(dragBoxStartingPosition, dragBoxPositionAfterActions, "Drag Box Not Moved");
        }

        [Test]
        public void Test2_Verify_DragBox_Is_In_StartingPosition_After_PageRefresh()
        {
            string dragBoxStartingPosition = _dragabblePage.GetElementPosition;

            _dragabblePage.MoveElementByOffset(500, 500, false);
            _dragabblePage.RefreshPage();
          
            string currentDragBoxPosition = _dragabblePage.GetElementPosition; ;
            Assert.AreEqual(dragBoxStartingPosition, currentDragBoxPosition, "Drag box is not in the starting position.");
        }

        [Test]
        public void Test3_Verify_RestrictedX_Box_Is_Able_ToBeMoved_Only_X_Axis()
        {
            _dragabblePage.ClickOnSubMenu("Axis Restricted");

            _dragabblePage.MoveElementByOffset(100, 350, true);

            Assert.AreEqual(_dragabblePage.GetRestrictedElementPosition, "top: 0px;");
        }


        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
