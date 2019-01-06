using System;
using Utilities;
using OpenQA.Selenium;

namespace GuruProject
{
    public class AccountPage : BasePage
    {
        private IWebElement LinkMyWishList => driver.FindElement(By.LinkText("MY WISHLIST"));
        private IWebElement LinkTV => driver.FindElement(By.XPath("//a[text()='TV']"));
        private IWebElement LinkMyOrders => driver.FindElement(By.LinkText("MY ORDERS"));

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

        public MyOrders OpenMyOrders()
        {
            ReportHelper.TestStepInfo("My orders to be clicked..");
            LinkMyOrders.Click();
            return new MyOrders(driver);
        }
    }
}