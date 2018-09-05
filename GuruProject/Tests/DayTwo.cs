using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Cost Verification")]
    public class DayTwo : BaseTest
    {
        [TestMethod]
        [Description("Verify cost of product in list and actual page")]
        [TestProperty("Author","VJKumar")]
        public void VerifyCost()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var mobilePage = homePage.OpenMobilePage(Driver);
            var priceOnMobilePage = mobilePage.GetXperiaPrice();
            var experiaPage = mobilePage.OpenXperiaPage(Driver);
            var priceOnProductPage = experiaPage.GetPrice();
            Assert.AreEqual(priceOnMobilePage, priceOnProductPage, "Some thing is different.. Look into it");
        }
    }
}
