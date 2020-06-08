using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            _dragabblePage = new HomePage(Driver).GoToInteractionsMenu().NavigateToInteractionsSection("Dragabble");
        }

        [Test]
        public void Test1_SimpleDraggable_Verify_DragBox_Position_Changed()
        {
            Assert.IsTrue(_dragabblePage.IsDisplayed);

            string dragBoxStartingPosition = _dragabblePage.GetElementPosition;

            _dragabblePage.MoveElementByOffset(500, 350);

            string dragBoxPositionAfterActions = _dragabblePage.GetElementPosition;
            Assert.AreNotEqual(dragBoxStartingPosition, dragBoxPositionAfterActions, "Drag Box Not Moved");
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
