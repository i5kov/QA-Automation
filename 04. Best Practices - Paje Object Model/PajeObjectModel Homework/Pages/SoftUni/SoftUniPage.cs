using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.SoftUni
{
    public class SoftUniPage : BasePage
    {

        private readonly By _englishLanguageLink = By.CssSelector("a[data-lang-id='en']");
        private IWebElement _mainMenuLink(string linkText) => FindElement(By.XPath($"//ul[contains(@class, 'horizontal-list')]//li//span[text()='{linkText}']"));
        private IWebElement _course(string courseName) => FindElement(By.XPath($"//a[text()='{courseName}']"));

        public SoftUniPage(IWebDriver driver) : base(driver) { }

        public void ChangeSiteLanguageToEnglish()
        {
            ClickElement(_englishLanguageLink);
        }

        public void ClickOnLinkFromMainMenu(string linkText)
        {
            ClickElement(_mainMenuLink(linkText));
        }

        public SoftUniQACoursePage ClickOnCourseLink(string courseName)
        {
            ClickElement(_course(courseName));
            return new SoftUniQACoursePage(Driver);
        }
    }
}
