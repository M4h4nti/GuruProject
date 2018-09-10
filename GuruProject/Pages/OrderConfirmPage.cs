using System;
using OpenQA.Selenium;

namespace GuruProject
{
    internal class OrderConfirmPage : BasePage
    {
        private IWebElement ValueOrderNumber => driver.FindElement(By.CssSelector("a[href*= 'order/view']"));

        public OrderConfirmPage(IWebDriver driver) :base(driver)
        { }

        internal string OrderNumber
        {
            get
            {
                return ValueOrderNumber.Text;
            }
        }
    }
}