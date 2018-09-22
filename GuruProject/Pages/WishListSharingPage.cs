using System;
using OpenQA.Selenium;
using Utilities;
using static Utilities.WebElementExtensions;

namespace GuruProject
{
    internal class WishListSharingPage : BasePage
    {
        private IWebElement TextEmail => driver.FindElement(By.Id("email_address"));
        private IWebElement TextMessage => driver.FindElement(By.Id("message"));
        private IWebElement ButtonShare => driver.FindElement(By.XPath("//*[@title='Share Wishlist']"));
        private IWebElement MsgSuccess => driver.FindElement(By.ClassName("messages"));

        public WishListSharingPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to WishList sharing Page..");
        

        public string SuccessMessage => MsgSuccess.Text;

        internal void ShareWithMessage(string Email,string Message)
        {
            ReportHelper.TestStepInfo("Sharing wish list with message..");
            TextEmail.EnterText(Email);
            TextMessage.EnterText(Message);
            ButtonShare.Click();
            ReportHelper.PassingTestStep("Sucessfully shared the with list with message");
        }
    }
}