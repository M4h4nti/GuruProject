using System;
using OpenQA.Selenium;

namespace GuruProject
{
    internal class ShoppingCart : BasePage
    {
        private IWebElement EmptyButton => driver.FindElement(By.Id("empty_cart_button"));
        private IWebElement AddQuantity => driver.FindElement(By.XPath("//*[starts-with(@name,'cart')]"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//*[@title = 'Update']"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//*[@class= 'item-msg error']"));

        public ShoppingCart(IWebDriver driver) : base(driver)
        {}

        internal void UpdateQuantity()
        {
            AddQuantity.Clear();
            AddQuantity.SendKeys("1000");
            UpdateButton.Click();
        }

        internal void EmptyCart()
        {
            EmptyButton.Click();
        }

        public bool ErrorMessageDisplayed => ErrorMessage.Displayed;
    }
}