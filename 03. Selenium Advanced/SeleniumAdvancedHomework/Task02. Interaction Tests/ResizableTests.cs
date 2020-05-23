using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    class ResizableTests : BaseTest
    {
        private const string Resizable = "resizable";

        private readonly By _resizeBoxWithRestriction = By.Id("resizableBoxWithRestriction");

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Resizable);
        }

        [Test]
        public void Test1_Verify_Size_Of_ResizableBox_After_Enlargement()
        {
            PerformActions()
                .ClickAndHold(_driver.FindElement(By.CssSelector("#resizableBoxWithRestriction .react-resizable-handle")))
                .MoveByOffset(200, 50)
                .Perform();
            string expectedSizeOfResizeBox = "width: 400px; height: 250px;";
            string actulaSizeOfResizeBox = FindElementAndGetAttribute(_resizeBoxWithRestriction, "style");

            Assert.AreEqual(expectedSizeOfResizeBox, actulaSizeOfResizeBox,
                "The resize box sizes are not equal");
        }
    }
}
