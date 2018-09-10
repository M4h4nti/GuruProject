using System;
using OpenQA.Selenium;

namespace GuruProject
{
    public class MyWishListPage : BasePage
    {
        private IWebElement ButtonAddToCart => driver.FindElement(By.XPath("//button[@title='Add to Cart' and @type='button']"));
        private IWebElement ButtonShareWishList => driver.FindElement(By.Name("save_and_share"));

        public MyWishListPage(IWebDriver driver) : base(driver)
        {}

        internal WishListSharingPage ShareWishList()
        {
            ButtonShareWishList.Click();
            return new WishListSharingPage(driver);
        }

        internal ShoppingCartPage AddToCart()
        {
            ButtonAddToCart.Click();
            return new ShoppingCartPage(driver);
        }
    }
}