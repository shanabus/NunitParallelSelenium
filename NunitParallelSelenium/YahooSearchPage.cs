using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium
{
    public class YahooSearchPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "uh-search-box")]
        public IWebElement SearchField { get; set; }

        public YahooSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public PageBase SearchTerm(string term)
        {
            SearchField.SendKeys(term);

            //Thread.Sleep(1000);

            SearchField.SendKeys(Keys.Return);

            return new YahooSearchPage(_driver);
        }
    }
}