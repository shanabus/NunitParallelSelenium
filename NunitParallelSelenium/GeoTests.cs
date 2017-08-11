using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace NunitParallelSelenium
{
    [TestFixture]
    public class GeoTests
    {
        [Test]
        public void Can_ByPass_Geo()
        {
            //--use-fake-ui-for-media-stream"
            var options = new ChromeOptions();
            options.AddArgument("--use-fake-ui-for-media-stream");

            var driver = new ChromeDriver(options);
            driver.Url = "http://localhost/geo.html"; // here you would need a local file attempting to serve geo coords 
            driver.Navigate();

            //IWebElement element = driver.FindElement(By.Id("coords"));
            

            var title = driver.Title;

            Thread.Sleep(8000);

            //var text = element.Text;

            driver.Close();
            driver.Quit();

            Assert.That(title, Is.EqualTo("Test Geo"));
            //Assert.That(text, Is.EqualTo("42.9710093"));
        }
    }
}
