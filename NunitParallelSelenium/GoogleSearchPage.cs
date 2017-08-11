using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium
{
    public class GoogleSearchPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement SearchField { get; set; }

        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public PageBase SearchTerm(string term)
        {
            SearchField.SendKeys(term);

            //Thread.Sleep(1000);

            SearchField.SendKeys(Keys.Return);

            return new GoogleSearchPage(_driver);
        }
    }
}