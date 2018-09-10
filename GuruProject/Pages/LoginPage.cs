using System;
using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    internal class LoginPage : BasePage
    {
        private IWebElement TextLoginEmail => driver.FindElement(By.Id("email"));
        private IWebElement TextLoginPassword => driver.FindElement(By.Id("pass"));
        private IWebElement ButtonLogin => driver.FindElement(By.Id("send2"));
        private IWebElement LinkCreateAccount => driver.FindElement(By.XPath("//*[@title='Create an Account']"));


        public LoginPage(IWebDriver driver) : base(driver)
        {}

        internal RegistrationPage CreateNewAccount()
        {
            LinkCreateAccount.Click();
            return new RegistrationPage(driver);
        }

        internal AccountPage Login(string Email, string Password)
        {
            TextLoginEmail.EnterText(Email);
            TextLoginPassword.EnterText(Password);
            ButtonLogin.Click();
            return new AccountPage(driver);
        }
    }
}