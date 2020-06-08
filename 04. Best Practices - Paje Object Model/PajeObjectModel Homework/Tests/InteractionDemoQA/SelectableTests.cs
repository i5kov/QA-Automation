

using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class SelectableTests : BaseTest
    {

        private InteractionsPage _interactionsPage;

        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            _interactionsPage = new HomePage(Driver).GoToInteractionsMenu();
        }

        [Test]
        public void Test1_Verify_All_SelectableElements_Are_Selected()
        {
            SelectablePage selectablePage = _interactionsPage.NavigateToInteractionsSection("Selectable", "List");
            int selectableOptionsCount = selectablePage.SelectableOptions;

            selectablePage.SelectOptions(selectableOptionsCount);

            int actualCountOfSelectedItems = selectablePage.SelectedOptions;

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
