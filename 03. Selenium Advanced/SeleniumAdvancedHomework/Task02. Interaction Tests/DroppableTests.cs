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

        private readonly By _dragMeBox = By.Id("draggable");
        private readonly By _dropHereBox = By.Id("droppable");

        private readonly By _preventPropogationTab = By.Id("droppableExample-tab-preventPropogation");
        private readonly By _greedyDropBox = By.Id("greedyDropBox");
        private readonly By _sourceBox = By.Id("dragBox");
        private readonly By _greedyInnerDroppableBox = By.Id("greedyDropBoxInner");
        private readonly By _notGreedyDropBox = By.Id("notGreedyDropBox");
        private readonly By _notGreedyInnerBox = By.Id("notGreedyInnerDropBox");

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
        public void Test2_Verify_InnerDroppableBox_Is_Greedy()
        {
            FindElementAndClick(_preventPropogationTab);
            PerformActions()
                .DragAndDrop(FindElement(_sourceBox), FindElement(_greedyInnerDroppableBox))
                .Perform();
            Assert.IsTrue(FindElement(_greedyInnerDroppableBox).Text == "Dropped!");
            Assert.AreEqual(FindElement(_greedyInnerDroppableBox).GetCssValue("background-color"), "rgba(70, 130, 180, 1)");
            Assert.AreEqual(FindElement(_greedyDropBox).Text.Split("\r\n")[0], "Outer droppable");
        }

        [Test]
        public void Test3_Verify_Color_Changed_In_Both_DroppableBoxes()
        {
            FindElementAndClick(_preventPropogationTab);
            PerformActions()
                .DragAndDrop(FindElement(_sourceBox), FindElement(_notGreedyInnerBox))
                .Perform();
            Assert.AreEqual(FindElement(_notGreedyDropBox).Text.Split("\r\n")[0], "Dropped!");
            Assert.AreEqual(FindElement(_notGreedyDropBox).GetCssValue("background-color"), "rgba(70, 130, 180, 1)");
            Assert.IsTrue(FindElement(_notGreedyInnerBox).Text == "Dropped!");
            Assert.AreEqual(FindElement(_notGreedyInnerBox).GetCssValue("background-color"), "rgba(70, 130, 180, 1)");       
        }
    }
}
