using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NunitParallelSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium
{
    [TestFixture]
    public class GliddenTests
    {
        [Test]
        [Parallelizable(ParallelScope.All)]
        public void Can_Navigate_To_And_Search_Page_Object([Values("how much paint", "when to paint", "is paint edible?")] string term)
        {
            var url = "https://glidden.com";

            var driver = new ChromeDriver();
            driver.Url = url;
            driver.Navigate();

            var homePage = PageFactory.InitElements<GliddenHomePage>(driver);

            homePage.SearchForm(term).RefineSearch("refined search");

            Thread.Sleep(1000);

            var title = driver.Title;

            driver.Dispose();

            Assert.That(title, Is.EqualTo("Search Results - Glidden.com"));
        }


        [Test]
        public void Can_Navigate_To_And_Search()
        {
            var url = "https://glidden.com";

            var driver = new ChromeDriver();
            driver.Url = url;
            driver.Navigate();

            var title = driver.Title;

            Thread.Sleep(2000);

            IWebElement searchInput = driver.FindElementById("q");
            searchInput.SendKeys("kunfu");

            Thread.Sleep(2000);

            IWebElement searchSubmit = driver.FindElementByClassName("find-submit");
            searchSubmit.Click();

            Thread.Sleep(20000);

            driver.Dispose();

            Assert.That(title, Is.EqualTo("Interior And Exterior Paints & Colors - Glidden.com"));
        }


        [Test]
        public void Can_Navigate_To_()
        {
            var url = "https://glidden.com";

            var driver = new ChromeDriver();
            driver.Url = url;
            driver.Navigate();

            var title = driver.Title;

            driver.Dispose();

            Assert.That(title, Is.EqualTo("Interior And Exterior Paints & Colors - Glidden.com"));
        }
    }
}
