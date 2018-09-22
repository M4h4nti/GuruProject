using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    internal class TVPage : BasePage
    {
        private IWebElement LinkAddToWishList => driver.FindElement(By.CssSelector("a[href*= 'product/4'][class='link-wishlist']"));

        public TVPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to TV Page..");
        

        internal MyWishListPage AddProductToWishList()
        {
            ReportHelper.TestStepInfo("Product Adding to wishList..");
            LinkAddToWishList.Click();
            ReportHelper.PassingTestStep("Product added..");
            return new MyWishListPage(driver);
        }        
    }
}