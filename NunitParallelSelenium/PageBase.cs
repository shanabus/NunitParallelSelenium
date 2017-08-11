using OpenQA.Selenium;

namespace NunitParallelSelenium
{
    public abstract class PageBase
    {
        public IWebDriver _driver;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
