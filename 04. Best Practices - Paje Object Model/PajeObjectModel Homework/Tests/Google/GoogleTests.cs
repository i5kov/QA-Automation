using NUnit.Framework;
using OpenQA.Selenium;
using PajeObjectModel_Homework.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Tests
{
    [TestFixture]
    class GoogleTests : BaseTest
    {
        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.GoogleSite);
        }

        [Test]
        public void Verify_FirstGoogleResult_When_SearchingForSelenium()
        {
            GooglePage googlePage = new GooglePage(Driver);

            googlePage.SearchByEnteredText("Selenium" + Keys.Enter);
            googlePage.ClickOnGoogleResultLinkByNumber(1);

            Assert.AreEqual("SeleniumHQ Browser Automation", Driver.Title);
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }

    }
}
