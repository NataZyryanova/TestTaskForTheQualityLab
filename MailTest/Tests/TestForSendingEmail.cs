using FunctionalTests.PagesAndElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class TestForSendingEmail
    {
        IWebDriver webDriver;

        [SetUp]
        public void InitBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        [Description("Тест на логин и отправку письма")]
        public void TestForASuccessfulLoginAndSendingEmail()
        {
            webDriver.Navigate().GoToUrl(StartPage.LocalPath);
            StartPage startPage = new StartPage(webDriver);
            startPage.BrowseWaitVisible();
            startPage.LogIn("for_quality-lab", "123qweasd");
            var eMailPage = new EMailPage(webDriver);
            eMailPage.BrowseWaitVisible();
            eMailPage.SendEmail("emailAdress@gmail.com", "test", "message");
        }

        [TearDown]
        public void CloseWebDriver()
        {
            webDriver.Close();
        }
        
    }
}
