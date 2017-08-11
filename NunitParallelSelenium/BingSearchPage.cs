using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium
{
    public class BingSearchPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement SearchField { get; set; }

        public BingSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public PageBase SearchTerm(string term)
        {
            SearchField.SendKeys(term);

            //Thread.Sleep(1000);

            SearchField.SendKeys(Keys.Return);

            return new BingSearchPage(_driver);
        }
    }
}