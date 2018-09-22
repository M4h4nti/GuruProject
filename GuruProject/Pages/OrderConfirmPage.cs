using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    internal class OrderConfirmPage : BasePage
    {
        private IWebElement ValueOrderNumber => driver.FindElement(By.CssSelector("a[href*= 'order/view']"));

        public OrderConfirmPage(IWebDriver driver) :base(driver) => ReportHelper.PassingTestStep("Redirected to Order confirmation Page with order number..");
        
        
        internal string OrderNumber
        {            
            get
            {
                return ValueOrderNumber.Text;
            }
        }

        public bool OrderNumberIsDisplayed => ValueOrderNumber.Displayed;
    }
}