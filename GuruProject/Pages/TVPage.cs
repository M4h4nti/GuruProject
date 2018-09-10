using System;
using OpenQA.Selenium;

namespace GuruProject
{
    internal class TVPage : BasePage
    {
        private IWebElement LinkAddToWishList => driver.FindElement(By.CssSelector("a[href*= 'product/4'][class='link-wishlist']"));

        public TVPage(IWebDriver driver) : base(driver)
        {}

        internal MyWishListPage AddProductToWishList()
        {
            LinkAddToWishList.Click();
            return new MyWishListPage(driver);
        }        
    }
}