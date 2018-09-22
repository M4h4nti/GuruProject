using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    internal class XperiaPage : BasePage
    {
        public XperiaPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Xperia Page..");
        
        private IWebElement Price => driver.FindElement(By.Id("product-price-1"));

        internal string GetPrice()
        {
            ReportHelper.TestStepInfo("Getting xperia price..");
            return Price.Text;
        }
    }
}