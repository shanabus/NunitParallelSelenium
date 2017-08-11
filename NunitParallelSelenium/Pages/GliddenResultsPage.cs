using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitParallelSelenium.Pages
{
    public class GliddenResultsPage : PageBase
    {
        //html/body/div[3]/div/div/section[1]/div/div/form/input
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/section[1]/div/div/form/input")]
        private IWebElement RefinedInput { get; set; }

        public GliddenResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public GliddenResultsPage RefineSearch(string term)
        {
            RefinedInput.SendKeys(term);

            Thread.Sleep(2000);

            return PageFactory.InitElements<GliddenResultsPage>(_driver);
        }
    }
}