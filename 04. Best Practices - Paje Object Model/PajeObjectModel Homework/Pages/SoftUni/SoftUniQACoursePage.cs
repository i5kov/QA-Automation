using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.SoftUni
{
    public class SoftUniQACoursePage : BasePage
    {
        private readonly By _courseTitle = By.CssSelector("h1");

        public SoftUniQACoursePage(IWebDriver driver) : base(driver) { }

        public string GetCourseTitle()
        {
            return FindElement(_courseTitle).Text;
        }
    }
}
