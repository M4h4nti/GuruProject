using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GuruProject
{
    internal class CheckoutPage : BasePage
    {
        private IWebElement ButtonPlaceOrder => driver.FindElement(By.XPath("//*[@title='Place Order']"));
        private IWebElement ButtonPaymentInformationContinue => driver.FindElement(By.XPath("//*[@onclick='payment.save()']"));
        private IWebElement RadioMoneyOrder => driver.FindElement(By.Id("p_method_checkmo"));
        private IWebElement ButtonBillingInformationContinue => driver.FindElement(By.XPath("//*[@title='Continue' and @onclick='billing.save()']"));
        private IWebElement ButtonShippingMethodContinue => driver.FindElement(By.XPath("//*[@onclick='shippingMethod.save()']"));
        private IWebElement RadioShipToThisAddress => driver.FindElement(By.Id("billing:use_for_shipping_yes"));
        private IWebElement TextFirstName => driver.FindElement(By.Id("billing:firstname"));
        private IWebElement TextLastName => driver.FindElement(By.Id("billing:lastname"));
        private IWebElement TextAddress => driver.FindElement(By.Id("billing:street1"));
        private IWebElement TextCity => driver.FindElement(By.Id("billing:city"));
        private IWebElement Textzip => driver.FindElement(By.Id("billing:postcode"));
        private IWebElement TextTelephone => driver.FindElement(By.Id("billing:telephone"));
        private IWebElement DDLState => driver.FindElement(By.Id("billing:region_id"));
        private IWebElement DDLCountry => driver.FindElement(By.Id("billing:country_id"));

        public CheckoutPage(IWebDriver driver) : base(driver)
        { }

        internal void UpdateBillingInformation(string firstName, string lastName, string address, string city,
            string country, string state, string zip, string telephone)
        {
            TextFirstName.EnterText(firstName);
            TextLastName.EnterText(lastName);
            TextAddress.EnterText(address);
            TextCity.EnterText(city);
            new SelectElement(DDLState).SelectByText(state);
            Textzip.EnterText(zip);
            new SelectElement(DDLCountry).SelectByText(country);
            TextTelephone.EnterText(telephone);

            if (!RadioShipToThisAddress.Selected)
                RadioShipToThisAddress.Click();

            ButtonBillingInformationContinue.Click();
        }

        internal OrderConfirmPage PlaceOrder()
        {
            ButtonPlaceOrder.Click();
            return new OrderConfirmPage(driver);
        }

        internal void SelectPaymentInformationAndContinue()
        {
            RadioMoneyOrder.Click();
            ButtonPaymentInformationContinue.Click();
        }

        internal void ShippingMethodContinue()
        {            
            ButtonShippingMethodContinue.Click();
        }
    }
}