using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    class DroppableTests : BaseTest
    {
        private const string Droppable = "droppable";

        private readonly By _droppableAcceptTab = By.Id("droppableExample-tab-accept");
        private readonly By _revertDraggableTab = By.Id("droppableExample-tab-revertable");
        private readonly By _dragMeBox = By.Id("draggable");
        private readonly By _dropHereBox = By.Id("droppable");
        private readonly By _dropHereBoxInAcceptTab = By.CssSelector("#acceptDropContainer #droppable");
        private readonly By _notAcceptableBox = By.Id("notAcceptable");s
        private readonly By _notRevertBox = By.Id("notRevertable");
        private readonly By _dropHereBoxInRevertDraggableTab = By.CssSelector("#revertableDropContainer #droppable");

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Droppable);
        }

        [Test]
        public void Test1_Verify_DragBox_Is_Placed_Inside_A_Box()
        {
            string dropBoxText = FindElement(_dropHereBox).Text;
            IWebElement source = FindElement(_dragMeBox);
            IWebElement target = FindElement(_dropHereBox);
            PerformActions()
                .DragAndDrop(source, target)
                .Perform();
            string dropBoxTextAfterActions = FindElement(_dropHereBox).Text;

            Assert.AreNotEqual(dropBoxText, dropBoxTextAfterActions,
                "Drop here text was not change, but should be changed to 'Dropped!'");
        }

        [Test]
        public void Test2_Verify_NotAcceptableBox_Does_Not_Change_Text_Of_DropHereBox()
        {
            FindElementAndClick(_droppableAcceptTab);
            string dropBoxText = FindElement(_dropHereBoxInAcceptTab).Text;
            PerformActions()
                .DragAndDrop(FindElement(_notAcceptableBox), FindElement(_dropHereBoxInAcceptTab))
                .Perform();
            string dropBoxTextAfterActions = FindElement(_dropHereBoxInAcceptTab).Text;

            Assert.AreEqual(dropBoxText, dropBoxTextAfterActions,
                "Drop here text was changed, but it should not be!");
        }
    }
}
