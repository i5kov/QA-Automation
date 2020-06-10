using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Pages.SoftUni
{
    public class SoftUniPage : BasePage
    {

        private readonly By _englishLanguageLink = By.CssSelector("a[data-lang-id='en']");
        private IWebElement MainMenuLink(string linkText) => FindElement(By.XPath($"//ul[contains(@class, 'horizontal-list')]//li//span[text()='{linkText}']"));
        private IWebElement Course(string courseName) => FindElement(By.XPath($"//a[text()='{courseName}']"));

        private readonly By _activeModule = By.XPath("//div[contains(@class, 'no-padding')]//div[contains(@class, 'sub')]");

        public SoftUniPage(IWebDriver driver) : base(driver) { }

        public void ChangeSiteLanguageToEnglish()
        {
            ClickElement(_englishLanguageLink);
        }

        internal SoftUniQACoursePage GoToQAAutomationCourse()
        {
            ClickElement(By.XPath("//a[contains(@href, 'Quality-Assurance')]"));
            ClickElement(By.XPath("//h4[contains(text(),'QA Automation')]"));
            return new SoftUniQACoursePage(Driver);
        }

        public void ClickOnLinkFromMainMenu(string linkText)
        {
            ClickElement(MainMenuLink(linkText));
        }

        public void ClickOnActiveModulesInOpenCoursesSection()
        {
            FindElements(_activeModule)[0].Click();
        }
    }
}
