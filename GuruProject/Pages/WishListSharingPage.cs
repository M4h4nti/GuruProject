using System;
using OpenQA.Selenium;
using static Utilities.WebElementExtensions;

namespace GuruProject
{
    internal class WishListSharingPage : BasePage
    {
        private IWebElement TextEmail => driver.FindElement(By.Id("email_address"));
        private IWebElement TextMessage => driver.FindElement(By.Id("message"));
        private IWebElement ButtonShare => driver.FindElement(By.XPath("//*[@title='Share Wishlist']"));
        private IWebElement MsgSuccess => driver.FindElement(By.ClassName("messages"));

        public WishListSharingPage(IWebDriver driver) : base(driver)
        {}

        public string SuccessMessage => MsgSuccess.Text;

        internal void ShareWithMessage(string Email,string Message)
        {
            TextEmail.EnterText(Email);
            TextMessage.EnterText(Message);
            ButtonShare.Click();
        }
    }
}