using OpenQA.Selenium;
using Utilities;

namespace GuruProject
{
    public class MyOrders : BasePage
    {
        public MyOrders(IWebDriver driver) : base(driver) => ReportHelper.PassingTestStep("Redirected to My orders..");

        private IWebElement LinkViewOrder => driver.FindElement(By.LinkText("VIEW ORDER"));

        public OrderPage ViewOrder()
        {
            ReportHelper.TestStepInfo("Clicking view order link..");
            LinkViewOrder.Click();
            return new OrderPage(driver);
        }
    }
}
