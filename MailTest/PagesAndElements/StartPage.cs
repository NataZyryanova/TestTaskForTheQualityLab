using OpenQA.Selenium;

namespace FunctionalTests.PagesAndElements
{
    public class StartPage : PageBase
    {
        public StartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public const string LocalPath = "https://mail.ru/";
        public const string LogoText = "Mail.ru";
        private const string LogInButtonText = "Войти";

        public IWebElement Search => FindElementById("search");
        public IWebElement Logo => FindElementById("logo");
        IWebElement UserNameInput => FindElementById("mailbox:login");
        IWebElement PassInput => FindElementById("mailbox:password");
        IWebElement LogInButton => FindElementById("mailbox:submit");
        public override void BrowseWaitVisible()
        {
            WaitRedyControl(Search, string.Empty);
            WaitRedyControl(Logo, LogoText);
        }

        public void LogIn(string userName, string pass)
        {
            WaitRedyControl(UserNameInput, string.Empty);
            UserNameInput.SendKeys(userName);
            WaitRedyControl(PassInput, string.Empty);
            PassInput.SendKeys(pass);
            WaitRedyControl(LogInButton, LogInButtonText);
            LogInButton.Click();
        }

    }
}
