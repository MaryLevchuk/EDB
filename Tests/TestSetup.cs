using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public abstract class TestSetup
    {
        public IWebDriver Driver = new ChromeDriver();

        
        public void OpenBrowser()
        {
            Driver.Manage().Window.Maximize();
        }

        public void OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
