using System;
using OpenQA.Selenium;

namespace GuruProject
{
    public class AccountPage : BasePage
    {
        private IWebElement LinkMyWishList => driver.FindElement(By.LinkText("MY WISHLIST"));
        private IWebElement LinkTV => driver.FindElement(By.XPath("//a[text()='TV']"));

        public AccountPage(IWebDriver driver) :base(driver)
        {}

        internal TVPage OpenTVPage()
        {
            LinkTV.Click();
            return new TVPage(driver);
        }

        public MyWishListPage OpenMyWishList()
        {
            LinkMyWishList.Click();
            return new MyWishListPage(driver);
        }
    }
}