using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    public class DraggableTests : BaseTest
    {

        private const string Dragabble = "dragabble";

        private readonly By _dragBox = By.Id("dragBox");

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Dragabble);
        } 

        [Test]
        public void Test1_SimpleDraggable_Verify_DragBox_Position_Changed()
        {
            string dragBoxStartingPosition = FindElementAndGetAttribute(_dragBox, "style");

            PerformActions()
                .ClickAndHold(FindElement(_dragBox))
                .MoveByOffset(500, 350)
                .Perform();

            string dragBoxPositionAfterActions = FindElementAndGetAttribute(_dragBox, "style");
            Assert.AreNotEqual(dragBoxStartingPosition, dragBoxPositionAfterActions, "Drag Box Not Moved");
        }

        [Test]
        public void Test2_Verify_DragBox_Is_In_StartingPosition_After_Drag()
        {
            string dragBoxStartingPosition = FindElementAndGetAttribute(_dragBox, "style");

            PerformActions()
                .ClickAndHold(FindElement(_dragBox))
                .MoveByOffset(500, 500)
                .Perform();

            SetAttributeToElement(FindElement(_dragBox), "style", "position: relative;");
            string currentDragBoxPosition = FindElementAndGetAttribute(_dragBox, "style");
            Assert.AreEqual(dragBoxStartingPosition, currentDragBoxPosition, "Drag box is not in the starting position.");
        }
    }
}
