using OpenQA.Selenium;

namespace FunctionalTests.PagesAndElements
{
    public class EMailPage : PageBase
    {
        public EMailPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        private IWebElement WriteALetterButton => FindElementByXPath(".//div[@id='LEGO']/div[@class = 'b-sticky']//span[.='Написать письмо']");
        private IWebElement Logo => FindElementByXPath(".//a[@class='pm-logo__link']");
        private IWebElement RecipientEmailInput => FindElementByXPath(".//div[@data-blockid='compose_to']/div");

        private IWebElement TitleEmailInput => FindElementByXPath(".//input[@name='Subject']");
        private IWebElement MessageIframe => FindElementByXPath(".//iframe[contains(@id, 'toolkit')]");
        private IWebElement MesageInput => FindElementById("tinymce");
        private IWebElement SendButton => FindElementByXPath(".//div[@class='b-sticky js-not-sticky']//span[.='Отправить']");
        private IWebElement SendedTitle => FindElementByXPath(".//div[@class='message-sent__title']");
        public override void BrowseWaitVisible()
        {
            WaitRedyControl(Logo);
        }

        public void SendEmail(string recipientEmail, string title, string messege)
        {
            WaitRedyControl(WriteALetterButton);
            WriteALetterButton.Click();
            RecipientEmailInput.Click();
            RecipientEmailInput.SendKeys(recipientEmail);
            WaitRedyControl(TitleEmailInput);
            TitleEmailInput.SendKeys(title);
            driver.SwitchTo().Frame(MessageIframe);
            WaitRedyControl(MesageInput);
            MesageInput.SendKeys(messege);
            driver.SwitchTo().DefaultContent();
            WaitRedyControl(SendButton);
            SendButton.Click();
            WaitRedyControl(SendedTitle, "Ваше письмо отправлено. Перейти во Входящие");
        }
    }
}
