using CreatingReports;
using OpenQA.Selenium;

namespace GuruProject
{
    public class BasePage
    {
        public readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}