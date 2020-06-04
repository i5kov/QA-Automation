using NUnit.Framework;
using PajeObjectModel_Homework.Pages.AutomationPractice;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Tests.AutomationPractice
{
    class AutomationPracticeTests : BaseTest
    {
        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.AutomationPracticeSite);
        }

        [Test]
        public void test1()
        {
            string email = "test123@test.bg";
            HomePage homePage = new HomePage(Driver);

            SignInPage signInPage = homePage.ClickSignIn();
            CreateAccountPage createAccountPage = signInPage.CreateAccount(email);

            Assert.AreEqual(email, createAccountPage.GetEmailFieldValue());
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
    }
}
