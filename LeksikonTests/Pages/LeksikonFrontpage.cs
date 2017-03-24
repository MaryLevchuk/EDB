using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LeksikonTests.Pages
{
    public class LeksikonFrontpage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = ".encyclopedia__ingredients ul li")]
        private IList<IWebElement> Ingredients;

        [FindsBy(How = How.CssSelector, Using = ".encyclopedia__guids__list-item")]
        private IList<IWebElement> Guides;

        public int IngredientsNumber = 0;
        public int InstructionsNumber = 0;
        public int TechniquesNumber = 0;
        public int GuidesNumber = 0;

        public LeksikonFrontpage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void GetNumberOfItems()
        {
           IngredientsNumber = Ingredients.Count;
           GuidesNumber = Guides.Count;

            var allContexts = FindAllLettersContexts();       
            foreach (var letterContext in allContexts)
            {
              var allCategories = FindAllNonIngredientsCategoriesIn(letterContext);
                foreach (var category in allCategories)
                {
                    InstructionsNumber += GetItemsNumberIn(category, "Instruktioner");
                    TechniquesNumber += GetItemsNumberIn(category, "Teknikker");
                }
            }
        }

        public IList<IWebElement> FindAllLettersContexts()
        {
           return _driver.FindElements(By.CssSelector(".encyclopedia__list-item__content"));
        }

        public IList<IWebElement> FindAllNonIngredientsCategoriesIn(IWebElement letterContext)
        {
            return letterContext.FindElements(By.ClassName("encyclopedia__guids"));
        }

        public int CountAllItemsInCategory(IWebElement category)
        {
            return category.FindElements(By.CssSelector(".encyclopedia__ingredients__list .encyclopedia__ingredients__list-item")).Count;
        }

        public int GetItemsNumberIn(IWebElement category, string textToCheck)
        {
            int n = 0;
            if (category.Text.Contains(textToCheck))
            {
                n = CountAllItemsInCategory(category);
            }
            return n;
        }
    }
}
