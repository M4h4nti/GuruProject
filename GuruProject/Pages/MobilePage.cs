using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

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

        internal void AddProductToCompare(string mobileName)
        {
            ReportHelper.TestStepInfo("Adding procuts to compare List..");
            switch (mobileName)
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
            ReportHelper.TestStepPass("Added products sucesfully to compare List..");
        }

        internal PopupPage CompareProducts(IWebDriver driver)
        {
            ReportHelper.TestStepInfo("Comparing products in compare list..");
            CompareButton.Click();
            ReportHelper.TestStepInfo("New window pops up..");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ReportHelper.TestStepInfo("Window switch Success...");
            return new PopupPage(driver);
        }

        public MobilePage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Mobile Page..");
        

        public void SortBy(string value)
        {
            ReportHelper.TestStepInfo("Sorting by...");
            new SelectElement(DdlSort).SelectByText(value);
            ReportHelper.PassingTestStep("Sorted..");
        }

        internal string GetXperiaPrice()
        {
            ReportHelper.TestStepInfo("Getting xperia price..");
            ReportHelper.TestStepPass($"{Price.Text}");
            return Price.Text;
        }

        internal ShoppingCartPage AddXperiaToCart(IWebDriver driver)
        {
            ReportHelper.TestStepInfo("Adding xperia to cart..");
            XperiaAddToCartButton.Click();
            return new ShoppingCartPage(driver);
        }

        internal XperiaPage OpenXperiaPage(IWebDriver driver)
        {
            ReportHelper.TestStepInfo("Opening xperia page..");
            XperiaProduct.Click();
            return new XperiaPage(driver);
        }
    }
}