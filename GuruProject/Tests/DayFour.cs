using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Handle Popup")]
    public class DayFour : BaseTest
    {
        [TestMethod]
        [Description("Verify that you are able to compare two product")]
        [TestProperty("Author","VJKumar")]
        public void HandleWindowPopup()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var mobilePage = homePage.OpenMobilePage(Driver);            
            mobilePage.AddProductToCompare("Sony Xperia");
            mobilePage.AddProductToCompare("IPhone");
            var popupPage = mobilePage.CompareProducts(Driver);
            //mobilePage.PopUp.IsValueTrue();
            //Console.WriteLine(popupPage.GetTableData("SKU", 3));
            Assert.IsTrue(Driver.PageSource.Contains("Compare Products"));
            Assert.IsTrue(popupPage.AreProductsPresent());
            popupPage.Close();
        }
    }
}
