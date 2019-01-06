using OpenQA.Selenium;
using Utilities;
using System.Windows.Forms;

namespace GuruProject
{
    public class OrderPage : BasePage
    {
        IWebElement LblOrderNumberAndStatus => driver.FindElement(By.XPath("//h1"));

        IWebElement LinkPrintOrder => driver.FindElement(By.XPath("//a[@class='link-print']"));

        public OrderPage(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to Orders Page..");

        public string OrderNumber => GetOrderNumber();

        public string Status => GetStatus();        

        public void PrintOrder()
        {
            //System.Console.WriteLine(driver.CurrentWindowHandle);
            LinkPrintOrder.Click();
            SendKeys.SendWait("{ENTER}");
            //System.Console.WriteLine(driver.CurrentWindowHandle);
        }

        private string GetOrderNumberAndStatus()
        {
            return LblOrderNumberAndStatus.Text;
        }

        string GetOrderNumber()
        {
           return GetOrderNumberAndStatus().Split('-')[0].Trim();
        }

        string GetStatus()
        {
            return GetOrderNumberAndStatus().Split('-')[1].Trim();
        }
    }
}