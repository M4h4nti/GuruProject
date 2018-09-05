using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GuruProject
{
    internal class MobilePage : BasePage
    {
        private IWebElement XperiaAddToCartButton => driver.FindElement(By.CssSelector("button[onclick*= 'product/1']"));

        private IWebElement DdlSort
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@title='Sort By']"));
            }
        }

        private IWebElement Price => driver.FindElement(By.Id("product-price-1"));

        //private IWebElement XperiaProduct => driver.FindElement(By.XPath("//*[ text()= 'Sony Xperia']"));

        private IWebElement XperiaProduct => driver.FindElement(By.LinkText("SONY XPERIA"));

        internal void CompareProducts()
        {
            throw new NotImplementedException();
        }

        public MobilePage(IWebDriver driver) : base(driver)
        {}

        public void SortBy(string v)
        {
            new SelectElement(DdlSort).SelectByText(v);
        }

        internal string GetXperiaPrice()
        {
            return Price.Text;
        }

        internal ShoppingCart AddXperiaToCart(IWebDriver driver)
        {
            XperiaAddToCartButton.Click();
            return new ShoppingCart(driver);
        }

        internal XperiaPage OpenXperiaPage(IWebDriver driver)
        {
            XperiaProduct.Click();
            return new XperiaPage(driver);
        }
    }
}