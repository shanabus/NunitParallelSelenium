using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium.Pages
{
    public class GliddenHomePage : PageBase
    {
        [FindsBy(How = How.Id, Using = "q")]
        private IWebElement SearchInput { get; set; }


        [FindsBy(How = How.ClassName, Using = "find-submit")]
        private IWebElement SearchButton { get; set; }

        public GliddenHomePage(IWebDriver driver) : base(driver)
        {
        }

        public GliddenResultsPage SearchForm(string term)
        {
            SearchInput.SendKeys(term);

            Thread.Sleep(1000);
            
            SearchButton.Click();

            return PageFactory.InitElements<GliddenResultsPage>(_driver);
        }
    }
}
