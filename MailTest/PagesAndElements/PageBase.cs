using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FunctionalTests.PagesAndElements
{
    public abstract class PageBase
    {
        private const int Timeout = 5000;
        public static IWebDriver driver;

        public abstract void BrowseWaitVisible();
        public PageBase(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebElement FindElementById(string idElement)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return webDriverWait.Until<IWebElement>(driver => driver.FindElement((By.Id(idElement))));
        }
        public IWebElement FindElementByXPath(string xPathElement)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return webDriverWait.Until(driver => driver.FindElement((By.XPath(xPathElement))));
        }
       
        public static void WaitRedyControl(IWebElement control, string expectedText = null, int timeout = Timeout)
        {
            Assert.IsTrue(control.Displayed);
            Assert.IsTrue(control.Enabled);
            if (expectedText!=null)
            {
                Assert.AreEqual(expectedText, control.Text);
            }
         }


    }
}
