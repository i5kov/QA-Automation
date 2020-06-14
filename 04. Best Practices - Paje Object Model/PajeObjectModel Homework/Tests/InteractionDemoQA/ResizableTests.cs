using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class ResizableTests : BaseTest
    {
        private ResizablePage _resizablePage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _resizablePage = new HomePage(Driver).NavigateToInteractionsPage().NavigateToInteractionsSection("Resizable");
        }

        [Test]
        public void Test1_Verify_Size_Of_ResizableBox_After_Enlargement()
        {
            bool IsResizableBoxRestricted = true;
            _resizablePage.ResizeElementByOffset(200, 50, IsResizableBoxRestricted);

            string expectedSizeOfResizeBox = "width: 500px; height: 249px;";
            string actulaSizeOfResizeBox = _resizablePage.SizeOfResizeBox(IsResizableBoxRestricted); 
                
            Assert.AreEqual(expectedSizeOfResizeBox, actulaSizeOfResizeBox,
                "The resize box sizes are not equal");
        }

        [Test]
        public void Test2_Verify_Size_Of_ResizableBox_After_PageRefresh()
        {
            bool IsResizableBoxRestricted = false;
            string sizeOfResizableBox = _resizablePage.SizeOfResizeBox(IsResizableBoxRestricted);

            _resizablePage.ResizeElementByOffset(350, 150, false);
           
            string sizeOfResizableBoxAfterActions = _resizablePage.SizeOfResizeBox(IsResizableBoxRestricted);

            Assert.AreNotEqual(sizeOfResizableBox, sizeOfResizableBoxAfterActions);

            _resizablePage.RefreshPage();

            string sizeOfResizableBoxAfterPageRefresh = _resizablePage.SizeOfResizeBox(IsResizableBoxRestricted);

            Assert.AreEqual(sizeOfResizableBox, sizeOfResizableBoxAfterPageRefresh);
        }


        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
