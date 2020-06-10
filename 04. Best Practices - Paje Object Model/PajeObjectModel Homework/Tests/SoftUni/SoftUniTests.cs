using NUnit.Framework;
using PajeObjectModel_Homework.Pages.SoftUni;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Tests.SoftUni
{
    [TestFixture]
    class SoftUniTests : BaseTest
    {
        [SetUp]
        public void BeforeEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.SoftuniSite);
        }

        [Test]
        public void Verify_UserIsCorrectlyNavigated_To_QAAutomationCoursePage()
        {
            SoftUniPage softUniPage = new SoftUniPage(Driver);

            softUniPage.ChangeSiteLanguageToEnglish();
            softUniPage.ClickOnLinkFromMainMenu("Trainings");
            softUniPage.ClickOnActiveModulesInOpenCoursesSection();
            SoftUniQACoursePage softUniQACoursePage = softUniPage.GoToQAAutomationCourse();

            Assert.AreEqual("QA Automation - May 2020", softUniQACoursePage.GetCourseTitle());
        }

        [TearDown]
        public void AfterEachTest()
        {
            CloseBrowser();
        }
        
    }
}
