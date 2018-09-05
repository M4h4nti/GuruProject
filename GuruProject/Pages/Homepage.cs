using System;
using OpenQA.Selenium;

namespace GuruProject
{
    internal class Homepage : BasePage
    {
        private IWebElement LnkMobile => driver.FindElement(By.XPath("//*[text()='Mobile']"));

        public Homepage(IWebDriver driver) : base(driver)
        {}

        public void GoTo() => driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");

        public MobilePage OpenMobilePage(IWebDriver driver)
        {
            LnkMobile.Click();
            return new MobilePage(driver);
        }
    }
}