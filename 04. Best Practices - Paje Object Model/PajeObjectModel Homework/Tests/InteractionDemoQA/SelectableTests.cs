

using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class SelectableTests : BaseTest
    {

        private SelectablePage _selectablePage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _selectablePage = new HomePage(Driver).NavigateToInteractionsPage().NavigateToInteractionsSection("Selectable");
        }

        [Test]
        public void Test1_Verify_All_SelectableElements_Are_Selected()
        {
            int selectableOptionsCount = _selectablePage.SelectableOptions;

            _selectablePage.SelectOptions(selectableOptionsCount);

            int actualCountOfSelectedItems = _selectablePage.SelectedOptions;

            int expectedCountOfSelectedItems = 4;
            Assert.AreEqual(expectedCountOfSelectedItems, actualCountOfSelectedItems);
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
