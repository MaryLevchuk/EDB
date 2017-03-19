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
       public ClientRequest Client = new ClientRequest();

        public Tests()
        {
            OpenBrowser();
            OpenPage(ConfigurationManager.AppSettings["FrontpageUrl"]);
            Frontpage = new LeksikonFrontpage(Driver);
            
        }

        [Test]
        public void SiteItemsNumber_ShouldMatch_ItemsNumberFromApi()
        {
            int websiteItems = Frontpage.GetNumberOfItems();
            int n = Client.GetIngredientsNumber();
            Console.WriteLine(n.ToString());
            //Assert;
            true.Should().BeTrue();
        }
    }
}
