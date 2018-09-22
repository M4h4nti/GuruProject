using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    internal class Homepage : BasePage
    {
        private IWebElement LnkMobile => driver.FindElement(By.XPath("//*[text()='Mobile']"));
        private IWebElement LinkAccount => driver.FindElement(By.XPath("//*[@class='label' and text()='Account']"));
        private IWebElement LinkMyAccount => driver.FindElement(By.LinkText("My Account"));

        public Homepage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirecting to Home Page..");
        

        public void GoTo()
        {
            ReportHelper.TestStepInfo("Opening homepage Url");
            driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");
            ReportHelper.PassingTestStep("Home Page Opened Succesfully..");
        }

        public MobilePage OpenMobilePage(IWebDriver driver)
        {
            ReportHelper.TestStepInfo("Opening mobile page..");
            LnkMobile.Click();
            return new MobilePage(driver);
        }

        internal LoginPage GoToAccountPage()
        {
            ReportHelper.TestStepInfo("Clicking Account link..");
            LinkAccount.Click();
            ReportHelper.TestStepInfo("clicking MyAccount link..");
            LinkMyAccount.Click();
            return new LoginPage(driver);
        }
    }
}