using System;
using OpenQA.Selenium;
using Utilities;
using static Utilities.WebElementExtensions;

namespace GuruProject
{
    internal class RegistrationPage :BasePage
    {
        private IWebElement TextFirstName => driver.FindElement(By.Id("firstname"));
        private IWebElement TextLastName => driver.FindElement(By.Id("lastname"));
        private IWebElement TextEmail => driver.FindElement(By.Id("email_address"));
        private IWebElement TextPassword => driver.FindElement(By.Id("password"));
        private IWebElement TextConfirmPassword => driver.FindElement(By.Id("confirmation"));
        private IWebElement ButtonRegister => driver.FindElement(By.XPath("//*[@type='submit' and @title='Register']"));

        public RegistrationPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Registration Page..");
        

        internal AccountPage CreateAccount(string FirstName, string LastName, string Email, string Password, string ConfirmPassword)
        {
            ReportHelper.TestStepInfo("Creating account...");
            TextFirstName.EnterText(FirstName);
            TextLastName.EnterText(LastName);
            TextEmail.EnterText(Email);
            TextPassword.EnterText(Password);
            TextConfirmPassword.EnterText(ConfirmPassword);
            ButtonRegister.Click();
            ReportHelper.PassingTestStep("Account created sucessfully...");
            return new AccountPage(driver);
        }
    }
}