using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumAdvancedHomework.Task02._Interaction_Tests
{
    class ResizableTests : BaseTest
    {
        private const string Resizable = "resizable";

        private readonly By _resizeBoxWithRestriction = By.Id("resizableBoxWithRestriction");
        private readonly By _handleForBoxWithRestriction = By.CssSelector("#resizableBoxWithRestriction .react-resizable-handle");
        private readonly By _resizableBox = By.Id("resizable");
        private readonly By _handleForResizableBox = By.CssSelector("#resizable .react-resizable-handle");

        [SetUp]
        public void BeforeEachTest()
        {
            NavigateToInteractionSection(Resizable);
        }

        [Test]
        public void Test1_Verify_Size_Of_ResizableBox_After_Enlargement()
        {
            PerformActions()
                .ClickAndHold(FindElement(_handleForBoxWithRestriction))
                .MoveByOffset(200, 50)
                .Perform();
            string expectedSizeOfResizeBox = "width: 400px; height: 250px;";
            string actulaSizeOfResizeBox = FindElementAndGetAttribute(_resizeBoxWithRestriction, "style");

            Assert.AreEqual(expectedSizeOfResizeBox, actulaSizeOfResizeBox,
                "The resize box sizes are not equal");
        }

        [Test]
        public void Test2_Verify_Size_Of_ResizableBox_After_PageRefresh()
        {
            string sizeOfResizableBox = FindElementAndGetAttribute(_resizableBox, "style");
            PerformActions()
                .ClickAndHold(FindElement(_handleForResizableBox))
                .MoveByOffset(350, 150)
                .Perform();
            string sizeOfResizableBoxAfterActions = FindElementAndGetAttribute(_resizableBox, "style");

            Assert.AreNotEqual(sizeOfResizableBox, sizeOfResizableBoxAfterActions);
            RefreshPage();

            string sizeOfResizableBoxAfterPageRefresh = FindElementAndGetAttribute(_resizableBox, "style");

            Assert.AreEqual(sizeOfResizableBox, sizeOfResizableBoxAfterPageRefresh);
        }
    }
}
