using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PajeObjectModel_Homework.Tests
{
    class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        protected void StartBrowser()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
        }

        protected void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }

        protected void NavigateToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
