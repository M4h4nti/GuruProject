using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GuruProject
{
    internal class MobilePage : BasePage
    {
        private IWebElement CompareButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@title='Compare']"));
            }
        }

        private IWebElement XperiaAddToCompare => driver.FindElement(By.CssSelector("a[href*= 'product/1'][class='link-compare']"));

        private IWebElement IphoneAddToCompare => driver.FindElement(By.CssSelector("a[href*= 'product/2'][class='link-compare']"));

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

        //public MobilePage PopUp { get; internal set; }

        internal void AddProductToCompare(string v)
        {
            switch (v)
            {
                case "Sony Xperia":
                    XperiaAddToCompare.Click();
                    break;
                case "IPhone":
                    IphoneAddToCompare.Click();
                    break;
                default:
                    break;
            }
        }

        internal PopupPage CompareProducts(IWebDriver driver)
        {
            CompareButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            return new PopupPage(driver);
        }

        public MobilePage(IWebDriver driver) : base(driver)
        { }

        public void SortBy(string v)
        {
            new SelectElement(DdlSort).SelectByText(v);
        }

        internal string GetXperiaPrice()
        {
            return Price.Text;
        }

        internal ShoppingCartPage AddXperiaToCart(IWebDriver driver)
        {
            XperiaAddToCartButton.Click();
            return new ShoppingCartPage(driver);
        }

        internal XperiaPage OpenXperiaPage(IWebDriver driver)
        {
            XperiaProduct.Click();
            return new XperiaPage(driver);
        }
    }
}