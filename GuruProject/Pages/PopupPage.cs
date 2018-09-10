using System;
using OpenQA.Selenium;
using static Utilities.TableHelper;


namespace GuruProject
{
    internal class PopupPage : BasePage
    {       
        private IWebElement Table => driver.FindElement(By.Id("product_comparison"));
        private IWebElement XperiaInCompareWindow => driver.FindElement(By.XPath("//*[text()='Sony Xperia']"));
        private IWebElement IPhoneInCompareWindow => driver.FindElement(By.XPath("//*[text()='IPhone']"));
        private IWebElement ButtonClose => driver.FindElement(By.XPath("//*[@title='Close Window']"));

        public PopupPage(IWebDriver driver) :base(driver)
        {}

        internal void Close()
        {
            ButtonClose.Click();
        }

        public string GetTableData(string ColumnName,int rowNum)
        {
            ReadTable(Table);
            return ReadCell(ColumnName, rowNum);
        }
           
        internal bool AreProductsPresent()
        {
            if ((XperiaInCompareWindow.Displayed) && (IPhoneInCompareWindow.Displayed))
                return true;
            else return false;
        }

       
    }
}