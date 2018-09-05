using System;
using OpenQA.Selenium;

namespace GuruProject
{
    internal class XperiaPage : BasePage
    {
        public XperiaPage(IWebDriver driver) : base(driver)
        {}

        private IWebElement Price => driver.FindElement(By.Id("product-price-1"));

        internal string GetPrice()
        {
            return Price.Text;
        }
    }
}