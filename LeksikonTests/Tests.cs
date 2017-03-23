using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LeksikonTests.Helpers;
using LeksikonTests.Pages;
using NUnit.Framework;



namespace LeksikonTests
{
    public class Tests : TestSetup
    {
       public LeksikonFrontpage Frontpage;
       public ClientRequest Api = new ClientRequest();

        public Tests()
        {
            OpenBrowser();
            OpenPage(ConfigurationManager.AppSettings["FrontpageUrl"]);
            Frontpage = new LeksikonFrontpage(Driver);
            Frontpage.GetNumberOfItems();
            Api.GetItemsNumber();
        }

        [Test]
        public void SiteIngredientsNumber_ShouldMatch_IngredientsNumberFromApi()
        {
            Frontpage.IngredientsNumber.Should().Be(Api.IngredientsNumber);
        }

        [Test]
        public void SiteInstructionsNumber_ShouldMatch_InstructionsNumberFromApi()
        {
            Frontpage.InstructionsNumber.Should().Be(Api.InstructionsNumber);
        }

        [Test]
        public void SiteTechniquesNumber_ShouldMatch_TechniquesNumberFromApi()
        {
            Frontpage.TechniquesNumber.Should().Be(Api.TechniquesNumber);
        }

        [Test]
        public void SiteGuidesNumber_ShouldMatch_GuidesNumberFromApi()
        {
            Frontpage.GuidesNumber.Should().Be(Api.GuidesNumber);
        }
    }
}
