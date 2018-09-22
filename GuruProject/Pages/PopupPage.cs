using System;
using OpenQA.Selenium;
using Utilities;
using static Utilities.TableHelper;


namespace GuruProject
{
    internal class PopupPage : BasePage
    {       
        private IWebElement Table => driver.FindElement(By.Id("product_comparison"));
        private IWebElement XperiaInCompareWindow => driver.FindElement(By.XPath("//*[text()='Sony Xperia']"));
        private IWebElement IPhoneInCompareWindow => driver.FindElement(By.XPath("//*[text()='IPhone']"));
        private IWebElement ButtonClose => driver.FindElement(By.XPath("//*[@title='Close Window']"));

        public PopupPage(IWebDriver driver) :base(driver) => ReportHelper.PassingTestStep("Redirected to popup Page..");
        

        internal void Close()
        {
            ReportHelper.TestStepInfo("Closing the popup..");
            ButtonClose.Click();
            ReportHelper.TestStepPass("popup closed successfully..");
        }

        public string GetTableData(string ColumnName,int rowNum)
        {
            ReportHelper.TestStepInfo("Reading table data..");
            ReadTable(Table);
            return ReadCell(ColumnName, rowNum);
        }
           
        internal bool AreProductsPresent()
        {
            ReportHelper.TestStepInfo("Checking for presence of products in popup..");
            if ((XperiaInCompareWindow.Displayed) && (IPhoneInCompareWindow.Displayed))
                return true;
            else return false;
        }

       
    }
}