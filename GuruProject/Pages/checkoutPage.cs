using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GuruProject
{
    internal class CheckoutPage : BasePage
    {
        private IWebElement BillingAdress => driver.FindElement(By.Id("billing-address-select"));
        private IWebElement ButtonPlaceOrder => driver.FindElement(By.XPath("//*[@title='Place Order']"));
        private IWebElement ButtonPaymentInformationContinue => driver.FindElement(By.XPath("//*[@onclick='payment.save()']"));
        private IWebElement RadioMoneyOrder => driver.FindElement(By.XPath("//*[contains(@for,'p_method_checkmo')]"));
        private IWebElement ButtonBillingInformationContinue => driver.FindElement(By.XPath("//*[@title='Continue' and @onclick='billing.save()']"));
        private IWebElement ButtonShippingMethodContinue => driver.FindElement(By.XPath("//*[@id='shipping-method-buttons-container']/child::button"));
        private IWebElement RadioShipToThisAddress => driver.FindElement(By.Id("billing:use_for_shipping_yes"));
        private IWebElement TextFirstName => driver.FindElement(By.Id("billing:firstname"));
        private IWebElement TextLastName => driver.FindElement(By.Id("billing:lastname"));
        private IWebElement TextAddress => driver.FindElement(By.Id("billing:street1"));
        private IWebElement TextCity => driver.FindElement(By.Id("billing:city"));
        private IWebElement Textzip => driver.FindElement(By.Id("billing:postcode"));
        private IWebElement TextTelephone => driver.FindElement(By.Id("billing:telephone"));
        private IWebElement DDLState => driver.FindElement(By.Id("billing:region_id"));
        private IWebElement DDLCountry => driver.FindElement(By.Id("billing:country_id"));

        bool BillingAddressPresent => BillingAdress.Displayed;

        public CheckoutPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Check Out Page..");
        

        internal void UpdateBillingInformation(string firstName, string lastName, string address, string city,
            string country, string state, string zip, string telephone)
        {
            if (!BillingAddressPresent)
            {
                ReportHelper.TestStepInfo("Updating Billing information of Customer..");
                TextFirstName.EnterText(firstName);
                TextLastName.EnterText(lastName);
                TextAddress.EnterText(address);
                TextCity.EnterText(city);
                new SelectElement(DDLState).SelectByText(state);
                Textzip.EnterText(zip);
                new SelectElement(DDLCountry).SelectByText(country);
                TextTelephone.EnterText(telephone);
            }

            if (!RadioShipToThisAddress.Selected)
                RadioShipToThisAddress.Click();

            ButtonBillingInformationContinue.Click();
            ReportHelper.PassingTestStep("Updated billing info of customer successfully...");
        }

        internal OrderConfirmPage PlaceOrder()
        {
            ReportHelper.TestStepInfo("Clicking Place order..");
            //WaitUntilElementVisible(By.XPath("//*[@title='Place Order']"));
            ButtonPlaceOrder.Click();
            return new OrderConfirmPage(driver);
        }

        internal void SelectPaymentInformationAndContinue()
        {
            ReportHelper.TestStepInfo("Selecting Payment method..");
            //WaitHelper.WaitUntilVisible(driver, By.XPath("//*[contains(@for,'p_method_checkmo')]"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //WaitHelper.WaitUntilTextElement(driver, RadioMoneyOrder, "Check / Money order ");
            //WaitUntilElementVisible(By.Id("p_method_checkmo"));
            RadioMoneyOrder.Click();                        
            ReportHelper.TestStepInfo("Clicking continue Button after selecting payment method..");
            //WaitUntilElementVisible(By.XPath("//*[@onclick='payment.save()']"));
            ButtonPaymentInformationContinue.Click();
            ReportHelper.PassingTestStep("Continue Button after selecting payment method clicked successfully...");
        }

        internal void ShippingMethodContinue()
        {
            ReportHelper.TestStepInfo("Waiting for button to visible..");
            //WaitHelper.WaitUntilVisible(driver,By.XPath("//*[@id='shipping-method-buttons-container']/child::button"));
            WaitUntilElementVisible(By.XPath("//*[@id='shipping-method-buttons-container']/child::button"));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ButtonShippingMethodContinue.Click();
            ReportHelper.PassingTestStep("Continue Button after shipping method clicked successfully...");
        }

        private void WaitUntilElementVisible(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}