using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GuruProject
{
    internal class ShoppingCartPage : BasePage
    {
        private IWebElement ButtonProceedToCheckout => driver.FindElement(By.XPath("//*[@class='method-checkout-cart-methods-onepage-bottom']/child::*"));
        private IWebElement ButtonUpdateTotal => driver.FindElement(By.Name("do"));
        private IWebElement RadioFlatRate => driver.FindElement(By.Name("estimate_method"));
        private IWebElement LinkEstimate => driver.FindElement(By.XPath("//button[@title='Estimate']"));
        private IWebElement DDLCountry => driver.FindElement(By.Id("country"));
        private IWebElement DDLState => driver.FindElement(By.Id("region_id"));
        private IWebElement TextZip => driver.FindElement(By.Id("postcode"));
        private IWebElement EmptyButton => driver.FindElement(By.Id("empty_cart_button"));
        private IWebElement AddQuantity => driver.FindElement(By.XPath("//*[starts-with(@name,'cart')]"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//*[@title = 'Update']"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//*[@class= 'item-msg error']"));
        private IWebElement TableTotal => driver.FindElement(By.Id("shopping-cart-totals-table"));
        private IWebElement TableTotalBody => TableTotal.FindElement(By.TagName("tbody"));
        private IReadOnlyList<IWebElement> TableTotalBodyRows => TableTotalBody.FindElements(By.TagName("tr"));

        internal CheckoutPage ProceedToCheckout()
        {
            ButtonProceedToCheckout.Click();
            return new CheckoutPage(driver);
        }

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        { }

        internal void UpdateQuantity(string value)
        {
            AddQuantity.EnterText(value);
            UpdateButton.Click();
        }

        internal void UpdateTotal()
        {
            if (!RadioFlatRate.Selected)
                RadioFlatRate.Click();
            ButtonUpdateTotal.Click();
        }

        internal void EmptyCart()
        {
            EmptyButton.Click();
        }

        internal void EstimateShippingAndTax(string country, string state, string zip)
        {
            new SelectElement(DDLCountry).SelectByText(country);
            new SelectElement(DDLState).SelectByText(state);
            TextZip.EnterText(zip);
            LinkEstimate.Click();
        }

        public bool ErrorMessageDisplayed => ErrorMessage.Displayed;

        public bool ShippingCostGenerated => RadioFlatRate.Displayed;

        public bool ShippingCostAdded => TableTotalBodyRows.Count > 1 ? true : false;
    }
}