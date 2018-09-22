using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    public class MyWishListPage : BasePage
    {
        private IWebElement ButtonAddToCart => driver.FindElement(By.XPath("//button[@title='Add to Cart' and @type='button']"));
        private IWebElement ButtonShareWishList => driver.FindElement(By.Name("save_and_share"));

        public MyWishListPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to MyWishList Page..");
        

        internal WishListSharingPage ShareWishList()
        {
            ReportHelper.TestStepInfo("Sharing Wish List..");
            ButtonShareWishList.Click();
            return new WishListSharingPage(driver);
        }

        internal ShoppingCartPage AddToCart()
        {
            ReportHelper.TestStepInfo("Adding wish list to cart..");
            ButtonAddToCart.Click();
            return new ShoppingCartPage(driver);
        }
    }
}