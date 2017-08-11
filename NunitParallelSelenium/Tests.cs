using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium
{
    [TestFixture]
    public class Tests
    {
        [Test] 
        [Parallelizable(ParallelScope.All)]
        public void CanSearch_Chrome([Values("people", "time")] string term)
        {
            var driver = new ChromeDriver();
            driver.Url = "http://www.google.com/";
            driver.Navigate();

            GoogleSearchPage page = PageFactory.InitElements<GoogleSearchPage>(driver);

            page.SearchTerm(term);
            

            var title = driver.Title;

            driver.Close();
            driver.Quit();

            Assert.That(title, Is.EqualTo(term + " - Google Search"));
        }

        [Test] 
        [Parallelizable(ParallelScope.All)]
        public void CanSearch_Firefox([Values("people", "time")] string term)
        {
            var service = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            var options = new FirefoxProfile();

            var driver = new FirefoxDriver(service, options);
            driver.Url = "http://www.yahoo.com/";
            driver.Navigate();

            YahooSearchPage page = PageFactory.InitElements<YahooSearchPage>(driver);

            page.SearchTerm(term);
            
            Thread.Sleep(2000);

            var title = driver.Title;

            driver.Close();
            driver.Quit();

            Assert.That(title, Is.EqualTo(term + " - Yahoo Search Results"));
        }

        [Test] 
        [Parallelizable(ParallelScope.All)]
        public void CanSearch_Gecko([Values("people", "time")] string term)
        {
            var driver = new FirefoxDriver();
            driver.Url = "http://www.yahoo.com/";
            driver.Navigate();

            YahooSearchPage page = PageFactory.InitElements<YahooSearchPage>(driver);

            page.SearchTerm(term);
            
            Thread.Sleep(2000);

            var title = driver.Title;

            driver.Close();
            driver.Quit();

            Assert.That(title, Is.EqualTo(term + " - Yahoo Search Results"));
        }

        [Test] 
        //[Parallelizable(ParallelScope.All)]
        public void CanSearch_Ie([Values("people")] string term)
        {
            var options = new InternetExplorerOptions();
            //options.EnsureCleanSession = true;
            //options.ForceCreateProcessApi = true;

            var driver = new InternetExplorerDriver(); //(options);
            driver.Url = "http://www.bing.com/";
            driver.Navigate();

            BingSearchPage page = PageFactory.InitElements<BingSearchPage>(driver);

            page.SearchTerm(term);
            
            //Thread.Sleep(2000);

            var title = driver.Title.ToString();

            driver.Quit();
            driver.Close();

            Assert.That(title, Is.EqualTo(term + " - Bing"));
        }
        
        [Test] 
        //[Parallelizable(ParallelScope.All)]
        public void CanSearch_Edge([Values("people")] string term)
        {
            
            var driver = new EdgeDriver();
            driver.Url = "http://www.bing.com/";
            driver.Navigate();

            BingSearchPage page = PageFactory.InitElements<BingSearchPage>(driver);

            page.SearchTerm(term);
            
            //Thread.Sleep(2000);

            var title = driver.Title;

            driver.Quit();
            driver.Close();

            Assert.That(title, Is.EqualTo(term + " - Bing"));
        }
    }
}
