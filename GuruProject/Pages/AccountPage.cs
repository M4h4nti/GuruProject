using System;
using Utilities;
using OpenQA.Selenium;

namespace GuruProject
{
    public class AccountPage : BasePage
    {
        private IWebElement LinkMyWishList => driver.FindElement(By.LinkText("MY WISHLIST"));
        private IWebElement LinkTV => driver.FindElement(By.XPath("//a[text()='TV']"));

        public AccountPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Account Page..");

        internal TVPage OpenTVPage()
        {
            ReportHelper.TestStepInfo("Linktext TV to be clicked...");
            LinkTV.Click();
            return new TVPage(driver);            
        }

        public MyWishListPage OpenMyWishList()
        {
            ReportHelper.TestStepInfo("Wish List to be clicked..");
            LinkMyWishList.Click();
            return new MyWishListPage(driver);
        }
    }
}