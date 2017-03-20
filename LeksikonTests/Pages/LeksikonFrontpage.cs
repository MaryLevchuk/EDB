using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LeksikonTests.Pages
{
    public class LeksikonFrontpage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "encyclopedia__ingredients__list-item")]
        private IList<IWebElement> Items;

        [FindsBy(How = How.CssSelector, Using = ".encyclopedia__ingredients")]
        private IList<IWebElement> Ingredients;
        
        //private IWebElement Item;

        public LeksikonFrontpage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public int GetNumberOfItems()
        {
            //return Items.Count;
            int n = Ingredients.Count;
            return n;

        }
    }
}
